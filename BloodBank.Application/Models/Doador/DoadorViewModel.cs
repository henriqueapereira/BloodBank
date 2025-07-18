using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Application.Models.Doador
{
    public class DoadorViewModel
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; } = null!;
        public double Peso { get; set; }
        public string TipoSanguineo { get; set; } = null!;
        public string FatorRh { get; set; } = null!;
        public EnderecoViewModel? Endereco { get; set; }
        public static DoadorViewModel FromEntity(Domain.Entities.Doador doador)
        {
            return new DoadorViewModel
            {
                Id = doador.Id,
                NomeCompleto = doador.NomeCompleto,
                Email = doador.Email,
                DataNascimento = doador.DataNascimento,
                Genero = doador.Genero,
                Peso = doador.Peso,
                TipoSanguineo = doador.TipoSanguineo,
                FatorRh = doador.FatorRh,
                Endereco = doador.Endereco is not null
                    ? EnderecoViewModel.FromEntity(doador.Endereco)
                    : null
            };
        }
    }
}