using System;
using System.Collections.Generic;
using System.Linq;
using DotNetCoreWebAPI.Context;
using DotNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;


/**
 * This is a .NET CORE web API example coded by Md Mamunur Rahman 
 * 
 * @FileName: PersonController.cs
 * @Author Md Mamunur Rahman
 * @Phone: 6474473215
 * @website: http://mamun-portfolio.azurewebsites.net/Default.aspx
 * @Last Update 19-July-2019
 * @description: this file is Controller clss file for the Web Api Example
 */


namespace DotNetCoreWebAPI.Controllers
{
    /**  
    * <summary>  
    * This is the PersonController class for controlling CRUD operation with database.  
    * </summary>  
    * @class PersonController  
    */

    [Route("api/")]
    [ApiController]
    public class PersonController : Controller
    {
        //PRIVATE INSTANCE VARIABLE++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private ILogger _log;
        private ApplicationDbContext _context;


        //CONSTRUCTOR++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
        * <summary>
        * This is the Constructor for initialiging the private variables
        * </summary>
        * @Constructor PersonController
        * @param {object ApplicationDbContext} context
        * @param {object ILoggerFactory} loggerFactory
        */
        public PersonController(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _log = loggerFactory.CreateLogger<PersonController>();
        }


        //PUBLIC METHODES++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
        * <summary>
        * This is the public method for making query for all persons
        * </summary>
        * @method GetAllPernsons
        * @returns {IEnumerable<Person>} 
        */
        [HttpGet("GetAllPernsons")]
        public IEnumerable<Person> GetAllPernsons()
        {
            if(_context.Persons == null)  _log.LogError("****Database is empty****");
            return _context.Persons;
        }
        /**
        * <summary>
        * This is the public method for making query for persons by id.
        * </summary>
        * @method GetPernsonByID
        * @returns {ActionResult<Person>} 
        * @param {string} id
        */
        [HttpGet("GetPernsonByID/{id}")] 
        public ActionResult<Person> GetPernsonByID(string id)
        {
            var findPerson =  _context.Persons.Find(id);
            if (findPerson == null)
            {
                _log.LogError("****Id does not match with any existing Person's Id****");
                return BadRequest();
            }

            else
            {
                _log.LogInformation("****Id has been found****");
                return Ok(findPerson);
            }
           
        }
        /**
        * <summary>
        * This is the public method for adding new data.
        * </summary>
        * @method AddPersion
        * @returns {ActionResult<Person>} 
        * @param {object Person} person
        */
        [HttpPost("AddPersion")]
        public ActionResult<Person> AddPersion(Person person)
        {
             if (_context.Persons.Find(person.Id) == null )
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
                _log.LogInformation("****Data has been added****");
                return Ok(person);
            }
            else
            {
                _log.LogError("****Id matches with an existing Person's Id****");
                return BadRequest();
            }
        }
        /**
        * <summary>
        * This is the public method for updating existing data.
        * </summary>
        * @method UpdatePersonByID
        * @returns {ActionResult} 
        * @param {object Person} person
        * @param {string} id
        */
        [HttpPut("UpdatePersonByID/{id}")] 
        public ActionResult UpdatePersonByID(string id, [FromBody]Person person)
        {
            if (person == null || person.Id != id)
            {
                _log.LogError("****Entry for update is null****");
                return BadRequest();
            }
        
            var findPerson = _context.Persons.FirstOrDefault(i => i.Id == id);
            if (findPerson == null)
            {
                _log.LogError("****Id does not match with any existing Person's Id****");
                return NotFound();
            }
                
            findPerson.Name = person.Name;

            _context.Persons.Update(findPerson);
            _context.SaveChanges();
            _log.LogInformation("****Data has been updated****");
            return new NoContentResult();
        }
        /**
        * <summary>
        * This is the public method for deleting existing data.
        * </summary>
        * @method DeletePersonspByID
        * @returns {ActionResult} 
        * @param {string} id
        */
        [HttpDelete("DeletePersonByID/{id}")]
        public ActionResult DeletePersonspByID(string id)
        {
            var deletePerson = _context.Persons.Find(id);
            if (deletePerson == null)
            {
                _log.LogError("****Id does not match with any existing Person's Id****");
                return BadRequest();
            }
            else
            {
                _context.Persons.Remove(deletePerson);
                _context.SaveChanges();
                _log.LogInformation("****Data has been deleted****");
                return new NoContentResult();
            }


        }
    }
}