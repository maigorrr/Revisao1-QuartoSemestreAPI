using System.ComponentModel.DataAnnotations;

namespace Revisao1.Models
{
    public class Candidato
    {
        //● Nome: mínimo de 3 e máximo de 50 caracteres.
        //● E-mail: deve ser um e-mail válido.
        //● Turma: número entre 1 e 8.
        //● Descrição da proposta: máximo de 500 caracteres.
        //● Número do candidato: número entre 10 e 99.

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo 3 caracteres e máximo 50 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email obrigatório!")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Turma de 1 a 8.")]
        [Range(1,8,ErrorMessage = "Turma obrigatória!")]
        public int Turma { get; set; }

        [StringLength(500, ErrorMessage = "Máximo 500 caracteres!")]
        [Required(ErrorMessage = "Descrição da proposta obrigatória!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Número do candidato obrigatório!")]
        [Range(10,99)]
        public int Numero { get; set; }
    }
}
