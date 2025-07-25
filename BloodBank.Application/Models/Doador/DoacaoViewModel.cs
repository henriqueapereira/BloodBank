using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Domain.Entities;

namespace BloodBank.Application.Models.Doador
{
    public class DoacaoViewModel
    {
        public int Id { get; set; }
        public int DoadorId { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeML { get; set; }

        //retorna uma lista
        public static List<DoacaoViewModel> FromEntity(List<Doacao> doacoes)
        {
            return doacoes.Select(d => new DoacaoViewModel
            {
                Id = d.Id,
                DoadorId = d.DoadorId,
                DataDoacao = d.DataDoacao,
                QuantidadeML = d.QuantidadeML
            }).ToList();
        }

        //retorna um objeto
        public static DoacaoViewModel FromEntity(Doacao doacao)
        {
            return new DoacaoViewModel
            {
                Id = doacao.Id,
                DoadorId = doacao.DoadorId,
                DataDoacao = doacao.DataDoacao,
                QuantidadeML = doacao.QuantidadeML
            };
        }

    }
}