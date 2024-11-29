# 🚚 MAXTRUCK Backend

## 🖥️ Sobre o Projeto

O **MAXTRUCK Backend** é uma API RESTful desenvolvida em .NET, responsável por gerenciar as operações de backend do sistema **MAXTRUCK**, incluindo:

- Cadastro de usuários e caminhões.
- Consulta de pontes críticas.
- Geração de rotas seguras integradas à API HERE Maps.

A API oferece suporte completo ao frontend Angular e utiliza uma base de dados PostgreSQL para armazenamento de dados.

---

## ⚙️ Funcionalidades

✔️ Cadastro e gerenciamento de usuários.  
✔️ Cadastro e gerenciamento de caminhões.  
✔️ Consulta de pontes cadastradas com base nos parâmetros do caminhão.  
✔️ API RESTful com autenticação JWT.

---

## 🛠️ Tecnologias

As seguintes tecnologias foram utilizadas no desenvolvimento do **MAXTRUCK Backend**:

- [dotnet 8.0.403](https://learn.microsoft.com/dotnet/)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [PostgreSQL](https://www.postgresql.org/)
- [JWT Authentication](https://jwt.io/)
- [AutoMapper](https://automapper.org/)

---

## 🚀 Como Executar o Projeto

### Pré-requisitos:

- Visual Studio (versão 2022 ou superior).
- SDK .NET Core 8.0.403 instalado.
- Banco de dados PostgreSQL configurado.

### Passos:

1. Clone o repositório:
   ```bash
   git clone https://github.com/mariahelenads/Maxtruck_BackEnd.git

   ```
2. Abra o projeto no Visual Studio:

   ```bash
   Abra o arquivo MAXTRUCK.sln no Visual Studio.

   ```

3. Configure o arquivo appsettings.json: Atualize a string de conexão com o banco de dados PostgreSQL :

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=maxtruck;Username=seu-usuario;Password=sua-senha"
  }
}
```

5. Restaure as dependências: No Visual Studio, execute o comando::

   ```bash
   dotnet restore

   ```

6. Inicie o servidor:

   ```bash
   Pressione F5 no Visual Studio.

   ```

6. O Swagger da API estará disponivel em 
   ```bash
   https://localhost:7153/swagger/index.html.

   ```
(host configurado em `"https:applicationUrl"` do arquivo `Properties/launchSettings.json`):

## 🗄️ Banco de Dados

O **MAXTRUCK Backend** utiliza o banco de dados **PostgreSQL 17.0** 

### 🐘 Como Configurar o PostgreSQL

1. **Instale o PostgreSQL:**
   - Baixe o instalador adequado para o seu sistema operacional no site oficial: [https://www.postgresql.org/download/](https://www.postgresql.org/download/).
   - Durante a instalação, configure um nome de usuário e senha. Por exemplo:
     - **Usuário:** `postgres`
     - **Senha:** `sua-senha`

2. **Acesse o Banco de Dados com o DBeaver:**
   - Baixe e instale o **DBeaver**: [https://dbeaver.io/download/](https://dbeaver.io/download/).
   - Conecte-se ao PostgreSQL:
     - **Host:** `localhost`
     - **Porta:** `5432`
     - **Banco de Dados:** `postgres`
     - **Usuário:** `postgres`
     - **Senha:** `sua-senha`

3. **📜 Execute os Scripts do Banco de Dados:**

#### 🗂️ Criação das Tabelas
```bash
CREATE TABLE "TB_USER" (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    name VARCHAR NOT NULL,
    document varchar not NULL,
    email VARCHAR NOT NULL UNIQUE,
    password VARCHAR NOT NULL,
    create_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE public."TB_TRUCKS" (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	model varchar(100) NOT NULL,
	brand varchar(100) NOT NULL,
	length numeric(10, 2) NOT NULL,
	weight numeric(10, 2) NOT NULL,
	height numeric(10, 2) NOT NULL,
	license_plate varchar(20) NOT NULL,
	load_capacity numeric(10, 2) NOT NULL,
	user_id uuid NOT NULL,
	active bool DEFAULT true NULL,
	create_at timestamp DEFAULT CURRENT_TIMESTAMP NULL,
	updated_at timestamp NULL,
	description text NULL,
	CONSTRAINT "TB_TRUCKS_license_plate_key" UNIQUE (license_plate),
	CONSTRAINT "TB_TRUCKS_pkey" PRIMARY KEY (id)
);
ALTER TABLE public."TB_TRUCKS" ADD CONSTRAINT "TB_TRUCKS_user_id_fkey" FOREIGN KEY (user_id) REFERENCES public."TB_USER"(id);

CREATE TABLE "TB_BRIDGES" (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    name VARCHAR(255) NOT NULL,
    max_height_expressway NUMERIC NULL,
    max_height_local_road NUMERIC NULL,
    max_height_single_road NUMERIC NULL,
    max_height_central NUMERIC NULL
);
```

#### 🌉 Inserção de Dados das Pontes
```bash
INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Ponte Engº Roberto Zuccolo', 5.3, 5.2, NULL, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Ponte Morumbi', 5.78, 5.68, NULL, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Ponte Nova Morumbi', 5.01, 5.8, NULL, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Ponte Laguna', NULL, NULL, 7.0, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Ponte Itapaiuna', 6.63, NULL, NULL, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Ponte João Dias', NULL, NULL, 5.6, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Passarela após Ponte João Dias', NULL, NULL, 5.93, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Ponte João Dias', 8.0, 5.31, NULL, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Ponte Itapaiuna', 6.19, NULL, NULL, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Ponte Laguna', 6.7, NULL, NULL, 7.0);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Passarela Granja Julieta', 5.87, 5.3, NULL, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Ponte Nova Morumbi', 6.9, 5.8, NULL, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Ponte Morumbi', 6.8, 5.88, NULL, 4.62);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Passarela Estação Berrini', 5.38, 5.63, NULL, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Ponte Engº Roberto Zuccolo', 6.13, 6.1, NULL, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Viaduto República Armênia', NULL, 5.5, NULL, 5.9);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Passarela Vila Olímpia', 6.29, 5.7, NULL, NULL);

INSERT INTO "TB_BRIDGES" (name, max_height_expressway, max_height_local_road, max_height_single_road, max_height_central)
VALUES ('Ponte Engº Roberto Zuccolo', 4.65, 5.05, NULL, NULL);
```