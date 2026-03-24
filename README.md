# 🎫 Internal Support Ticket System - Ability Challenge

Este projeto é uma solução fullstack desenvolvida para o gerenciamento de chamados técnicos internos, como parte do desafio técnico para a **Ability Tecnologia**. A aplicação permite a abertura, listagem e conclusão de tickets de suporte de forma rápida e resiliente.

 ## 📸 Preview
    
    ![abilityCase-screenshot](https://github.com/user-attachments/assets/39dbcb39-e40e-4b63-a697-d95ce0a4e903)

## 🚀 Diferenciais de Implementação

* **Resiliência de Infraestrutura:** Implementação de `healthchecks` no Docker Compose, garantindo que a API só inicie após o banco de dados SQL Server estar totalmente pronto para conexões.
* **Auto-Migration:** A API foi configurada para detectar a ausência do banco de dados e aplicar as Migrations do Entity Framework automaticamente ao subir o container, dispensando comandos manuais.
* **Arquitetura:** Uso do **Repository Pattern** para desacoplamento da camada de dados e facilitação de testes unitários futuros.
* **UX/UI:** Interface limpa e intuitiva desenvolvida com CSS moderno e JavaScript Vanilla para alta performance.

---

## 🛠️ Tecnologias Utilizadas

* **Backend:** .NET 8 (C#)
* **Banco de Dados:** SQL Server 2022
* **ORM:** Entity Framework Core
* **Frontend:** HTML5, CSS3 e JavaScript (Vanilla)
* **Containerização:** Docker & Docker Compose
* **Documentação:** Swagger (OpenAPI)

---

## 📦 Como Executar o Projeto

### Pré-requisitos

* [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado e em execução.

### Passo a Passo

1. **Clone o repositório:**
    ```bash
    git clone https://github.com/t3lles/ability-case.git
    cd ability-case
    ```

2. **Suba os containers via Docker Compose:**

    Na raiz do projeto, execute:
    ```bash
    docker-compose up --build
    ```
    *Aguarde até que o log exiba a mensagem: `Database and Migrations applied successfully!`.*

3. **Acesse as Interfaces:**
    * **Frontend:** Abra o arquivo `frontend/index.html` diretamente no seu navegador.
    * **Swagger UI (Documentação da API):** Acesse [http://localhost:5000/index.html](http://localhost:5000/index.html).
    * **Banco de Dados:** O SQL Server estará acessível externamente pela porta **1434** (para evitar conflitos com instâncias locais na porta padrão 1433).

---

## 📂 Estrutura do Repositório

```text
ability-case/
├── docker-compose.yml       # Orquestração de containers (API + DB)
├── frontend/                # Interface Web (Página Única)
│   ├── index.html
│   ├── style.css
│   └── script.js
└── src/
    └── Ability.Api/         # Backend em .NET 8
        ├── Controllers/     # Endpoints REST
        ├── Data/            # DbContext e Configuração do EF
        ├── Models/          # Entidades (Ticket) e Enums (Status)
        ├── Repositories/    # Implementação do Repository Pattern
        ├── Migrations/      # Versionamento do Banco de Dados
        └── Dockerfile       # Definição da imagem Docker da API
```

---

## 🧠 Considerações Técnicas

* **CORS:** Configurado no `Program.cs` para permitir requisições do frontend local para a API dentro do container.
* **Status de Ticket:** Implementado via `Enum` (Aberto, EmAndamento, Concluido) para garantir a consistência dos dados.
* **Ambiente Isolado:** Toda a configuração de conexão entre API e Banco utiliza os nomes de serviços do Docker (`ticket_db`), garantindo que o projeto funcione em qualquer máquina com Docker instalado.

---

Desenvolvido por Giovanna Teles 🚀
