# vyracare-api-proceedings

API .NET 8 responsavel pelo catalogo corporativo de procedimentos esteticos da plataforma Vyracare.

## Estrutura

A API foi reorganizada em `vertical slice` por caso de uso.

- `Features/Proceedings/Create`
  Cadastro de novos procedimentos.
- `Features/Proceedings/List`
  Consulta do catalogo.
- `Features/Proceedings/GetById`
  Consulta individual.
- `Features/Proceedings/Shared`
  Entidade `Proceeding` e porta `IProceedingRepository`.
- `Common`
  Configuracao, resultados, extensoes HTTP e abstração de tempo.
- `Infrastructure/Persistence`
  Adapter MongoDB para a collection `proceedings`.
- `Infrastructure/DependencyInjection`
  Registro de handlers, repositorio e conexao do banco.

Arquivos centrais:
- [Program.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Program.cs)
- [ProceedingsController.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Features/Proceedings/ProceedingsController.cs)
- [MongoProceedingRepository.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Infrastructure/Persistence/MongoProceedingRepository.cs)

## Fluxo funcional

1. O `vyracare-app-proceedings-mfe` envia o formulario para `POST /api/proceedings`.
2. `CreateProceedingHandler` valida o payload e monta a entidade de dominio.
3. `IProceedingRepository` abstrai a persistencia.
4. `MongoProceedingRepository` grava na collection `proceedings`.

## Rotas

- `GET /api/proceedings`
- `GET /api/proceedings/{id}`
- `POST /api/proceedings`

## Seguranca e configuracao

- JWT obrigatorio em todos os endpoints.
- Configuracao sensivel carregada via AWS Secrets Manager.
- Secrets padrao:
  - `vyracare/shared/mongo`
  - `vyracare/shared/jwt-signing`

Fallbacks suportados:
- `MONGO_URI`
- `JWT_KEY`
- `JWT_ISSUER`
- `JWT_AUDIENCE`
- `CORS_ALLOWED_ORIGINS`

## Testes unitarios

Camada de testes:

- [Vyracare.Api.Proceedings.Tests.csproj](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Vyracare.Api.Proceedings.Tests/Vyracare.Api.Proceedings.Tests.csproj)

Cobertura inicial incluida:
- `CreateProceedingHandler`
- `GetProceedingByIdHandler`

Comando esperado:

```bash
dotnet test Vyracare.Api.Proceedings.Tests/Vyracare.Api.Proceedings.Tests.csproj
```

## Integracao com frontend

O arquivo [.vyracare/mfe-consumer.json](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/.vyracare/mfe-consumer.json) identifica o `vyracare-app-proceedings-mfe` como consumidor e permite que a esteira sincronize `apiUrl` em `dev` e `prod`.

## Execucao local

```bash
dotnet restore
dotnet build
dotnet run
```

## Deploy

Publica em AWS Lambda + HTTP API com Swagger em:

- `/swagger/index.html`
- `/swagger/v1/swagger.json`
