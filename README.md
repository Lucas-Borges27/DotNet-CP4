# ToyAPI

Repositório: https://github.com/Lucas-Borges27/DotNet-CP4

API REST para gerenciamento de brinquedos de criancas ate 14 anos, usando ASP.NET Core Web API e Entity Framework Core com Oracle.

## Tecnologias
- C# / .NET
- ASP.NET Core Web API
- Entity Framework Core
- Oracle Database
- Oracle SQL Developer
- Swagger
- xUnit

## Endpoints
- `GET /brinquedos` - lista todos os brinquedos
- `GET /brinquedos/{id}` - retorna um brinquedo especifico
- `POST /brinquedos` - cria um novo brinquedo
- `PUT /brinquedos/{id}` - atualiza um brinquedo existente
- `DELETE /brinquedos/{id}` - remove um brinquedo

## Exemplo de JSON (cadastro de brinquedo - POST)
```json
{
  "nome_brinquedo": "Carrinho Hot Wheels",
  "tipo_brinquedo": "Carro",
  "classificacao": "5+",
  "tamanho": "Pequeno",
  "preco": 29.90
}
```

## Como rodar o projeto
1. Ajuste a string de conexao em `ToyAPI/appsettings.json` com seus dados do Oracle:
   - `User Id`, `Password`, `HOST`, `PORTA` e `SERVICE_NAME`
2. (Opcional) Crie o banco de dados via migrations:
```bash
# instalar a ferramenta (uma unica vez)
dotnet tool install --global dotnet-ef

# criar migration
dotnet ef migrations add InitialCreate --project ToyAPI --startup-project ToyAPI

# aplicar no banco
dotnet ef database update --project ToyAPI --startup-project ToyAPI
```
3. Execute a API:
```bash
dotnet run --project ToyAPI
```

## Testar no Swagger
- Ao iniciar o projeto, o Swagger abrira automaticamente em `http://localhost:5207/swagger`.
- Use a interface para executar `GET`, `POST`, `PUT` e `DELETE` diretamente no navegador.

## Testar no Postman
1. Crie uma nova collection.
2. Adicione requests para os endpoints listados acima.
3. Para `POST` e `PUT`, use `Body -> raw -> JSON` e cole o exemplo de JSON.

## Acessar no Oracle SQL Developer
1. Crie uma nova conexao no SQL Developer.
2. Use o mesmo `User Id`, `Password`, `HOST`, `PORTA` e `SERVICE_NAME` definidos em `ToyAPI/appsettings.json`.
3. A tabela criada sera `TDS_TB_Brinquedos`.

## Executar os testes
```bash
dotnet test
```
