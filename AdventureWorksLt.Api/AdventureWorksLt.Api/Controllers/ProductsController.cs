using AdventureWorksLt.Shared.Dtos;
using AdventureWorksLt.Shared.Dtos.Product;
using AdventureWorksLt.Shared.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace AdventureWorksLt.Api.Controllers;

[Route("api/[controller]")]
public class ProductsController : Base.BaseController
{
    private readonly IProductService _productService;

    public ProductsController(ILogger logger, IProductService productService) : base(logger)
    {
        _productService = productService;
    }

    [HttpGet("")]
    public Task<IActionResult> GetProductsAsync() => 
        ResultAsync(_productService.GetProductsAsync());

    [HttpGet("{productId:int}")]
    public Task<IActionResult> GetProductDetailsAsync(int productId) => 
        ResultAsync(_productService.GetProductAsync(productId));

    [HttpPost("create")]
    public Task<IActionResult> CreateProductAsync([FromBody] ProductDetailsDto requestDto) => 
        ResultAsync(_productService.CreateProductAsync(requestDto));

    [HttpPut("update/{productId:int}")]
    public Task<IActionResult> UpdateProductAsync(int productId, [FromBody] ProductDetailsDto requestDto) => 
        ResultAsync(_productService.UpdateProductAsync(productId, requestDto));

    [HttpDelete("delete/{productId:int}")]
    public Task<IActionResult> DeleteProductAsync(int productId) => 
        ResultAsync(_productService.DeleteProductAsync(productId));
}