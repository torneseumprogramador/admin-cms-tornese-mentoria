using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace admin_cms.Models.Domino.Entidades
{
  public class Pagina
  {
    [Required]
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string Conteudo { get; set; }

    [Required]
    public bool AreaRestrita { get; set; }

    [Required]
    public bool Login { get; set; }
    
    [Required]
    public bool Home { get; set; }
    
    [Required]
    public int Ordem { get; set; }
  }
}