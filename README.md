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

## Exemplo de JSON (atualizacao - PUT)
```json
{
  "nome_brinquedo": "Carrinho Hot Wheels",
  "tipo_brinquedo": "Carro",
  "classificacao": "6+",
  "tamanho": "Pequeno",
  "preco": 34.90
}
```

## Exemplo de DELETE
Endpoint:
`DELETE /brinquedos/{id}`
Exemplo:
`DELETE /brinquedos/1`

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
4. Para facilitar, importe o arquivo `postman_collection.json` deste repositorio.

## Evidencias (prints)
Inclua os prints abaixo no repositorio e atualize esta secao com os caminhos das imagens.

Swagger:
- `docs/prints/swagger-get-all.png`
- `docs/prints/swagger-post.png`
- `docs/prints/swagger-put.png`
- `docs/prints/swagger-delete.png`

Postman/Insomnia:
- `docs/prints/postman-get-all.png`
- `docs/prints/postman-post.png`
- `docs/prints/postman-put.png`
- `docs/prints/postman-delete.png`

Testes unitarios:
- `docs/prints/tests-dotnet-test.png`

Observacao: os prints devem mostrar a URL (localhost), metodo HTTP, payload e resposta.

## Acessar no Oracle SQL Developer
1. Crie uma nova conexao no SQL Developer.
2. Use o mesmo `User Id`, `Password`, `HOST`, `PORTA` e `SERVICE_NAME` definidos em `ToyAPI/appsettings.json`.
3. A tabela criada sera `TDS_TB_Brinquedos`.

## Executar os testes
```bash
dotnet test
```
