using System.ComponentModel.DataAnnotations;

namespace Revisao1.Models
{
    public class Voto
    {
        [Required]
        public string RA { get; set; }

        [Required]
        public DateTime DataVoto { get; set; }

        [Required]
        [Range(10,99)]
        public int NumeroCandidato { get; set; }
    }
}
