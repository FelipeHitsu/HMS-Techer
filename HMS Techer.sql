CREATE TABLE TipoQuarto  (
   TipoQuartoId int NOT NULL,
   Descricao nvarchar(255) NOT NULL,
   Valor  float NOT NULL,
   PRIMARY KEY (TipoQuartoId)
);

CREATE TABLE SituacaoQuarto  (
   SituacaoQuartoId int NOT NULL,
   Descricao nvarchar(255) NOT NULL,
   PRIMARY KEY (SituacaoQuartoId)
);

CREATE TABLE Quarto  (
   QuartoId int NOT NULL,
   TipoId int NOT NULL,
   SituacaoId int NOT NULL,
   PRIMARY KEY (QuartoId)
);


CREATE TABLE Cliente  (
   Cpf varchar(11) NOT NULL,
   NomeCompleto varchar(50) NOT NULL,
   DataNascimento datetime NOT NULL,
   Email varchar(50) NOT NULL,
   TelefoneCelular varchar(11) NOT NULL,
   DataCriacao datetime NOT NULL,
   PRIMARY KEY (Cpf)
);

CREATE TABLE Reserva  (
   ReservaId int NOT NULL,
   DataCriacao datetime NOT NULL,
   CheckIn datetime NULL,
   CheckOut datetime NULL,
   CpfReserva varchar(11) NOT NULL,
   HospedesJson JSON NULL,
   QuartoId int NOT NULL,
   ValorDiarias float NULL,
   TaxasConsumo float NULL,
   ValorFinal float NULL,
   PRIMARY KEY (ReservaId)
);

ALTER TABLE Quarto ADD CONSTRAINT FK_Quarto_Tipo FOREIGN KEY (TipoId) REFERENCES TipoQuarto(TipoQuartoId);

ALTER TABLE Quarto ADD CONSTRAINT FK_Quarto_Situacao FOREIGN KEY (SituacaoId) REFERENCES SituacaoQuarto (SituacaoQuartoId);

ALTER TABLE Reserva ADD CONSTRAINT FK_Reserva_Cliente FOREIGN KEY (CpfReserva) REFERENCES Cliente(Cpf);

ALTER TABLE Reserva ADD CONSTRAINT FK_Reserva_Quarto FOREIGN KEY (QuartoId) REFERENCES Quarto (QuartoId);

