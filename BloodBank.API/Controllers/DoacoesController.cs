using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Application.Models.Doador;
using BloodBank.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoacoesController : ControllerBase
    {
        private readonly IDoacaoService _doacaoService;

        public DoacoesController(IDoacaoService doacaoService)
        {
            _doacaoService = doacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DoacaoViewModel>>> GetAll()
        {
            var doacoes = await _doacaoService.GetAll();
            return Ok(doacoes);
        }

        [HttpPost]
        public async Task<ActionResult<DoacaoViewModel>> Post([FromBody] CreateDoacaoInputModel inputModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doacao = await _doacaoService.Insert(inputModel);
            return CreatedAtAction(nameof(GetAll), new { id = doacao.Id }, doacao);
        }

    }
}