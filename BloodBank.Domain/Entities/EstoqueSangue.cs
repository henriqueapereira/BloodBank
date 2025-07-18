using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Domain.Entities
{
    public class EstoqueSangue
    {
        public int Id { get; set; }

        [Required]
        public string TipoSanguineo { get; set; } = null!;

        [Required]
        public string FatorRh { get; set; } = null!;
        public int QuantidadeML { get; set; }
    }
}