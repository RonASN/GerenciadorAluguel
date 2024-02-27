CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Usuario" (
    "Id" uuid NOT NULL DEFAULT (gen_random_uuid()),
    "Nome" text NOT NULL,
    "Senha" text NOT NULL,
    "Email" text NOT NULL,
    "Role" integer NOT NULL,
    CONSTRAINT "PK_Usuario" PRIMARY KEY ("Id")
);

CREATE TABLE "Aluguel" (
    "Id" uuid NOT NULL DEFAULT (gen_random_uuid()),
    "Inicio" timestamp with time zone NOT NULL,
    "Termino" timestamp with time zone NOT NULL,
    "PrevisaoTermino" timestamp with time zone NOT NULL,
    "idUsuario" uuid NULL,
    CONSTRAINT "PK_Aluguel" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Aluguel_Usuario_idUsuario" FOREIGN KEY ("idUsuario") REFERENCES "Usuario" ("Id")
);

CREATE TABLE "Entregador" (
    "Id" uuid NOT NULL DEFAULT (gen_random_uuid()),
    "Cnpj" text NOT NULL,
    "DataNascimento" text NOT NULL,
    "CategoriaCnh" integer NOT NULL,
    "NumeroCnh" text NOT NULL,
    "ImagemCnh" text NOT NULL,
    "idUsuario" uuid NULL,
    CONSTRAINT "PK_Entregador" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Entregador_Usuario_idUsuario" FOREIGN KEY ("idUsuario") REFERENCES "Usuario" ("Id")
);

CREATE TABLE "Moto" (
    "Id" uuid NOT NULL DEFAULT (gen_random_uuid()),
    "Ano" integer NOT NULL,
    "Modelo" text NOT NULL,
    "Placa" text NOT NULL,
    "idUsuario" uuid NULL,
    CONSTRAINT "PK_Moto" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Moto_Usuario_idUsuario" FOREIGN KEY ("idUsuario") REFERENCES "Usuario" ("Id")
);

CREATE TABLE "Pedido" (
    "Id" uuid NOT NULL DEFAULT (gen_random_uuid()),
    "DataCriacao" timestamp with time zone NOT NULL,
    "ValorCorrida" double precision NOT NULL,
    "Situacao" integer NOT NULL,
    "idUsuario" uuid NULL,
    CONSTRAINT "PK_Pedido" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Pedido_Usuario_idUsuario" FOREIGN KEY ("idUsuario") REFERENCES "Usuario" ("Id")
);

CREATE UNIQUE INDEX "IX_Aluguel_idUsuario" ON "Aluguel" ("idUsuario");

CREATE UNIQUE INDEX "IX_Entregador_idUsuario" ON "Entregador" ("idUsuario");

CREATE UNIQUE INDEX "IX_Moto_idUsuario" ON "Moto" ("idUsuario");

CREATE INDEX "IX_Pedido_idUsuario" ON "Pedido" ("idUsuario");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240227142543_First-migration', '7.0.0');

COMMIT;

