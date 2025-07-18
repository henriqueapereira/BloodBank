using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Application.Models.Doador;
using BloodBank.Domain.Entities;
using BloodBank.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoadoresController : ControllerBase
    {
        private readonly IDoadorService _doadorService;

        public DoadoresController(IDoadorService doadorService)
        {
            _doadorService = doadorService;
        }


        [HttpGet]
        public async Task<ActionResult<List<DoadorViewModel>>> GettAll()
        {
            var doadores = await _doadorService.ObterTodosAsync();
            return Ok(doadores);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateDoadorInputModel model)
        {
            var novoDoador = await _doadorService.CriarAsync(model.ToEntity());   
            return Ok();
        }
    }
}