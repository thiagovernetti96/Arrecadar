using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Arrecadar.Models
{
    public class Campanha
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required, Range(5, 100)]
        [RegularExpression(@"^[a-zA-ZÀ-ú\s'-]+$")]
        public string Titulo { get; set; }

        [Required]
        [ForeignKey(nameof(Ongs))]
        public int OngId { get; set; }

        [Required]
        public Ong Ongs { get; set; }


        [Required, Range(10, 1000)]
        [RegularExpression(@"^[a-zA-ZÀ-ú0-9\s']+$")]
        public string Descricao { get; set; }
        public decimal? Meta_Arrecadacao { get; set; }
        public decimal? Valor_Arrecadado { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Data_Inicio { get; set; }
        public string? Imagem_Url { get; set; }

        public enum Status
        {
            Ativa,
            Suspensa,
        }
        public static Status Set(string status)
        {
            return Enum.TryParse(status, true, out Status result)
                ? result
                : throw new ArgumentException("Status inválido. Use 'Ativa' ou 'Suspensa'.");
        }


    }
}
