using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Arrecadar.Models
{
        public class Usuario
        {
            [Key]
            [Required]
            public int Id { get; set; }
            [Required]
            [MinLength(3)]
            [RegularExpression(@"^[a-zA-ZÀ-ú\s'-]+$")]
            public string Nome { get; set; }
            [Required]
            [EmailAddress(ErrorMessage = "Email inválido")]
            public string Email { get; set; }

            private string Senha_Hash { get; set; }

            [NotMapped]
            public string Senha
            {
                set { SenhaHash = HashSenha(value); }
            }

            [Required]
            public string SenhaHash
            {
                get => SenhaHash;
                private set => SenhaHash = value;
            }
            private static string HashSenha(string senha)
            {
                return BCrypt.Net.BCrypt.HashPassword(senha, workFactor: 12);
            }

            [Required]
            [DataType(DataType.Date)]
            public DateTime Data_Cadastro { get; set; }

        }
    }
