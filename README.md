*** Comandos config ***
-- dotnet ef migrations add EstruturaInicial
-- dotnet ef database update

-- dotnet ef dbcontext scaffold "host=localhost;database=aula_youtube_pedido_produtos;user id=danilo" Microsoft.EntityFrameworkCore.SqlServer -o Models -f -c ContextoLoja1

-- dotnet tool install -g dotnet-aspnet-codegenerator
-- dotnet aspnet-codegenerator controller -name ClientesController -m Cliente -dc ContextoLoja1 --relativeFolderPath Controllers --useDefaultLayout
-- dotnet aspnet-codegenerator controller -name ProdutosController -m Produto -dc ContextoLoja1 --relativeFolderPath Controllers --useDefaultLayout
-- dotnet aspnet-codegenerator controller -name PedidosController -m Pedido -dc ContextoLoja1 --relativeFolderPath Controllers --useDefaultLayout
-- dotnet aspnet-codegenerator controller -name PedidoProdutosController -m PedidoProduto -dc ContextoLoja1 --relativeFolderPath Controllers --useDefaultLayout
