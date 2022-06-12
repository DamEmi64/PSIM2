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

using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;
using IO.Swagger.Security;
using Microsoft.AspNetCore.Authorization;

using WebApplication2.Models;
using WebApplication2.Data;
using System.Linq;

namespace WebApplication2.Controllers
{ 
    
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly WebApplication2Context _context;

        public StationController(WebApplication2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a new gas Station to the database
        /// </summary>
        /// <remarks>Dodanie obiektu stacja</remarks>
        /// <param name="body">Station object that needs to be added to the store</param>
        /// <response code="200">Operation successful</response>
        /// <response code="401">Not authenticated</response>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/Station/new")]
        public virtual IActionResult AddStation([FromBody] Station body)
        {
            body.Id = null;
            _context.Station.Add(body);
            _context.SaveChanges();

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
             return StatusCode(200);

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401);

            //TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(405);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit gas Station to the database
        /// </summary>
        /// <remarks>Modyfikacja obiektu stacja</remarks>
        /// <param name="id">Station object id</param>
        /// <param name="body">Station object that needs to be edited to the store</param>
        /// <response code="200">Operation successful</response>
        /// <response code="401">Not authenticated</response>
        /// <response code="405">Invalid input</response>
        [HttpPut]
        [Route("/Station/edit/{id}")]
        public virtual IActionResult EditStation([FromRoute][Required] int? id, [FromBody] Station body)
        {    
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401);

            //TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(405);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a new gas Station to the database
        /// </summary>
        /// <remarks>Dodanie obiektu stacja</remarks>
        /// <param name="id">Station object id</param>
        /// <response code="200">Operation successful</response>
        /// <response code="401">Not authenticated</response>
        /// <response code="405">Invalid input</response>
        [HttpDelete]
        [Route("/Station/remove/{id}")]
        public virtual IActionResult RemoveStation([FromRoute][Required] int? id)
        {
            var station = _context.Station.Where(x => x.Id == id).FirstOrDefault();
            if (station!=null)
            {
                _context.Station.Remove(station);
                _context.SaveChanges();
                return StatusCode(200);
            }
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401);

            //TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(405);


            throw new NotImplementedException();
        }

        /// <summary>
        /// show commentary about station
        /// </summary>

        /// <param name="stationID">id stacji</param>
        /// <response code="200">Succesfull operation</response>
        /// <response code="401">Not authenticated</response>
        /// <response code="405">Invalid input</response>
        [HttpGet]
        [Route("/Station/com/{stationID}")]
        public virtual IActionResult ShowComments([Required] int? stationID)
        {
            var comments = _context.Comment.Where(x => x.Station.Id == stationID).ToList();

            if (comments != null)
            {
                return Ok(comments);
            }
            //TODO: Change the data returned
            throw new NotImplementedException();

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Comment));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401);

            //TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(405);
        }

        /// <summary>
        /// get info about station
        /// </summary>

        /// <param name="id">id stacji</param>
        /// <response code="0">Info about station</response>
        /// <response code="405">Invalid input</response>
        [HttpGet]
        [Route("/Station/info/{id}")]
        public virtual IActionResult ShowStationinfo([FromRoute][Required] int? id)
        {
            var station = _context.Station.Where(x => x.Id == id).FirstOrDefault();
            if (station == null) return StatusCode(405);
            return StatusCode(0, station);
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Station));

            //TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(405);

/*            string exampleJson = null;
            exampleJson = "<Station>\n  <id>123456789</id>\n  <Name>Orlen</Name>\n  <Open_hours>8:00 22:00</Open_hours>\n  <Location>93.12421 65.12652</Location>\n  <Adres_ID>12</Adres_ID>\n  <Grade>12</Grade>\n</Station>";
            exampleJson = "{\"empty\": false}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Station>(exampleJson)
            : default(Station);*/
            //TODO: Change the data returned
           // return new ObjectResult(example);
        }

        /// <summary>
        /// show nearest Station
        /// </summary>
        /// <remarks>Uzyskanie info o najbliższej stacji</remarks>
        /// <param name="userStreet">Pola użytkownika z nowymi wartościami</param>
        /// <response code="200">Info about station</response>
        /// <response code="403">Not Found</response>
        [HttpGet]
        [Route("/Station/near")]
        public virtual IActionResult ShownearStation(String userStreet)
        {
            var stations = _context.Station.Where(x => userStreet.Contains(x.Address.Street)).ToList();

            if (stations != null)
            {
                return Ok(stations);
            }
            //TODO: Change the data returned
            throw new NotImplementedException();
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Station));

            //TODO: Uncomment the next line to return response 403 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(403);

            //TODO: Change the data returned

        }
    }
}
