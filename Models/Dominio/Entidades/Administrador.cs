using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace admin_cms.Models.Domino.Entidades
{
  public class Administrador
  {
    [Required]
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    [MaxLength(15)]
    public string Telefone { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [MaxLength(150)]
    public string Senha { get; set; }
    public string Imagem { get; set; }
    public string Acesso { get{ return "Admin"; }}
  }
}