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
using System.Linq;

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
            var price2 = _context.History.Where(x => x.ID == price_id).FirstOrDefault();
            if (price2 == null) return StatusCode(404);
            price2.Prize95 = price.Prize95;
            price2.Prize98 = price.Prize98;
            price2.PrizeDiesel = price.PrizeLPG;
            var station = _context.Station.Where(x => x.Id == price2.Station.Id).FirstOrDefault();
            if (station == null) return StatusCode(404);
            price2.Station = station;
            var fuel = _context.FuelAvaliability.Where(x => x.Id == price2.FuelAvaliabilityID.Id).FirstOrDefault();
            price2.FuelGrade = _context.FuelGrade.Where(x => x.Id == price2.FuelGrade.Id).FirstOrDefault();
            if (fuel == null) return StatusCode(404);
           price2.User = _context.User.Where(x => x.Id == price2.User.Id).FirstOrDefault();
            _context.History.Update(price2);
            return StatusCode(200);
            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Upload price of fuel in the station
        /// </summary>
        /// <remarks>Dodaje koszt paliwa na stacji</remarks>
        /// <param name="Station_ID"></param>
        /// <param name="User_ID"></param>
        /// <param name="price"></param>
        /// <response code="0">successful operation</response>
        [HttpPost]
        [Route("/{User_ID}/price/{Station_ID}")]
        public virtual IActionResult PostPrize([FromRoute][Required] int? Station_ID, [FromRoute][Required] int? User_ID, [FromBody] History price)
        {
            var user = _context.User.Where(x => x.Id == User_ID).FirstOrDefault();
            if (user!=null)
            {
                var station = _context.Station.Where(x => x.Id == Station_ID).FirstOrDefault();
                if (station == null) return StatusCode(404); 
                price.Station = station;
                price.User = user;
                _context.History.Add(price);
                _context.SaveChanges();
            }
            
            _context.SaveChanges();
            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(History));
            /*
                        string exampleJson = null;
                        exampleJson = "<History>\n  <Station_ID>123456789</Station_ID>\n  <User_ID>123456789</User_ID>\n  <Fuel_avaliability_ID>123456789</Fuel_avaliability_ID>\n  <Prize_95>8.0</Prize_95>\n  <Prize_98>8.0</Prize_98>\n  <Prize_LPG>8.0</Prize_LPG>\n  <Prize_Diesel>8.0</Prize_Diesel>\n  <Date>aeiou</Date>\n  <Fuel_grade_ID>123456789</Fuel_grade_ID>\n</History>";
                        exampleJson = "{\"empty\": false}";

                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<History>(exampleJson)
                        : default(History);*/
            //TODO: Change the data returned
            return StatusCode(500);
            //  return new ObjectResult(example);
        }

        /// <summary>
        /// Upload price of fuel in the station
        /// </summary>
        /// <remarks>Dodaje koszt paliwa na stacji</remarks>
        /// /// <param name="user_id"></param>
        /// <param name="station_id"></param>
        /// <response code="0">successful operation</response>
        [HttpDelete]
        [Route("/price/remove/{user_id}_{station_id}")]
        public virtual IActionResult RemovePrice([FromRoute][Required] int? user_id, [FromRoute][Required] int? station_id)
        {
            var price = _context.History.Where(x => x.User.Id == user_id && x.Station.Id == station_id).FirstOrDefault();
            if (price != null)
            {
                _context.History.Remove(price);
                _context.SaveChanges();
                return StatusCode(0);
            }
            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0);


            throw new NotImplementedException();
        }
    }
}
