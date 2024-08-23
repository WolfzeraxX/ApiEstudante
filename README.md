
# CursoEstudanteAPI

A CursoEstudanteAPI é uma API RESTful desenvolvida com ASP.NET Core e Entity Framework Core. O objetivo desta API é gerenciar informações sobre cursos, estudantes e avaliações, seguindo princípios SOLID e DDD.
## Uso/Exemplos

Cursos: CRUD para gerenciar cursos.
Estudantes: CRUD para gerenciar estudantes.
Avaliações: CRUD para gerenciar avaliações de cursos por estudantes.
Validações: Garante que as avaliações não sejam enviadas em branco ou sem um curso associado e que o nome do curso e estudante sejam obrigatórios.


## Tecnologias

ASP.NET Core 8.0
Entity Framework Core
SQL Server
System.Text.Json (ou Newtonsoft.Json para serialização JSON)
    
## Documentação

Estrutura do Projeto

    CursoEstudanteAPI.Application: Contém a lógica de negócios e serviços.
    CursoEstudanteAPI.Infrastructure: Contém a implementação do repositório e acesso a dados.
    CursoEstudanteAPI.API: Contém as controladoras e configuração da API.

## Configuração

Configuração do Banco de Dados

    Instale as ferramentas de EF Core CLI:

    bash

dotnet tool install --global dotnet-ef

Configure a string de conexão no appsettings.json:

json

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CursoEstudanteDb;Trusted_Connection=True;"
}

Criar e aplicar migrações:

    Adicionar uma migração:

    bash

dotnet ef migrations add InitialCreate

Aplicar a migração:

bash

        dotnet ef database update

Configuração da Serialização JSON

Para remover a propriedade $id da serialização JSON, adicione o seguinte código ao Program.cs ou Startup.cs:

## Execução

Compilar e executar o projeto:

bash

dotnet build
dotnet run

Acessar a API: Navegue para https://localhost:5001 ou http://localhost:5000 (dependendo da configuração) para acessar a API.

Testar Endpoints: Use ferramentas como Postman ou Swagger para testar os endpoints da API.

## EndPoints

Cursos

    GET /api/cursos: Retorna todos os cursos.
    GET /api/cursos/{id}: Retorna um curso específico.
    POST /api/cursos: Cria um novo curso.
    PUT /api/cursos/{id}: Atualiza um curso existente.
    DELETE /api/cursos/{id}: Remove um curso.

Estudantes

    GET /api/estudantes: Retorna todos os estudantes.
    GET /api/estudantes/{id}: Retorna um estudante específico.
    POST /api/estudantes: Cria um novo estudante.
    PUT /api/estudantes/{id}: Atualiza um estudante existente.
    DELETE /api/estudantes/{id}: Remove um estudante.

Avaliações

    GET /api/avaliacoes: Retorna todas as avaliações.
    GET /api/avaliacoes/{id}: Retorna uma avaliação específica.
    POST /api/avaliacoes: Cria uma nova avaliação.
    PUT /api/avaliacoes/{id}: Atualiza uma avaliação existente.
    DELETE /api/avaliacoes/{id}: Remove uma avaliação.
