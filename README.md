# DevFreela API

Uma API RESTful desenvolvida do zero com **ASP.NET Core**, aplicando boas práticas de arquitetura, escalabilidade e testabilidade. Este projeto simula um sistema de gerenciamento de freelancers e projetos, inspirado em cenários reais de backend.

---

## 🚀 Tecnologias e Ferramentas Utilizadas

- **ASP.NET Core**: Controllers, Actions, DTOs (Input e ViewModels), Dependency Injection, Middlewares, Rotas e Configuração por ambiente.
- **Entity Framework Core**: ORM para persistência de dados, Code First, DbContext, DbSets, Migrations, relacionamentos, Fluent API e bancos SQL.
- **Arquitetura Limpa (Clean Architecture)**: separação em camadas Core, Application, Infrastructure e API, aplicando DDD, Repositórios, Value Objects, Services e abstrações.
- **CQRS + MediatR**: Commands para escrita, Queries para leitura, Pipeline Behaviors para validações, Notifications para eventos desacoplados.
- **Padrão Repository**: abstração do acesso a dados, garantindo flexibilidade e testabilidade.
- **FluentValidation**: validações desacopladas nos Commands, mantendo a consistência de regras de negócio.
- **Swagger / OpenAPI**: documentação interativa dos endpoints.
- **Autenticação e Autorização**: JWT para segurança nos endpoints protegidos.
- **Testes Unitários**: xUnit, FluentAssertions, NSubstitute/Moq e Bogus para garantir qualidade e previsibilidade do código.

---

## 📝 Funcionalidades da API

### Usuários
- Criar, atualizar e deletar usuários.
- Login com autenticação JWT.
- Recuperação de senha via email.
- Validação de código de recuperação e alteração de senha.

### Projetos
- Criar, atualizar e deletar projetos.
- Início e conclusão de projetos.
- Comentários em projetos.
- Pesquisa e listagem de projetos com filtros.

### Skills
- Adicionar habilidades a usuários.
- Criar e listar skills disponíveis.

---

## ⚡ Boas práticas aplicadas

- **Segregação de responsabilidades**: Controllers finos delegando a execução para Handlers via CQRS.
- **Desacoplamento**: validações, notificações e acesso a dados isolados em suas camadas.
- **SOLID**: código modular, testável e fácil de manter.
- **Testabilidade**: handlers e services testáveis com mocks e dados fictícios.
- **Escalabilidade**: arquitetura preparada para crescimento sem acoplamento entre camadas.

---

## 📂 Estrutura do Projeto

DevFreela
- API => Camada de apresentação e endpoints
- Application => Lógica de negócios, Commands, Queries e Handlers
- Core => Entidades, Interfaces e Value Objects
- Infrastructure => Persistência de dados, EmailService, AuthService
- Tests => Testes unitários e mocks


---

## 📖 Documentação

A API possui documentação interativa via **Swagger**, disponível ao rodar a aplicação em `https://localhost:{7180}/swagger`.

---

## 💡 Observações

- Tokens JWT são utilizados para autenticação e autorização.
- As validações de Commands garantem consistência antes de qualquer alteração no banco.
- O padrão Repository facilita mudanças de tecnologia de persistência sem impactar o domínio.
- A API está preparada para testes unitários e futura expansão.

---

## 🔗 Contato

Desenvolvido por **[Lucas Woibau]**, para prática avançada de backend com .NET.
