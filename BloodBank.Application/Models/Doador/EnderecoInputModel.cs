using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Domain.Entities;

namespace BloodBank.Application.Models.Doador
{
    public class EnderecoInputModel
    {
        public string Logradouro { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string CEP { get; set; } = null!;

        public Endereco ToEntity()
        {
            return new Endereco
            {
                Logradouro = Logradouro,
                Cidade = Cidade,
                Estado = Estado,
                CEP = CEP
            };
        }
    }
}