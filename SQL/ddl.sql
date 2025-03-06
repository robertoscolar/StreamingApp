CREATE TABLE [users] (
    id INT IDENTITY(1,1) PRIMARY KEY,
    full_name NVARCHAR(255) NULL,
    email NVARCHAR(255) NULL,
    password NVARCHAR(255) NULL,
	role NVARCHAR(255) NULL
);

CREATE TABLE [content] (
    id INT IDENTITY(1,1) PRIMARY KEY,
    title NVARCHAR(255) NULL,
    type NVARCHAR(50) NULL,
    user_id INT NULL,
    FOREIGN KEY (user_id) REFERENCES [user](id)
);

CREATE TABLE [playlist] (
    id INT IDENTITY(1,1) PRIMARY KEY,
    title NVARCHAR(255) NULL,
    user_id INT NULL,
    created_at DATETIME,
    updated_at DATETIME NULL,
    FOREIGN KEY (user_id) REFERENCES [user](id)
);

CREATE TABLE [playlist_content] (
    playlist_id INT,
    content_id INT,
    PRIMARY KEY (playlist_id, content_id),
    FOREIGN KEY (playlist_id) REFERENCES [playlist](id),
    FOREIGN KEY (content_id) REFERENCES [content](id)
);