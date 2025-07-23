using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Logradouro { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Cidade { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Estado { get; set; } = null!;

        [Required, MaxLength(10)]
        public string CEP { get; set; } = null!;

        public int DoadorId { get; set; }
        public Doador Doador { get; set; } = null!;

        public void Update(string logradouro, string cidade, string estado, string cep)
        {
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
        }
    }
}