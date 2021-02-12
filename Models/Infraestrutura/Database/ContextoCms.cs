using System;
using System.IO;
using admin_cms.Models.Domino.Entidades;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace admin_cms.Models.Infraestrutura.Database
{
  public class ContextoCms : DbContext
  {
    public ContextoCms(DbContextOptions<ContextoCms> options) : base(options) { }

    public ContextoCms() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
      optionsBuilder.UseSqlServer(jAppSettings["ConexaoSql"].ToString());
    }

    public DbSet<Administrador> Administradores { get; set; }
    public DbSet<Pagina> Paginas { get; set; }
  }
}