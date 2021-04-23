using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using admin_cms.Models.Domino.Entidades;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace admin_cms.Models.Infraestrutura.Autenticacao
{
  public class Token 
  {
    public static string GerarToken(Administrador adm)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
			var key = Encoding.ASCII.GetBytes(jAppSettings["JwtToken"].ToString());
			var expirationTime = Convert.ToInt32(jAppSettings["ExpirationTime"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
			{
				Subject = new ClaimsIdentity(new Claim[]{
						new Claim(ClaimTypes.Name, adm.Nome),
						new Claim(ClaimTypes.Role, adm.Acesso),
					}),
				Expires = DateTime.UtcNow.AddHours(expirationTime),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
  }
}