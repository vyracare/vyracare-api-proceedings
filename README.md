# vyracare-api-proceedings

## Visao geral

Esta API e responsavel pelo catalogo de procedimentos esteticos da plataforma.

Ela atende principalmente o `vyracare-app-proceedings-mfe`, que precisa:

- listar procedimentos;
- consultar um procedimento especifico;
- cadastrar novos procedimentos.

---

## Como ler este projeto pela primeira vez

Leia nesta ordem:

1. [Program.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Program.cs)
   Mostra configuracao de JWT, CORS, Swagger, Mongo e Lambda.

2. [ProceedingsController.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Features/Proceedings/ProceedingsController.cs)
   Mostra as rotas disponiveis.

3. O caso de uso de criacao:
   - [CreateProceedingRequest.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Features/Proceedings/Create/CreateProceedingRequest.cs)
   - [CreateProceedingHandler.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Features/Proceedings/Create/CreateProceedingHandler.cs)

4. O caso de uso de leitura:
   - [ListProceedingsHandler.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Features/Proceedings/List/ListProceedingsHandler.cs)
   - [GetProceedingByIdHandler.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Features/Proceedings/GetById/GetProceedingByIdHandler.cs)

5. A entidade e a porta:
   - [Proceeding.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Features/Proceedings/Shared/Domain/Proceeding.cs)
   - [IProceedingRepository.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Features/Proceedings/Shared/Ports/IProceedingRepository.cs)

6. O adapter Mongo:
   - [MongoProceedingRepository.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Infrastructure/Persistence/MongoProceedingRepository.cs)

7. Os testes:
   - [CreateProceedingHandlerTests.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Vyracare.Api.Proceedings.Tests/Proceedings/Create/CreateProceedingHandlerTests.cs)
   - [GetProceedingByIdHandlerTests.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Vyracare.Api.Proceedings.Tests/Proceedings/GetById/GetProceedingByIdHandlerTests.cs)

---

## Estrutura de pastas

### `Common`

Contem elementos reaproveitados por toda a API:

- options;
- resultado de caso de uso;
- extensoes HTTP;
- abstração de tempo.

### `Features/Proceedings`

Cada pasta representa um caso de uso do dominio:

- `Create`
- `List`
- `GetById`

### `Features/Proceedings/Shared`

Guarda:

- entidade `Proceeding`;
- interface `IProceedingRepository`.

### `Infrastructure`

Contem:

- leitura de secrets;
- DI;
- repositorio Mongo;
- documento Mongo;
- implementacao concreta do relogio da aplicacao.

### `Vyracare.Api.Proceedings.Tests`

Projeto de testes unitarios para os handlers.

---

## Fluxo passo a passo de uma requisicao

Vamos usar `POST /api/proceedings`.

1. O frontend envia o formulario.
2. O controller recebe o payload.
3. O payload vira `CreateProceedingRequest`.
4. O handler valida nome e demais campos obrigatorios.
5. O handler monta a entidade `Proceeding`.
6. O repositorio Mongo salva o documento.
7. O controller devolve `201 Created`.

Para leitura, o fluxo e similar:

1. o controller recebe a rota;
2. chama o handler;
3. o handler consulta a porta;
4. o repositorio Mongo devolve o dado;
5. o controller transforma em HTTP.

---

## Endpoints

Base path:

- `/api/proceedings`

Rotas:

- `GET /api/proceedings`
- `GET /api/proceedings/{id}`
- `POST /api/proceedings`

---

## Seguranca e configuracao

Todos os endpoints exigem JWT.

Secrets padrao:

- `vyracare/shared/mongo`
- `vyracare/shared/jwt-signing`

Fallbacks:

- `MONGO_URI`
- `JWT_KEY`
- `JWT_ISSUER`
- `JWT_AUDIENCE`
- `CORS_ALLOWED_ORIGINS`

Arquivo importante:

- [SecretsManagerBootstrapper.cs](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/Infrastructure/SecretsManagerBootstrapper.cs)

---

## Integracao com o MFE

O projeto declara o consumidor em:

- [.vyracare/mfe-consumer.json](C:/Users/lenin/OneDrive/Desktop/GitHub/Vyracare/vyracare-api-proceedings/.vyracare/mfe-consumer.json)

Isso permite que a esteira atualize a URL consumida pelo frontend apos o deploy.

---

## Testes unitarios

### O que esta coberto hoje

- validacao de nome obrigatorio;
- criacao com sucesso;
- busca por id inexistente;
- busca por id existente.

### Como rodar

```bash
dotnet restore
dotnet build --no-restore
dotnet test Vyracare.Api.Proceedings.Tests/Vyracare.Api.Proceedings.Tests.csproj --no-restore
```

### Como criar novos testes

1. escolha um handler;
2. crie fakes das portas;
3. simule o comportamento esperado;
4. teste retorno feliz e retorno de erro.

---

## Como adicionar um novo caso de uso

Exemplo: `UpdateProceeding`.

Passos:

1. Criar `Features/Proceedings/Update`.
2. Criar `UpdateProceedingRequest`.
3. Criar `UpdateProceedingHandler`.
4. Atualizar `IProceedingRepository`.
5. Implementar o metodo em `MongoProceedingRepository`.
6. Expor a rota no controller.
7. Registrar o handler em `ServiceCollectionExtensions`.
8. Escrever o teste unitario.

---

## Execucao local

```bash
dotnet restore
dotnet build
dotnet run
```

Swagger:

- `/swagger/index.html`

---

## Resumo para desenvolvedores

O caminho mental e:

- request entra no controller;
- controller chama o handler;
- handler aplica regra;
- handler usa uma porta;
- a infraestrutura implementa essa porta;
- o teste valida o handler sem precisar subir o banco.
