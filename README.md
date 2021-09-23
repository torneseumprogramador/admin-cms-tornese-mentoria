*** Comandos config *** <br>
-- dotnet ef migrations add EstruturaInicial <br>
-- dotnet ef database update <br>
 <br>
-- dotnet ef dbcontext scaffold "host=localhost;database=aula_youtube_pedido_produtos;user id=danilo" Microsoft.EntityFrameworkCore.SqlServer -o Models -f -c ContextoCms <br>
 <br>
-- dotnet tool install -g dotnet-aspnet-codegenerator <br>
-- dotnet aspnet-codegenerator controller -name ClientesController -m Cliente -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout <br>
-- dotnet aspnet-codegenerator controller -name ProdutosController -m Produto -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout <br>
-- dotnet aspnet-codegenerator controller -name PedidosController -m Pedido -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout <br>
-- dotnet aspnet-codegenerator controller -name PedidoProdutosController -m PedidoProduto -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout <br>
 <br>
 <br>
 <br>
**** Configurando produção **** <br>
 <br>
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb  <br>
sudo dpkg -i packages-microsoft-prod.deb  <br>
 <br>
sudo apt update  <br>
 <br>
sudo apt-cache dump | grep dotnet-sdk <br>
 <br>
sudo apt install apt-transport-https  <br>
sudo apt install dotnet-sdk-5.0 <br>
 <br>
sudo apt install apt-transport-https  <br>
sudo apt install dotnet-runtime-5.0 <br>
 <br>
proxy_pass no nginx <br>
 <br>
location /some/path/ { <br>
    proxy_pass https://localhost:5001; <br>
} <br>
 <br>
sudo systemctl restart nginx <br>
 <br>
 <br>
dotnet tool install --global dotnet-ef  <br>
dotnet ef database update <br>
 <br>
*** verifica se aplicação está de pé <br>
sudo lsof -iTCP -sTCP:LISTEN -P | grep :5001 <br>
 <br>
*** verifica log acesso <br>
tail -f /var/log/nginx/access.log <br>
 <br>
*** verifica log error <br>
tail -f /var/log/nginx/error.log <br>
 <br>
https://stackoverflow.com/questions/44682864/cannot-connect-to-rds-sql-server-database-using-management-studio <br>
 <br>
Inbound rules <br>
Type  Protocol Port range Source <br>
MSSQL	TCP	     1433	      0.0.0.0/0 <br>


