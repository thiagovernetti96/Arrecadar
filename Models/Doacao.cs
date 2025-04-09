using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Arrecadar.Models
{
    public class Doacao
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public Campanha Campanha { get; set; }

        [Required]
        [ForeignKey(nameof(Campanha))]
        public int CampanhaId { get; set; }
        [Required]
        public decimal Valor_Doado { get; set; }

        [Required]
        public DateTime Data { get; set; }

        public enum Metodo_Pagamento { Credito, Debito, Pix, Boleto };
        [Required]
        public Metodo_Pagamento Metodo { get; set; }
        public enum Status_Doacao { Pendente, Processando, Concluida, Falha, Cancelada, Reembolsada }
        [Required]
        public Status_Doacao Status { get; set; }



    }
}
