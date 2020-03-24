using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemiyNLayerProject.Core.Models;
using UdemiyNLayerProject.Core.Services;

namespace UdemiyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personelservis;

        public PersonsController(IService<Person> service)
        {
            _personelservis = service;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var persons = await _personelservis.GetAllAsync();
            return Ok(persons);
        }


        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
           var newperson= await _personelservis.AddAsync(person);
            return Ok(newperson);
        }


        [HttpPut]

        public IActionResult Update(Person person)
        {
            var newperson =  _personelservis.Update(person);
            return NoContent();
        }


    }
}