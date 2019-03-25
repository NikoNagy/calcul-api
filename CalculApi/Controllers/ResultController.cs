using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CalculApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get([FromBody]JObject expression)
        {
            // if sending empty object return BadRequest
            if (!expression.HasValues)
            {
                return BadRequest(new { message = "The body should not be empty" });
            }

            // Retrieve expression parameter from body
            string nonParsedValue = expression.GetValue("expression").ToObject<string>();

            // If expression in body is empty return BadRequest with approriate error message
            if (nonParsedValue.Length == 0)
            {
                return BadRequest(new { message = "The expression should not be empty" });
            }

            int result = 0;

            try
            {
                int[] valuesToAdd = Array.ConvertAll(nonParsedValue.Split('+'), int.Parse);
                result = valuesToAdd.Aggregate(0, (acc, next) => acc += next);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "The expression should only contains integers separated by plus signs (+)" });
            }


            return Ok(new { result = result });
        }

    }

}
