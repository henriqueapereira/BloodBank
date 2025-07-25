using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Application.Models.Doador
{
    public class ViaCepResponseModel
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Localidade { get; set; } // Cidade
        public string Uf { get; set; }         // Estado
    }
}