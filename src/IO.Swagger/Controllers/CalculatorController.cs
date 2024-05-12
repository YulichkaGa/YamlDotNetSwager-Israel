using IO.Swagger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace IO.Swagger.Controllers
{
    ///<Summary>
    /// Api
    ///</Summary>
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        Calculator data;

        ///<Summary>
        /// CAlculator 
        ///</Summary>
        private static double resolte = 1;

        /// <summary>
        /// get for test 
        /// </summary>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(resolte);
        }
        /// <summary>
        /// Performs arithmetic operations on two numbers.
        /// </summary>
        /// <param name="operation">The operation to perform ('add', 'subtract', 'multiply', 'divide').</param>
        ///// <param name="model">An object containing two numerical operands.</param>
        /// <returns>The result of the arithmetic operation.</returns>
        [HttpPost]
        public ActionResult Calculate([FromHeader] string operation, [FromBody] Calculator data)
        {
            try
            {
                switch (operation)
                {
                    case "add":
                        resolte = data.number1 + data.number2;
                        break;
                    case "subtract":

                        resolte = CompareAndSubtract(data.number1, data.number2);
                        break;
                    case "multiply":
                        resolte = data.number1 * data.number2;
                        break;
                    case "divide":
                        resolte = CompareAndDivide(data.number1, data.number2);
                        break;
                    default:
                        resolte = 0.0;
                        break;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.ToString());
            }
            return Ok(resolte);
        }
        static double CompareAndDivide(double num1, double num2)
        {
            if (num1 > num2)
            {
                return num1 /num2;
            }
            else if (num2 > num1)
            {
                return num2 / num1;
            }
            else
            {
                return 0;
            }
        }
    static double CompareAndSubtract(double num1, double num2)
        {
            if (num1 > num2)
            {
                return num1 - num2;
            }
            else if (num2 > num1)
            {
                return num2 - num1;
            }
            else
            {
                return 0;
            }
        }
    }
}
