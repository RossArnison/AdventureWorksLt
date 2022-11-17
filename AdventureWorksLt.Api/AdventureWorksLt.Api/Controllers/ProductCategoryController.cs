using AdventureWorksLt.Shared.Dtos;
using AdventureWorksLt.Shared.Dtos.ProductCategory;
using AdventureWorksLt.Shared.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace AdventureWorksLt.Api.Controllers;

[Route("api/[controller]")]
public class ProductCategoryController : Base.BaseController
{
    private readonly IProductCategoryService _productCategoryService;

    public ProductCategoryController(ILogger logger, IProductCategoryService productCategoryService) : base(logger)
    {
        _productCategoryService = productCategoryService;
    }

    [HttpGet("")]
    public Task<IActionResult> GetProductCategoriesAsync() => 
        ResultAsync(_productCategoryService.GetProductCategoriesAsync());

    [HttpGet("{productCategoryId:int}")]
    public Task<IActionResult> GetProductCategoryDetailsAsync(int productCategoryId) => 
        ResultAsync(_productCategoryService.GetProductCategoryAsync(productCategoryId));

    [HttpPost("create")]
    public Task<IActionResult> CreateProductCategoryAsync(ProductCategoryDto requestDto) => 
        ResultAsync(_productCategoryService.CreateProductCategoryAsync(requestDto));

    [HttpPut("update/{productCategoryId:int}")]
    public Task<IActionResult> UpdateProductCategoryAsync(int productCategoryId, ProductCategoryDto requestDto) => 
        ResultAsync(_productCategoryService.UpdateProductCategoryAsync(productCategoryId, requestDto));

    [HttpDelete("delete/{productCategoryId:int}")]
    public Task<IActionResult> DeleteProductCategoryAsync(int productCategoryId) => 
        ResultAsync(_productCategoryService.DeleteProductCategoryAsync(productCategoryId));
}