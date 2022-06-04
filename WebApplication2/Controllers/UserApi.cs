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

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly WebApplication2Context _context;

        public UserApiController(WebApplication2Context context)
        {
            _context = context;
        }
        /// <summary>
        /// Create User
        /// </summary>
        /// <remarks>Tworzy użytkownika</remarks>
        /// <param name="uytkownik">Tworzy użytkownicy</param>
        /// <response code="0">successful operation</response>
        [HttpPost]
        [Route("/register")]
        [ValidateModelState]
        public virtual IActionResult CreateUser([FromBody]User uytkownik)
        {
            if (ModelState.IsValid)
            {
                uytkownik.Id = null;
                _context.Add(uytkownik);
                _context.SaveChanges();
                return StatusCode(200);
            }
            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete User info
        /// </summary>
        /// <remarks>Usuwa info o użytkowniku.</remarks>
        /// <param name="userID">ID użytkownika do usunięcia</param>
        /// <param name="token">Token zalogowanego użytkownika</param>
        /// <response code="401">Not authenticated</response>
        /// <response code="0">successful operation</response>
        [HttpDelete]
        [Route("/User/remove/{User_ID}")]
        [ValidateModelState]
        public virtual IActionResult Delinfo([FromRoute][Required]int? userID, [FromHeader][Required()]string token)
        { 
            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401);

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit user info
        /// </summary>
        /// <remarks>Zedytuj niektóre dane o użytkowniku.</remarks>
        /// <param name="userIDEdit">ID użytkownika do edycji</param>
        /// <param name="token">Token zalogowanego użytkownika proszącego o dane</param>
        /// <param name="userChange">Pola użytkownika z nowymi wartościami</param>
        /// <response code="401">Not authenticated</response>
        /// <response code="0">successful operation</response>
        [HttpPut]
        [Route("/User/edit/{User_ID_edit}")]
        [ValidateModelState]
        public virtual IActionResult Editinfo([FromRoute][Required]int? userIDEdit, [FromHeader][Required()]string token, [FromBody]UserChange userChange)
        { 
            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401);

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Show User info
        /// </summary>
        /// <remarks>Pokazuje info o użytkowniku.</remarks>
        /// <param name="userID">ID użytkownika do wyświetlenia</param>
        /// <param name="token">Token zalogowanego użytkownika proszącego o dane</param>
        /// <response code="401">Not authenticated</response>
        /// <response code="0">successful operation</response>
        [HttpGet]
        [Route("/User/{User_ID}")]
        [ValidateModelState]
        public virtual IActionResult Showinfo([FromRoute][Required]int? userID, [FromHeader][Required()]string token)
        { 
            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401);

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0);


            throw new NotImplementedException();
        }
    }
}