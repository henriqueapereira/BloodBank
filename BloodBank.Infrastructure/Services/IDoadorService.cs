using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Domain.Entities;

namespace BloodBank.Infrastructure.Services
{
    public interface IDoadorService
    {
        Task<List<Doador>> ObterTodosAsync();
        Task<Doador?> ObterPorIdAsync(int id);
        Task<Doador> CriarAsync(Doador doador);
        Task AtualizarAsync(Doador doador);
        Task DeletarAsync(int id);
    }
}