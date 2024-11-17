using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fala_cidadao.Models
{
    public enum Categoria
    {
        Iluminacao,
        Pavimentacao,
        Saneamento,
        Limpeza,
        Sinalizacao,
        Segurança,
        Outro
    }

    [Table("Problemas")]
    public class Problema
    {
        public int Id { get; set; }

        [Required]
        public Categoria Categoria { get; set; }
  
        [Required]
        [Display(Name = "Descrição do Problema")]
        [StringLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres.")]
        public required string Descricao { get; set; }

        [Required]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        public required string Local { get; set; }

    }
}