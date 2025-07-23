using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Application.Models.Doador
{
    public class UpdateDoadorInputModel
    {
        

        public string NomeCompleto { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; } = null!;
        public double Peso { get; set; }
        public string TipoSanguineo { get; set; } = null!;
        public string FatorRh { get; set; } = null!;

        public EnderecoInputModel? Endereco { get; set; }
    }
}