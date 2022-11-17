using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorksLt.Shared.Dtos.Product;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace AdventureWorksLt.Api.Tests.Controllers.ProductsController;

[TestFixture]
public class GetProductsAsyncTests : Base.ProductsControllerTest
{
    [Test]
    public void WhenAnInternalErrorOccurs_ReturnAnErrorCodeOf500()
    {
        // arrange
        MockProductService
            .Setup(service => service.GetProductsAsync())
            .ThrowsAsync(new Exception("Something went wrong"));
        
        var controller = CreateController();

        // act
        var getProductsTask = controller.GetProductsAsync();

        // assert
        Assert.ThrowsAsync<Exception>(async () => await getProductsTask);
    }
    
    [Test]
    public async Task WhenNoResultsExist_ReturnAnOkResult()
    {
        // arrange
        MockProductService
            .Setup(service => service.GetProductsAsync())
            .ReturnsAsync(Array.Empty<ProductDto>());
        
        var controller = CreateController();

        // act
        var result = await controller.GetProductsAsync();

        // assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }
    
    [Test]
    public async Task WhenNoResultsExist_ReturnAnEmptyEnumerable()
    {
        // arrange
        MockProductService
            .Setup(service => service.GetProductsAsync())
            .ReturnsAsync(Array.Empty<ProductDto>());
        
        var controller = CreateController();

        // act
        var result = await controller.GetProductsAsync();
        var okResult = result as OkObjectResult;

        // assert
        Assert.Multiple(() =>
        {
            Assert.NotNull(okResult);
            Assert.IsTrue(okResult.Value is ProductDto[]);
            Assert.IsEmpty((ProductTableDto[]) okResult.Value);
        });
    }
    
    [Test]
    public async Task WhenResultsExist_ReturnProductsInDto()
    {
        // arrange
        MockProductService
            .Setup(service => service.GetProductsAsync())
            .ReturnsAsync(GetProducts());
        
        var controller = CreateController();

        // act
        var result = await controller.GetProductsAsync();
        var okResult = result as OkObjectResult;
        var products = okResult?.Value as IEnumerable<ProductDto>;

        // assert
        Assert.Multiple(() =>
        {
            Assert.NotNull(products);
            Assert.That(products.ElementAt(0).Id, Is.EqualTo(1));
            Assert.That(products.ElementAt(0).Name, Is.EqualTo("Test 1"));
            Assert.That(products.ElementAt(1).Id, Is.EqualTo(2));
            Assert.That(products.ElementAt(1).Name, Is.EqualTo("Test 2"));
        });
    }

    private ProductDto[] GetProducts() => new[]
    {
        new ProductDto { Id = 1, Name = "Test 1"},
        new ProductDto { Id = 2, Name = "Test 2"},
    };
}