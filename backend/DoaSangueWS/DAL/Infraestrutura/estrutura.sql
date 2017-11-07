DROP TABLE IF EXISTS usuarios;
DROP TABLE IF EXISTS doacoes;
DROP TABLE IF EXISTS perguntas;
DROP TABLE IF EXISTS doadores;
DROP TABLE IF EXISTS hemocentros;


CREATE TABLE hemocentros(
	id INTEGER PRIMARY KEY IDENTITY(1, 1),
	nome VARCHAR(100) NOT NULL,
	descricao TEXT,
	estado VARCHAR(2),
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
	tipo_sanguineo SMALLINT NOT NULL,
	fator_rh BIT NOT NULL,
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

	status INT NOT NULL,
	atendente VARCHAR(100) NOT NULL,
	litros FLOAT NOT NULL,

	data_criacao DATETIME2 NOT NULL,
	data_alteracao DATETIME2
);

CREATE TABLE usuarios(
	id INTEGER PRIMARY KEY IDENTITY(1, 1),
	nome VARCHAR(100) NOT NULL,
	sobrenome VARCHAR(100) NOT NULL,
	login VARCHAR(30) NOT NULL,
	senha VARCHAR(128) NOT NULL,
	privilegio SMALLINT NOT NULL,
	data_nascimento DATETIME2 NOT NULL,
	data_criacao DATETIME2,
	data_alteracao DATETIME2
);

INSERT INTO hemocentros (nome, estado, cidade, bairro, logradouro, numero, cep, data_criacao)
VALUES
('Hemosc - Blumenau', 'SC', 'Blumenau', 'Vila Nova', 'Rua Theodoro Holtrup', '40', '89035-300', '2017-06-21 22:32:21'),
('Hemepar','PR','Curitiba', 'Alto da XV', 'Travessa João Prosdócimo','145','80045-145', '2017-06-22 22:32:21'),
('Hemosc - Xanxerê', 'SC', 'Xanxerê', 'Centro', 'Rua Cel Passos Maia', '234', '89820-000', '2017-06-21 22:32:21'),
('Hemepar','PR','Telêmaco Borba', 'Jardim Alegre', 'Rua Monte Horebe','129','84268-494', '2017-06-22 22:32:21'),
('Hemopar','PR', 'Pato Branco', 'Vila Isabel', 'Rua Pedro Soares', '982', '85504-317', '2017-06-21 22:32:21'),
('Banco de Sangue','RS','Uruguaiana', 'União das Vilas', 'Quadra A','551','97509-590', '2017-06-22 22:32:21'),
('Hemonúcleo', 'AC', 'Rio Branco', 'Bosque', 'Rua Manoel Cassiano', '659', '69900-436', '2017-06-21 22:32:21');


INSERT INTO usuarios(nome, sobrenome, login, senha, privilegio, data_nascimento, data_criacao)
VALUES 
/* senha doasanguefran */
('Francisco', 'Lucas Sens', 'francisco', 'DA5490266F0B0B75D031AE4C2E7AC02D709D391F2DDBA2263A91E655EB8F11C7F3A4EBBA411FABDB8F84ED8F5BE7FE9DC59A7077D4E8DBC1CE89E9AC2E8FB8DA', 1, '1994-06-04 23:59:59', '2017-11-02 16:29:30.07'),
/* senha doasanguetof */
('Thiago', ' Tofolo', 'tofolo', 'E048301BC1D415743C46FFB936A04B1816B76839BD6A1BCFDBA2C5BAA17B27CA37E466BC658D04B304D44D75E3FA7AAC53AB75E0778FFD3C1AEF8E78693CDB8B', 2, '1985-04-01 23:59:59', '2017-11-02 16:29:30.07');

INSERT INTO doadores (id_hemocentro, nome, sobrenome, data_nascimento, tipo_sanguineo, fator_rh, peso, altura, data_criacao)
VALUES
(1, 'Pedro', 'Vargineo', '1980-12-25 21:54:48', 2, 1, 95.300, 1.74, '2017-11-01 22:54:12'),
(1, 'Guilherme', 'Enrico Gabriel Martins', '1995-09-08 21:54:48', 1, 0, 62.000, 1.64, '2017-11-01 22:54:12'),
(1, 'Kaique', 'Lucca Freitas', '1972-01-12 21:54:48', 3, 1, 88.600, 1.76, '2017-11-01 22:54:12'),
(2, 'Brenda', 'Caroline Kamilly Rodrigues', '1990-07-04 21:54:48', 3, 0, 58.400, 1.60, '2017-11-01 22:54:12'),
(2, 'Cecília', 'Lara Ribeiro', '1984-02-21 21:54:48', 1, 0, 83.100, 1.85, '2017-11-01 22:54:12'),
(3, 'Valentina', 'Nascimento', '1987-12-06 21:54:48', 2, 1, 67.300, 1.70, '2017-11-01 22:54:12'),
(4, 'Nicolas', 'Pedro Castro', '1976-11-14 21:54:48', 4, 1, 97.400, 1.84, '2017-11-01 22:54:12'),
(5, 'Nicole', 'Yasmin Jennifer Costa', '1995-10-27 21:54:48', 2, 1, 57.000, 1.61, '2017-11-01 22:54:12'),
(6, 'Emily', 'Souza', '1965-09-16 21:54:48', 3, 0, 90.300, 1.64, '2017-11-01 22:54:12'),
(7, 'Julio', 'Fernandes', '1978-02-07 21:54:48', 1, 1, 90.600, 1.84, '2017-11-01 22:54:12'),
(3, 'Diogo', 'Iago Moura', '1986-05-29 21:54:48', 4, 1, 73.000, 1.74, '2017-11-01 22:54:12'),
(1, 'Bruna', 'Barros', '1990-10-05 21:54:48', 3, 0, 73.300, 1.78, '2017-11-01 22:54:12');

INSERT INTO doacoes (id_doador, litros, atendente, status, data_criacao)
VALUES
(1, 0.320, 'Lucia da Silva', 3, '2016-05-21 20:15:24');