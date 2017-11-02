DROP TABLE IF EXISTS usuarios;
DROP TABLE IF EXISTS doacoes_perguntas;
DROP TABLE IF EXISTS doacoes;
DROP TABLE IF EXISTS perguntas;
DROP TABLE IF EXISTS doadores;
DROP TABLE IF EXISTS hemocentros;


CREATE TABLE hemocentros(
	id INTEGER PRIMARY KEY IDENTITY(1, 1),
	nome VARCHAR(100) NOT NULL,
	descricao TEXT,
	estado VARCHAR(100),
	cidade VARCHAR(100),
	bairro VARCHAR(100),
	logradouro VARCHAR(100),
	numero VARCHAR(30),
	cep VARCHAR(10),
	complemento TEXT,
	data_criacao DATETIME2,
	data_alteracao DATETIME2
);

CREATE TABLE doadores(
	id INTEGER PRIMARY KEY IDENTITY(1, 1),

	id_hemocentro INTEGER NOT NULL,
	FOREIGN KEY(id_hemocentro) REFERENCES hemocentros(id),

	nome VARCHAR(100) NOT NULL,
	sobrenome VARCHAR(100) NOT NULL,
	data_nascimento DATE NOT NULL,
	tipo_sanguineo VARCHAR(6) NOT NULL,
	peso FLOAT,
	altura FLOAT,
	data_criacao DATETIME2,
	data_alteracao DATETIME2

);

CREATE TABLE perguntas(
	id INTEGER PRIMARY KEY IDENTITY(1, 1),
	nome VARCHAR(100) NOT NULL,
	resposta BIT
);

CREATE TABLE doacoes(
	id INTEGER PRIMARY KEY IDENTITY(1, 1),

	id_doador INTEGER NOT NULL,
	FOREIGN KEY(id_doador) REFERENCES doadores(id),

	aceitavel BIT,
	atendente VARCHAR(100),
	litros FLOAT,
	data DATE
);

CREATE TABLE doacoes_perguntas(
	id INTEGER PRIMARY KEY IDENTITY(1, 1),
	id_doacao INTEGER NOT NULL,
	id_pergunta INTEGER NOT NULL,
	FOREIGN KEY(id_doacao) REFERENCES doacoes(id),
	FOREIGN KEY(id_pergunta) REFERENCES perguntas(id), 

	resposta BIT NOT NULL
);

CREATE TABLE usuarios(
	id INTEGER PRIMARY KEY IDENTITY(1, 1),
	nome VARCHAR(100) NOT NULL,
	login VARCHAR(30) NOT NULL,
	senha VARCHAR(128) NOT NULL,
	privilegio VARCHAR(100) NOT NULL
);

INSERT INTO hemocentros (nome, estado, cidade, bairro, logradouro, numero, cep, data_criacao)
VALUES
('Hemosc - Blumenau', 'SC', 'Blumenau', 'Vila Nova', 'Rua Theodoro Holtrup', '40', '89035-300', '2017-06-21 22:32:21'),
('Hemepar','PR','Curitiba', 'Alto da XV', 'Travessa João Prosdócimo','145','80045-145', '2017-06-22 22:32:21');
