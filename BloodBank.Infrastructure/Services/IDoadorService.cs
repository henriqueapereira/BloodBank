using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Application.Models.Doador;
using BloodBank.Domain.Entities;

namespace BloodBank.Infrastructure.Services
{
    public interface IDoadorService
    {
        Task<List<DoadorViewModel>> GetAll();
        Task<DoadorViewModel?> GetById(int id);
        Task<Doador> Insert( CreateDoadorInputModel model);
        Task Update(int id, UpdateDoadorInputModel doador);
        Task Delete(int id);
    }
}