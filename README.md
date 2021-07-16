*** Comandos config ***
-- dotnet ef migrations add EstruturaInicial
-- dotnet ef database update

-- dotnet ef dbcontext scaffold "host=localhost;database=aula_youtube_pedido_produtos;user id=danilo" Microsoft.EntityFrameworkCore.SqlServer -o Models -f -c ContextoCms

-- dotnet tool install -g dotnet-aspnet-codegenerator
-- dotnet aspnet-codegenerator controller -name ClientesController -m Cliente -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout
-- dotnet aspnet-codegenerator controller -name ProdutosController -m Produto -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout
-- dotnet aspnet-codegenerator controller -name PedidosController -m Pedido -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout
-- dotnet aspnet-codegenerator controller -name PedidoProdutosController -m PedidoProduto -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout



**** Configurando produção ****

wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb 
sudo dpkg -i packages-microsoft-prod.deb 

sudo apt update 

sudo apt-cache dump | grep dotnet-sdk

sudo apt install apt-transport-https 
sudo apt install dotnet-sdk-5.0

sudo apt install apt-transport-https 
sudo apt install dotnet-runtime-5.0

proxy_pass no nginx

location /some/path/ {
    proxy_pass https://localhost:5001;
}

sudo systemctl restart nginx


dotnet tool install --global dotnet-ef 
dotnet ef database update

sudo lsof -iTCP -sTCP:LISTEN -P | grep :5001

https://stackoverflow.com/questions/44682864/cannot-connect-to-rds-sql-server-database-using-management-studio

Inbound rules
Type  Protocol Port range Source
MSSQL	TCP	     1433	      0.0.0.0/0


