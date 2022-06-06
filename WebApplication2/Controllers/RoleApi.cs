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
    public class RoleController : ControllerBase
    {
        private readonly WebApplication2Context _context;

        public RoleController(WebApplication2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a new tag
        /// </summary>
        /// <remarks>Dodanie nowego tagu</remarks>
        /// <param name="body">Tag object that needs to be added to the station description</param>
        /// <response code="200">Operation successful</response>
        /// <response code="401">Not authenticated</response>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/Role/new")]
        public virtual IActionResult AddTag([FromBody] Role body)
        {
            body.Id = null;
            _context.Role.Add(body);
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
        /// Edit tag
        /// </summary>
        /// <remarks>Modyfikacja obiektu Tag</remarks>
        /// <param name="body">Tag that needs to be added to the station description</param>
        /// <param name="id">Tag id</param>
        /// <response code="200">Operation successful</response>
        /// <response code="401">Not authenticated</response>
        /// <response code="405">Invalid input</response>
        [HttpPut]
        [Route("/Role/edit/{id}")]
        public virtual IActionResult EditTag([FromBody] Role body, [FromRoute][Required] long? id)
        {
            var role = _context.Role.Where(x => x.Id == id).FirstOrDefault();
            if (role != null) {
                
                role.IsAdmin = body.IsAdmin;
                role.Range = body.Range;
                role.Bonuses = body.Bonuses;
                _context.Role.Update(role);
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
        /// Remove tag
        /// </summary>
        /// <remarks>Usunięcie tagu</remarks>
        /// <param name="id">Tag id</param>
        /// <response code="200">Operation successful</response>
        /// <response code="401">Not authenticated</response>
        /// <response code="405">Invalid input</response>
        [HttpDelete]
        [Route("/Role/remove/{id}")]
        public virtual IActionResult RemoveTag([FromRoute][Required] long? id)
        {
            var tag = _context.Role.Where(x => x.Id == id).FirstOrDefault();
            if (tag!=null)
            {
                _context.Role.Remove(tag);
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
    }
}
