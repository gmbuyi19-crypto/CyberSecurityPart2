CREATE DATABASE cyberbot_db;
GO
USE cyberbot_db;
GO

CREATE TABLE tasks (
    id INT IDENTITY(1,1) PRIMARY KEY,
    title VARCHAR(150) NOT NULL,
    description VARCHAR(500) NOT NULL,
    reminder_date DATETIME NULL,
    is_completed BIT NOT NULL DEFAULT 0,
    created_at DATETIME NOT NULL DEFAULT GETDATE()
);

-- One test row so you can see it working
INSERT INTO tasks (title, description, reminder_date)
VALUES ('Enable two-factor authentication',
        'Turn on 2FA for your email and banking accounts.',
        DATEADD(DAY, 3, GETDATE()));

SELECT * FROM tasks;
