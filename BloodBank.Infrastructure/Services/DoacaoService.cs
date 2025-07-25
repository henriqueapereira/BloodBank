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
    public class DoacaoService : IDoacaoService
    {
        private readonly BloodBankDbContext _context;

        public DoacaoService(BloodBankDbContext context)
        {
            _context = context;
        }

        public async Task<List<DoacaoViewModel>> GetAll()
        {
            var doacoes = await _context.Doacoes.ToListAsync();
            return DoacaoViewModel.FromEntity(doacoes);
        }


        public async Task<DoacaoViewModel> Insert(CreateDoacaoInputModel model)
        {
            var doacao = model.ToEntity();

            _context.Doacoes.Add(doacao);
            await _context.SaveChangesAsync();

            return DoacaoViewModel.FromEntity(doacao);
        }

        
    }
}