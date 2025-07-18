using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Application.Models.Doador
{
    public class CreateDoadorInputModel
    {
        [Required, MaxLength(100)]
        public string NomeCompleto { get; set; } = null!;

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Genero { get; set; } = null!;

        [Required, Range(0, 300)]
        public double Peso { get; set; }

        [Required]
        public string TipoSanguineo { get; set; } = null!;

        [Required]
        public string FatorRh { get; set; } = null!;
        public EnderecoInputModel Endereco { get; set; } = null!;

        public BloodBank.Domain.Entities.Doador ToEntity()
        {
            return new BloodBank.Domain.Entities.Doador(
                nomeCompleto: NomeCompleto,
                email: Email,
                dataNascimento: DataNascimento,
                genero: Genero,
                peso: Peso,
                tipoSanguineo: TipoSanguineo,
                fatorRh: FatorRh,
                endereco: Endereco.ToEntity()
            );
        }
    }
}