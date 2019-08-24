using System;
using AutoMapper;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Service.Validators;

namespace CurupiraCarAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApoliceSeguroController : Controller
    {
        private readonly IApoliceSeguroService _service;
        public ApoliceSeguroController(IApoliceSeguroService apoliceSeguroService)
        {
            _service = apoliceSeguroService;
            
        }
        // GET: api/ApoliceSeguro
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(_service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        // GET: api/ApoliceSeguro/5
        [HttpGet("{numeroApolice}", Name = "Get")]
        public IActionResult Get(double numeroApolice)
        {
            try
            {
                return new ObjectResult(_service.GetByNumeroApolice(numeroApolice));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/ApoliceSeguro
        [HttpPost]
        public IActionResult Post([FromBody] ApoliceSeguro apolice)
        {
            try
            {
                return new ObjectResult(_service.Post<ApoliceSeguroValidator>(apolice));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // PUT: api/ApoliceSeguro/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ApoliceSeguro apolice)
        {
            try
            {
                return new ObjectResult(_service.Put<ApoliceSeguroValidator>(apolice));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/ApoliceSeguro/5
        [HttpDelete("{numeroApolice}")]
        public IActionResult Delete(double numeroApolice)
        {
            try
            {
                return new ObjectResult(_service.RemoveByNumeroApolice(numeroApolice));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
