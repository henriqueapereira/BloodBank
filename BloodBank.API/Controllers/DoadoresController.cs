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
            var doadores = await _doadorService.GetAll();
            return Ok(doadores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<DoadorViewModel>>> GetById(int id)
        {
            var doador = await _doadorService.GetById(id);
            return Ok(doador);
        }

        [HttpPost]
        public async Task<ActionResult<DoadorViewModel>> Post([FromBody] CreateDoadorInputModel model)
        {
            var novoDoador = await _doadorService.Insert(model);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateDoadorInputModel model)
        {
            await _doadorService.Update(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _doadorService.Delete(id);

            return Ok();
        }

        //public async Task<List<DoacaoViewModel>> GetHistoricoDoacoes(int doadorId)
        [HttpGet("{id}/listarDoacoes")]
        public async Task<ActionResult<List<DoacaoViewModel>>> GetHistoricoDoacoes(int id)
        {
            var lista = await _doadorService.GetHistoricoDoacoes(id);

            return Ok(lista);
        }
    }
}