create database VinosProyecto;

use VinosProyecto;

drop database VinosProyecto;
CREATE TABLE Cliente (
    [IdCliente] INTEGER NOT NULL IDENTITY(1,1),
    [Nombre] VARCHAR(64) NOT NULL,
    [PrimerApellido] VARCHAR(64) NOT NULL,
    [SegundoApellido] VARCHAR(64) NOT NULL,
    [Correo] VARCHAR(256) NOT NULL,
    [Telefono] VARCHAR(16) NOT NULL,
    [Usuario] VARCHAR(16) NOT NULL,
    [Pass] VARCHAR(16) NOT NULL,
    [Direccion] VARCHAR(512) NOT NULL,
    [Provincia] VARCHAR(32) NOT NULL,
    [Canton] VARCHAR(64) NOT NULL,
    [Distrito] VARCHAR(64) NOT NULL,
    [FechaNacimiento] DATETIME NOT NULL,
    [Rol] varchar(50) null DEFAULT('cliente')
    PRIMARY KEY ([IdCliente]),
    UNIQUE ([Usuario])
);
CREATE TABLE Vino (
    [IdVino] INTEGER NOT NULL IDENTITY(1,1),
    [Nombre] VARCHAR(256) NOT NULL,
    [PrecioBase] FLOAT NOT NULL,
    PRIMARY KEY ([IdVino])
);
CREATE TABLE Diseño (
    [IdDiseño] INTEGER NOT NULL IDENTITY(1,1),
    [Nombre] VARCHAR(64) NOT NULL,
    [Descripcion] VARCHAR(200) NOT NULL,
    PRIMARY KEY ([IdDiseño])
);
CREATE TABLE ItemPedido (
    [IdItem] INTEGER NOT NULL IDENTITY(1,1),
    [IdPedido] INTEGER NOT NULL,
    [IdVino] INTEGER NOT NULL,
    [Descripcion] VARCHAR(200) NOT NULL,
    [IdDiseño] INTEGER NOT NULL,
    [Cantidad] INTEGER NOT NULL,
    [Precio] FLOAT NOT NULL,
    PRIMARY KEY ([IdItem])
);
CREATE TABLE Pedido (
    [IdPedido] INTEGER NOT NULL IDENTITY(1,1),
    [IdCliente] INTEGER NOT NULL,
    [FechaCreacion] DATETIME2(0) NOT NULL,
    [FechaEntrega] DATE NOT NULL,
    [PrecioTotal] FLOAT NOT NULL,
    [Estado] VARCHAR(32) NOT NULL,
    PRIMARY KEY ([IdPedido])
);

CREATE TABLE Feedback (
    [IdFeedback] INTEGER NOT NULL IDENTITY(1,1),
    [IdVino] INTEGER NOT NULL,
    [Comentario] VARCHAR(512) NOT NULL,
    [Calificacion] INTEGER NOT NULL,
    PRIMARY KEY ([IdFeedback])
);

ALTER TABLE [Pedido] ADD FOREIGN KEY ([IdCliente]) REFERENCES Cliente([IdCliente]);
ALTER TABLE [ItemPedido] ADD FOREIGN KEY ([IdVino]) REFERENCES Vino([IdVino]);
ALTER TABLE [ItemPedido] ADD FOREIGN KEY ([IdPedido]) REFERENCES Pedido([IdPedido]);
ALTER TABLE [ItemPedido] ADD FOREIGN KEY ([IdDiseño]) REFERENCES Diseño([IdDiseño]);
ALTER TABLE [Feedback] ADD FOREIGN KEY ([IdVino]) REFERENCES Vino([IdVino]);

SELECT * FROM cliente;