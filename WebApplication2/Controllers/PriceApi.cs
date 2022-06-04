/*
 * Aplikacja
 *
 * Społecznościowy system informowania o cenach paliw. 
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using WebApplication2.Models;
using WebApplication2.Data;

namespace IO.Swagger.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly WebApplication2Context _context;

        public PriceController(WebApplication2Context context)
        {
            _context = context;
        }
        /// <summary>
        /// Upload price of fuel in the station
        /// </summary>
        /// <remarks>Dodaje koszt paliwa na stacji</remarks>
        /// <param name="price_id"></param>
        /// <param name="price"></param>
        /// <response code="0">successful operation</response>
        [HttpPut]
        [Route("/price/edit/{price_id}")]
        public virtual IActionResult EditPrice([FromRoute][Required] int? price_id, [FromBody] History price)
        {  
            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Upload price of fuel in the station
        /// </summary>
        /// <remarks>Dodaje koszt paliwa na stacji</remarks>
        /// <param name="Fuel_price_ID"></param>
        /// <param name="User_ID"></param>
        /// <param name="prize"></param>
        /// <response code="0">successful operation</response>
        [HttpPost]
        [Route("/{User_ID}/price/{Fuel_price_ID}")]
        public virtual IActionResult PostPrize([FromRoute][Required] int? Fuel_price_ID, [FromRoute][Required] int? User_ID, [FromBody] History prize)
        {
            //TODO NAPRAWIC
            _context.History.Add(prize);
           // _context.SaveChanges();
            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(History));

            string exampleJson = null;
            exampleJson = "<History>\n  <Station_ID>123456789</Station_ID>\n  <User_ID>123456789</User_ID>\n  <Fuel_avaliability_ID>123456789</Fuel_avaliability_ID>\n  <Prize_95>8.0</Prize_95>\n  <Prize_98>8.0</Prize_98>\n  <Prize_LPG>8.0</Prize_LPG>\n  <Prize_Diesel>8.0</Prize_Diesel>\n  <Date>aeiou</Date>\n  <Fuel_grade_ID>123456789</Fuel_grade_ID>\n</History>";
            exampleJson = "{\"empty\": false}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<History>(exampleJson)
            : default(History);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Upload price of fuel in the station
        /// </summary>
        /// <remarks>Dodaje koszt paliwa na stacji</remarks>
        /// <param name="price_id"></param>
        /// <response code="0">successful operation</response>
        [HttpDelete]
        [Route("/price/remove/{price_id}")]
        public virtual IActionResult RemovePrice([FromRoute][Required] int? price_id)
        {
            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0);


            throw new NotImplementedException();
        }
    }
}
