using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace AdventureWorksLt.Api.Controllers.Base;

[Route("api/[controller]")]
public abstract class BaseController : Controller
{
    private readonly ILogger _logger;
    private readonly string _controller;

    protected BaseController(ILogger logger)
    {
        _logger = logger;
        _controller = GetType().Name;
    }

    public async Task<IActionResult> ResultAsync<TResult>(Task<TResult> task, [CallerMemberName] string? caller = null)
    {
        var fullCaller = $"{_controller}.{caller}";
        
        try
        {
            var result = await task;
            
            _logger.Debug("Got result from {FullCaller}: {Result}", fullCaller, result);

            return Ok(result);
        }
        catch (Exception exception)
        {
            _logger.Fatal(exception, "An error occured while running {FullCaller}", fullCaller);
            throw;
        }
    }
}