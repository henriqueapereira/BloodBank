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
            return doacoes.Select(DoacaoViewModel.FromEntity).ToList();
        }

        public async Task<DoacaoViewModel> Insert(CreateDoacaoInputModel inputModel)
        {
            var doacao = new Doacao
            {
                DoadorId = inputModel.DoadorId,
                DataDoacao = inputModel.DataDoacao,
                QuantidadeML = inputModel.QuantidadeML
            };

            _context.Doacoes.Add(doacao);
            await _context.SaveChangesAsync();

            return DoacaoViewModel.FromEntity(doacao);
        }
    }
}