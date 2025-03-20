﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sessions_app.Models
{
    [Table("PACIENTE")]
    public class Paciente
    {
        [Key]
        [Column("ID_PACIENTE")]
        public int IdPaciente { get; set; }

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

        [DataType(DataType.Date)]
        [Column("DATA_NASCIMENTO")]
        public DateTime? DataNascimento { get; set; }
    }
}
