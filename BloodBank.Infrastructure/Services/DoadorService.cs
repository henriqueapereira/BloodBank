using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<Doador>> ObterTodosAsync()
        {
            return await _context.Doadores.Include(d => d.Endereco).Include(d => d.Doacoes).ToListAsync();
        }

        public async Task<Doador?> ObterPorIdAsync(int id)
        {
            return await _context.Doadores.Include(d => d.Endereco).Include(d => d.Doacoes)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Doador> CriarAsync(Doador doador)
        {
            _context.Doadores.Add(doador);
            await _context.SaveChangesAsync();
            return doador;
        }

        public async Task AtualizarAsync(Doador doador)
        {
            _context.Doadores.Update(doador);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var doador = await _context.Doadores.FindAsync(id);
            if (doador is not null)
            {
                _context.Doadores.Remove(doador);
                await _context.SaveChangesAsync();
            }
        }
    }

}