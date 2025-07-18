using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Domain.Entities
{
    public class Doacao
    {
        public int Id { get; set; }
        public int DoadorId { get; set; }
        
        [Required]
        public DateTime DataDoacao { get; set; }

        [Range(420, 470)]
        public int QuantidadeML { get; set; }

        public Doador Doador { get; set; } = null!;
    }
}