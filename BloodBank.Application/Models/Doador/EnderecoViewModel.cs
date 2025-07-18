using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Application.Models.Doador
{
    public class EnderecoViewModel
    {
        public string Logradouro { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string CEP { get; set; } = null!;

        public static EnderecoViewModel FromEntity(Domain.Entities.Endereco endereco)
        {
            return new EnderecoViewModel
            {
                Logradouro = endereco.Logradouro,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
                CEP = endereco.CEP
            };
        }
    }
}