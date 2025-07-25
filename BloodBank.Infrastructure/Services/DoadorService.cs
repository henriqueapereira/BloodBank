using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Application.Models.Doador;
using BloodBank.Domain.Entities;
using BloodBank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Services
{
    public class DoadorService : IDoadorService
    {
        private readonly BloodBankDbContext _context;
        private readonly ViaCepService _viaCepService;

        public DoadorService(BloodBankDbContext context, ViaCepService viaCepService)
        {
            _context = context;
            _viaCepService = viaCepService;
        }

        public async Task<List<DoadorViewModel>> GetAll()
        {
            var doadores = await _context.Doadores.Include(d => d.Endereco).Include(d => d.Doacoes).ToListAsync(); ;

            var model = doadores.Select(DoadorViewModel.FromEntity).ToList();
            return (model);
        }

        public async Task<DoadorViewModel?> GetById(int id)
        {
            var doador = await _context.Doadores
                .Include(d => d.Endereco)
                .Include(d => d.Doacoes)
                .SingleOrDefaultAsync(d => d.Id == id);

            var model = DoadorViewModel.FromEntity(doador);

            return (model);
        }


        public async Task<DoadorViewModel> Insert(CreateDoadorInputModel doador)
        {
            // Buscar o endereço pela API usando o CEP informado
            var enderecoApi = await _viaCepService.BuscarEnderecoPorCep(doador.Endereco.CEP);

            if (enderecoApi == null || string.IsNullOrEmpty(enderecoApi.Logradouro))
                throw new Exception("Endereço não encontrado para o CEP informado.");

            // Preencher os dados faltantes
            doador.Endereco.Logradouro = enderecoApi.Logradouro;
            doador.Endereco.Cidade = enderecoApi.Localidade;
            doador.Endereco.Estado = enderecoApi.Uf;
            

            var entity = doador.ToEntity();
            _context.Doadores.Add(entity);
            await _context.SaveChangesAsync();
            return DoadorViewModel.FromEntity(entity);
        }

        public async Task Update(int id, UpdateDoadorInputModel model)
        {
            var doador = await _context.Doadores.SingleOrDefaultAsync(d => d.Id == id) ?? throw new Exception("Doador não encontrado");

            var endereco = model.Endereco?.ToEntity();

            doador.Update(model.NomeCompleto, model.Email, model.DataNascimento, model.Genero, model.Peso, model.TipoSanguineo, model.FatorRh);
            if (doador.Endereco is not null && model.Endereco is not null)
            {
                doador.Endereco.Update(model.Endereco.Logradouro, model.Endereco.Cidade, model.Endereco.Estado, model.Endereco.CEP);
            }
            _context.Doadores.Update(doador);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var doador = await _context.Doadores.SingleOrDefaultAsync(d => d.Id == id);
            if (doador is not null)
            {
                _context.Doadores.Remove(doador);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DoacaoViewModel>> GetHistoricoDoacoes(int doadorId)
        {
            var doacoes = await _context.Doacoes
                .Where(d => d.DoadorId == doadorId)
                .OrderByDescending(d => d.DataDoacao)
                .ToListAsync();

            return DoacaoViewModel.FromEntity(doacoes);
        }
    }
}