using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Domain.Entities
{
    public class Doacao
    {
        protected Doacao() { }
        public Doacao(int doadorId, DateTime dataDoacao, int quantidadeML)
        {
            DoadorId = doadorId;
            DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
        }

        public int Id { get; set; }
        public int DoadorId { get; set; }

        public DateTime DataDoacao { get; set; }

        public int QuantidadeML { get; set; }

        public Doador Doador { get; set; } = null!;
    }
}