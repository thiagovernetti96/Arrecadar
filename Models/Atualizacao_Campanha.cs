
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arrecadar.Models
{

    public class Atualizacao_Campanha
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Campanha))]
        public int CampanhaId { get; set; }
        [Required]
        public Campanha Campanha { get; set; }

        [Required, Range(10, 100)]
        [RegularExpression(@"^[a-zA-ZÀ-ú0-9\s']+$")]
        public string Titulo { get; set; }

        [Required, Range(10, 1000)]
        [RegularExpression(@"^[a-zA-ZÀ-ú0-9\s']+$")]
        public string Descricao { get; set; }
        public string? Imagem_Url { get; set; }

        public DateTime Data_Publicacao { get; set; }
    }
}
