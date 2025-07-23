using System.ComponentModel.DataAnnotations;

namespace BloodBank.Domain.Entities
{
    public class Doador
    {
        public int Id { get; private set; }
        public string NomeCompleto { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public DateTime DataNascimento { get; private set; }
        public string Genero { get; private set; } = null!;
        public double Peso { get; private set; }
        public string TipoSanguineo { get; private set; } = null!;
        public string FatorRh { get; private set; } = null!;

        public Endereco? Endereco { get; private set; }
        public ICollection<Doacao> Doacoes { get; private set; } = new List<Doacao>();

        // Construtor para EF
        protected Doador() { }

        public Doador(
            string nomeCompleto,
            string email,
            DateTime dataNascimento,
            string genero,
            double peso,
            string tipoSanguineo,
            string fatorRh,
            Endereco? endereco = null)
        {
            // Validações simples
            if (string.IsNullOrWhiteSpace(nomeCompleto)) throw new ArgumentException("Nome é obrigatório");
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email é obrigatório");
            if (peso <= 0) throw new ArgumentException("Peso deve ser maior que 0");
            if (string.IsNullOrWhiteSpace(tipoSanguineo)) throw new ArgumentException("Tipo sanguíneo é obrigatório");
            if (string.IsNullOrWhiteSpace(fatorRh)) throw new ArgumentException("Fator Rh é obrigatório");
            if (string.IsNullOrWhiteSpace(genero)) throw new ArgumentException("Gênero é obrigatório");

            NomeCompleto = nomeCompleto;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            Endereco = endereco;
        }

        public void Update(
            string nomeCompleto,
            string email,
            DateTime dataNascimento,
            string genero,
            double peso,
            string tipoSanguineo,
            string fatorRh
            
        )
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
        }
    }
}