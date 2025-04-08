--ddl
CREATE TABLE [usuario] (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    senha VARCHAR(255) NOT NULL,
);

CREATE TABLE [criador] (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(255) NOT NULL
);

CREATE TABLE [conteudo] (
    id INT IDENTITY(1,1) PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    tipo VARCHAR(50) NOT NULL,
    criador_id INT NOT NULL,
    FOREIGN KEY (criador_id) REFERENCES [criador](id)
);

CREATE TABLE [playlist] (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    usuario_id INT NOT NULL,
    criado_em DATETIME NOT NULL,
    atualizado_em DATETIME NULL,
    FOREIGN KEY (usuario_id) REFERENCES [usuario](id)
);

CREATE TABLE [item_playlist] (
    playlist_id INT,
    conteudo_id INT,
    PRIMARY KEY (playlist_id, conteudo_id),
    FOREIGN KEY (playlist_id) REFERENCES [playlist](id),
    FOREIGN KEY (conteudo_id) REFERENCES [conteudo](id)
);

--dml
INSERT INTO usuario(nome, email, senha) 
VALUES ('admin', 'admin@unip.com.br', 'ccf394566353d3b647d65aeed09ad6dff40bb6f9b7363b623af4de795b7d47a9'); --senha !SenhaForte123