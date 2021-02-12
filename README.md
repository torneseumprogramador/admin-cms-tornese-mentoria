*** Comandos config ***
-- dotnet ef migrations add EstruturaInicial
-- dotnet ef database update

-- dotnet ef dbcontext scaffold "host=localhost;database=aula_youtube_pedido_produtos;user id=danilo" Microsoft.EntityFrameworkCore.SqlServer -o Models -f -c ContextoCms

-- dotnet tool install -g dotnet-aspnet-codegenerator
-- dotnet aspnet-codegenerator controller -name ClientesController -m Cliente -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout
-- dotnet aspnet-codegenerator controller -name ProdutosController -m Produto -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout
-- dotnet aspnet-codegenerator controller -name PedidosController -m Pedido -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout
-- dotnet aspnet-codegenerator controller -name PedidoProdutosController -m PedidoProduto -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout
