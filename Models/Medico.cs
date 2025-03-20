using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sessions_app.Models
{
    [Table("MEDICO")]
    public class Medico
    {
        [Key]
        [Column("ID_MEDICO")]
        public int IdMedico { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(255, ErrorMessage = "O nome deve ter no máximo 255 caracteres")]
        [Column("NOME")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 caracteres")]
        [Column("TELEFONE")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        [StringLength(255, ErrorMessage = "O email deve ter no máximo 255 caracteres")]
        [Column("EMAIL")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O CRM é obrigatório")]
        [StringLength(15, ErrorMessage = "O CRM deve ter no máximo 15 caracteres")]
        [Column("CRM")]
        public string CRM { get; set; }
    }
}
