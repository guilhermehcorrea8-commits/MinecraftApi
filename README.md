# 🎮 Minecraft API (.NET 8 + Entity Framework Core)

## 📌 Sobre o Projeto

A Minecraft API é uma Web API REST desenvolvida em **ASP.NET Core 8** utilizando **Entity Framework Core** e **SQL Server**.

O projeto foi desenvolvido como atividade prática da disciplina de Web API, tendo como objetivo aplicar os principais conceitos do desenvolvimento de APIs REST.

A API permite gerenciar informações relacionadas ao universo Minecraft, como:

* 👤 Players
* 🌍 Mundos
* ⚔️ Itens
* 📦 Inventários
* 🧱 Blocos
* 👾 Mobs
* 🌳 Biomas
* ✨ Encantamentos

Além disso, a API realiza integração com serviços externos para consultar informações reais de jogadores do Minecraft.

---

# 🚀 Tecnologias Utilizadas

* ASP.NET Core 8
* Entity Framework Core 8
* SQL Server
* Swagger / OpenAPI
* C#
* REST API
* HttpClient

---

# 📚 Funcionalidades

## CRUD Completo

* Players
* Mundos
* Itens
* Blocos
* Mobs
* Biomas
* Encantamentos

---

## Consultas

* Buscar jogador por ID
* Buscar jogador por nickname
* Ranking de jogadores
* Dashboard da API

---

## Integrações

* Mojang API
* Minecraft Wiki
* Crafatar (Skins e Avatares)

---

# 🗄 Banco de Dados

O projeto utiliza SQL Server juntamente com Entity Framework Core.

Relacionamentos implementados:

* 1:N

  * Mundo → Players

* N:N

  * Players ↔ Itens
  * (Inventário)

---

# ▶ Como executar

Clone o projeto

```bash
git clone https://github.com/SEU_USUARIO/MinecraftApi.git
```

Entre na pasta

```bash
cd MinecraftApi
```

Restaure os pacotes

```bash
dotnet restore
```

Crie o banco

```bash
dotnet ef database update
```

Execute

```bash
dotnet run
```

---

# 🌐 Swagger

Após iniciar a aplicação:

```
https://localhost:xxxx/
```

ou

```
https://localhost:xxxx/swagger
```

---

# 📌 Endpoints

## Players

GET /api/Players

POST /api/Players

PUT /api/Players/{id}

DELETE /api/Players/{id}

GET /api/Players/buscar?nickname=Steve

---

## Mundos

GET /api/Mundos

POST /api/Mundos

PUT /api/Mundos/{id}

DELETE /api/Mundos/{id}

---

## Itens

GET /api/Itens

POST /api/Itens

PUT /api/Itens/{id}

DELETE /api/Itens/{id}

---

## Blocos

GET /api/Blocos

POST /api/Blocos

PUT /api/Blocos/{id}

DELETE /api/Blocos/{id}

---

## Mobs

GET /api/Mobs

POST /api/Mobs

PUT /api/Mobs/{id}

DELETE /api/Mobs/{id}

---

## Biomas

GET /api/Biomas

POST /api/Biomas

PUT /api/Biomas/{id}

DELETE /api/Biomas/{id}

---

## Encantamentos

GET /api/Encantamentos

POST /api/Encantamentos

PUT /api/Encantamentos/{id}

DELETE /api/Encantamentos/{id}

---

## Serviços Externos

GET /api/Profiles/{nickname}

GET /api/Skin/{nickname}

GET /api/Wiki?termo=diamond_sword

---

## Dashboard

GET /api/Dashboard

GET /api/Dashboard/ranking

GET /api/Dashboard/mundos

GET /api/Dashboard/itens

---

# 📂 Estrutura

```
Controllers
Context
DTOs
Models
Services
Migrations
Program.cs
appsettings.json
```

---

# 👨‍💻 Autor

Guilherme Hofman Correa Miguel Miaki

Projeto desenvolvido para fins acadêmicos utilizando ASP.NET Core 8, Entity Framework Core e SQL Server.
