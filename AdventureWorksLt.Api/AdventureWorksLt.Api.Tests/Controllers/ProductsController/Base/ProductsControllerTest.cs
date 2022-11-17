using System.Net.Http;
using AdventureWorksLt.Shared.Interfaces.Services;
using Moq;
using NUnit.Framework;
using Serilog;

namespace AdventureWorksLt.Api.Tests.Controllers.ProductsController.Base;

public abstract class ProductsControllerTest
{
    private readonly MockRepository _mockRepository = new(MockBehavior.Loose);
    
    protected Mock<ILogger> MockLogger = null!;
    protected Mock<IProductService> MockProductService = null!;

    [SetUp]
    public virtual void Setup()
    {
        MockLogger = _mockRepository.Create<ILogger>();
        MockProductService = _mockRepository.Create<IProductService>();
    }

    protected Api.Controllers.ProductsController CreateController()
    {
        return new Api.Controllers.ProductsController(MockLogger.Object, MockProductService.Object);
    }
}