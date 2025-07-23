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

        public DoadorService(BloodBankDbContext context)
        {
            _context = context;
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


        public async Task<Doador> Insert(CreateDoadorInputModel doador)
        {
            var entity = doador.ToEntity();
            _context.Doadores.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(int id, UpdateDoadorInputModel model)
        {
            var doador = await _context.Doadores.SingleOrDefaultAsync(d => d.Id == id);
            if (doador == null)
                throw new Exception("Doador não encontrado");

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
            var doador = await _context.Doadores.FindAsync(id);
            if (doador is not null)
            {
                _context.Doadores.Remove(doador);
                await _context.SaveChangesAsync();
            }
        }

        //public Task<Doador> Insert(CreateDoadorInputModel model)
        //{
        //throw new NotImplementedException();
        //}
    }

}