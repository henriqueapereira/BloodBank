using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Application.Models.Doador
{
    public class CreateDoacaoInputModel
    {
        [Required]
        public int DoadorId { get; set; }
        
        [Required]
        public DateTime DataDoacao { get; set; }

        [Required]
        [Range(420, 470, ErrorMessage = "A doação deve conter entre 420 e 470 ml.")]
        public int QuantidadeML { get; set; }
    }
}