using AdventureWorksLt.Shared.Dtos;
using AdventureWorksLt.Shared.Dtos.ProductDescription;
using AdventureWorksLt.Shared.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace AdventureWorksLt.Api.Controllers;

[Route("api/[controller]")]
public class ProductDescriptionController : Base.BaseController
{
    private readonly IProductDescriptionService _productDescriptionService;

    public ProductDescriptionController(ILogger logger, IProductDescriptionService productDescriptionService) : base(logger)
    {
        _productDescriptionService = productDescriptionService;
    }

    [HttpGet("")]
    public Task<IActionResult> GetProductDescriptionsAsync() => 
        ResultAsync(_productDescriptionService.GetProductDescriptionsAsync());

    [HttpGet("{productDescriptionId:int}")]
    public Task<IActionResult> GetProductDescriptionDetailsAsync(int productDescriptionId) => 
        ResultAsync(_productDescriptionService.GetProductDescriptionAsync(productDescriptionId));

    [HttpPost("create")]
    public Task<IActionResult> CreateProductDescriptionAsync(ProductDescriptionDto requestDto) => 
        ResultAsync(_productDescriptionService.CreateProductDescriptionAsync(requestDto));

    [HttpPut("update/{productDescriptionId:int}")]
    public Task<IActionResult> UpdateProductDescriptionAsync(int productDescriptionId, ProductDescriptionDto requestDto) => 
        ResultAsync(_productDescriptionService.UpdateProductDescriptionAsync(productDescriptionId, requestDto));

    [HttpDelete("delete/{productDescriptionId:int}")]
    public Task<IActionResult> DeleteProductDescriptionAsync(int productDescriptionId) => 
        ResultAsync(_productDescriptionService.DeleteProductDescriptionAsync(productDescriptionId));
}