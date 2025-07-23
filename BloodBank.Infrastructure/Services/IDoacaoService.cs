using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Application.Models.Doador;

namespace BloodBank.Infrastructure.Services
{
    public interface IDoacaoService
    {
        Task<List<DoacaoViewModel>> GetAll();
        Task<DoacaoViewModel> Insert(CreateDoacaoInputModel inputModel);
    }
}