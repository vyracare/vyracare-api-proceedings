# vyracare-api-proceedings

API .NET 8 responsavel pelo catalogo corporativo de procedimentos esteticos da plataforma Vyracare.

## Objetivo

O projeto centraliza o cadastro e a consulta de procedimentos esteticos usados pelas unidades da empresa. Hoje ele atende principalmente o fluxo do `vyracare-app-proceedings-mfe`, que utiliza esta API para:

- listar procedimentos cadastrados;
- salvar novos procedimentos;
- manter a URL de integracao sincronizada no frontend consumidor.

## Stack

- .NET 8
- ASP.NET Core Web API
- AWS Lambda com HTTP API
- MongoDB
- Swagger
- JWT Bearer Authentication

## Arquitetura

A estrutura atual do projeto esta organizada assim:

- [Program.cs](c:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Program.cs)
  Configura MongoDB, CORS, JWT, Swagger e o hosting da Lambda.

- [Controllers/ProceedingsController.cs](c:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Controllers/ProceedingsController.cs)
  Expoe os endpoints HTTP do modulo de procedimentos.

- [Services/ProceedingsService.cs](c:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Services/ProceedingsService.cs)
  Implementa o acesso a collection `proceedings` no MongoDB.

- [DTOS/ProceedingsDto.cs](c:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/DTOS/ProceedingsDto.cs)
  Define o contrato de entrada para criacao de procedimentos.

- [Models/ProceedingsModel.cs](c:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Models/ProceedingsModel.cs)
  Define o documento persistido no MongoDB.

- [.vyracare/mfe-consumer.json](c:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/.vyracare/mfe-consumer.json)
  Declara o frontend consumidor que deve ter a URL da API atualizada pela esteira de deploy.

## Fluxo funcional

O fluxo principal hoje e:

1. O `vyracare-app-proceedings-mfe` envia o formulario de cadastro.
2. A API recebe um `CreateProceedingsRequest`.
3. O controller converte o DTO em `ProceedingsModel`.
4. O service persiste o documento no MongoDB.
5. A API devolve o recurso criado com `201 Created`.

## Endpoints

Base path publicada:

`/api/proceedings`

Endpoints disponiveis:

- `GET /api/proceedings`
  Lista todos os procedimentos cadastrados.

- `GET /api/proceedings/{id}`
  Retorna um procedimento especifico pelo identificador.

- `POST /api/proceedings`
  Cria um novo procedimento.

Payload esperado no `POST`:

```json
{
  "name": "Toxina botulinica premium",
  "category": "Injetaveis",
  "code": "INJ-001",
  "targetArea": "Face",
  "durationMinutes": 45,
  "sessionPrice": 950,
  "sessionCount": 1,
  "recoveryTime": "24 horas",
  "description": "Suavizacao de linhas dinamicas.",
  "active": true
}
```

## Seguranca

Todos os endpoints exigem autenticacao JWT.

Configuracoes relevantes:

- `Jwt:Key`
- `Jwt:Issuer`
- `Jwt:Audience`

O Swagger tambem esta preparado para receber token Bearer.

## Swagger

Documentacao interativa:

- `/swagger/index.html`

Contrato OpenAPI:

- `/swagger/v1/swagger.json`

## Persistencia

A API grava os dados na collection:

- `proceedings`

Banco padrao:

- `vyracare_db`

Campos principais persistidos:

- `name`
- `category`
- `code`
- `targetArea`
- `durationMinutes`
- `sessionPrice`
- `sessionCount`
- `recoveryTime`
- `description`
- `active`
- `createdAt`
- `updatedAt`

## Configuracao

Arquivo principal:

- [appsettings.json](c:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/appsettings.json)

Exemplo das configuracoes versionadas:

- `Mongo:ConnectionString`
- `Mongo:Database`
- `Jwt:Key`
- `Jwt:Issuer`
- `Jwt:Audience`

Variaveis de ambiente suportadas no deploy:

- `MONGO_URI`
- `JWT_KEY`
- `JWT_ISSUER`
- `JWT_AUDIENCE`
- `CORS_ALLOWED_ORIGINS`

## Integracao com o MFE consumidor

Este projeto declara o `vyracare-app-proceedings-mfe` como consumidor em:

- [.vyracare/mfe-consumer.json](c:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/.vyracare/mfe-consumer.json)

Com isso, a esteira generica do deploy .NET consegue:

- descobrir qual frontend deve ser atualizado;
- atualizar `src/environments/environments.ts`;
- atualizar `src/environments/environments.prod.ts`;
- preencher a propriedade `apiUrl` com a URL publicada da API.

## Execucao local

Pre-requisitos:

- .NET 8 SDK
- acesso ao MongoDB

Comandos:

```bash
dotnet restore
dotnet build
dotnet run
```

## Deploy

Publicacao local:

```bash
dotnet publish -c Release -o ./publish
```

No GitHub Actions, o projeto depende da esteira reutilizavel do repositório de pipes .NET para:

- empacotar a Lambda;
- publicar a API no API Gateway;
- expor Swagger;
- atualizar o MFE consumidor quando configurado.
