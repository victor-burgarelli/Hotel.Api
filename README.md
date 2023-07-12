# Hotel.Api
API feita em ASP.NET Core 6 com operações CRUD de hotéis com persistência de dados em SQL Server.
## :hammer: Funcionalidades do projeto

- `Criar Categoria`: Cria uma categoria para classificar um hotel.
- `Criar Hotel`: Faz o cadastro de um novo hotel juntamente de seu endereço.
- `Editar Hotel`: Edita as informações de um hotel.
- `Deletar Hotel`: Deleta um hotel.
- `Visualizar hotel`: Retorna os detalhes de um hotel especifico.
- `Visualizar todos hoteis`: Retorna uma lista com todos os hoteis.
## 📝 Pré-requisitos
* Visual Studio
* SQL Server Express + SSMS
## 🛠️ Abrir e rodar o projeto
1. Após baixar o projeto, extraia o arquivo ZIP
2. Abra o .sln
3. Crie uma nova conexão no banco de dados utilizando o SSMS
4. Adicione sua string de conexão no arquivo appsetting.Development.json, você irá mudar apenas o começo da string de acordo com sua conexão por exemplo:
   `"ConnectionStrings": {
    "ConnStr": "Data Source=DESKTOP-SA87846\\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"}` Você irá mudar apenas `DESKTOP-SA87846\\SQLEXPRESS`
5. Abra o Package Manager Console e digite o comando `update-database`
6. Compile a solução
7. API pronta para uso ✅

## 📝 Instruções para uso da API
![image](https://github.com/victor-burgarelli/Hotel.Api/assets/99456672/7a0ff5d3-607a-416c-8247-262c2d616458)
Todo Hotel precisa de uma categoria, para criar um hotel devemos preencher o campo "CategoryId" de acordo com o Id da categoria que você criou anteriormente através do endpoint `AddCategory`.
Os outros end-points seguem o padrão de um CRUD, você pode visualizar os dados de um hotel em específico informando o Id, visualizar uma lista com todos os hotéis existentes, criar, editar e deletar um hotel de acordo com a documentação do Swagger.
