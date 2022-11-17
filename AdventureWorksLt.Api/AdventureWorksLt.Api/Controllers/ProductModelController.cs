using AdventureWorksLt.Shared.Dtos;
using AdventureWorksLt.Shared.Dtos.ProductModel;
using AdventureWorksLt.Shared.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace AdventureWorksLt.Api.Controllers;

[Route("api/[controller]")]
public class ProductModelController : Base.BaseController
{
    private readonly IProductModelService _productModelService;

    public ProductModelController(ILogger logger, IProductModelService productModelService) : base(logger)
    {
        _productModelService = productModelService;
    }

    [HttpGet("")]
    public Task<IActionResult> GetProductModelsAsync() => 
        ResultAsync(_productModelService.GetProductModelsAsync());

    [HttpGet("{productModelId:int}")]
    public Task<IActionResult> GetProductModelDetailsAsync(int productModelId) => 
        ResultAsync(_productModelService.GetProductModelAsync(productModelId));

    [HttpPost("create")]
    public Task<IActionResult> CreateProductModelAsync(ProductModelDto requestDto) => 
        ResultAsync(_productModelService.CreateProductModelAsync(requestDto));

    [HttpPut("update/{productModelId:int}")]
    public Task<IActionResult> UpdateProductModelAsync(int productModelId, ProductModelDto requestDto) => 
        ResultAsync(_productModelService.UpdateProductModelAsync(productModelId, requestDto));

    [HttpDelete("delete/{productModelId:int}")]
    public Task<IActionResult> DeleteProductModelAsync(int productModelId) => 
        ResultAsync(_productModelService.DeleteProductModelAsync(productModelId));
}