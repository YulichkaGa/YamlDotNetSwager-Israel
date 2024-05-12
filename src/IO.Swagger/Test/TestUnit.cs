using System;
using Xunit;

using IO.Swagger.Controllers;
using IO.Swagger.Models;
using Microsoft.AspNetCore.Mvc; // Replace 'MyApi' with the namespace of your actual API

public class CalculatorTests
{
    private readonly CalculatorController _controller;
    ///<Summary>
    /// TEst file
    ///</Summary>
    ///

    public CalculatorTests()
    {
        _controller = new CalculatorController(); // Assuming no dependencies
    }
    ///<Summary>
    /// TEst CalculateValidOperation
    ///</Summary>
    ///
    [Theory]
    [InlineData("add", 1, 2, 3)]
    [InlineData("subtract", 5, 3, 2)]
    [InlineData("multiply", 4, 5, 20)]
    [InlineData("divide", 8, 2, 4)]

    public void CalculateValidOperation(string operation, double num1, double num2, double expectedResult)
    {
        var result = _controller.Calculate(operation, new Calculator { number1 = num1, number2 = num2 }) as OkObjectResult;

        Assert.NotNull(result);
        var actualResult = Assert.IsType<double>(result.Value);
        Assert.Equal(expectedResult, actualResult);
    }
    ///<Summary>
    /// TEst Calculate_DivideByZero_ReturnsBadRequest
    ///</Summary>
    ///

    [Fact]
    public void Calculate_DivideByZero_ReturnsBadRequest()
    {
        var result = _controller.Calculate("divide", new Calculator { number1= 10, number2 = 0 });

        Assert.IsType<BadRequestObjectResult>(result);
    }
}