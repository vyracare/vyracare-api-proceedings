vyracare-api-proceedings (.NET 8) - MongoDB + AWS Lambda
-----------------------------------------------

Descricao:
  - API responsável por administrar os procedimentos

Recursos iniciais:
  - Projeto .NET 8 preparado para AWS Lambda
  - MongoDB configurado com database `vyracare_db`
  - Controller inicial para a collection `proceedings`
  - Rotas base publicadas em `/api/proceedings`
  - Swagger habilitado em `/swagger/index.html`
  - CORS configurado por default para nao bloquear integracoes
  - JWT obrigatorio em todos os endpoints da API
  - Branch `develop` criada automaticamente a partir da `main`
  - Protecao basica habilitada em `main` e `develop`
  - Configuracao opcional de MFE consumidor em `.vyracare/mfe-consumer.json`

Integracao opcional com MFE:
  - Informe o repositório do MFE no issue form apenas quando a API precisar atualizar automaticamente a URL consumida
  - O template grava essa relacao no arquivo `.vyracare/mfe-consumer.json`
  - A esteira generica usa esse arquivo para descobrir qual repositório de frontend deve ser atualizado

Setup local:
  - Install .NET 8 SDK
  - Configure a MongoDB cluster and set `MONGO_URI` env var or update `appsettings.json`
  - Ajuste `Cors:AllowedOrigins` caso queira restringir origens
  - `dotnet restore`
  - `dotnet build`
  - `dotnet run`

To publish:
  - `dotnet publish -c Release -o ./publish`
  - Configure o secret `MONGO_URI` no repositório para o deploy da Lambda acessar o banco real
  - Opcionalmente configure `CORS_ALLOWED_ORIGINS` para sobrescrever os domínios permitidos
  - Opcionalmente configure `JWT_KEY`, `JWT_ISSUER` e `JWT_AUDIENCE` para sobrescrever os valores versionados
