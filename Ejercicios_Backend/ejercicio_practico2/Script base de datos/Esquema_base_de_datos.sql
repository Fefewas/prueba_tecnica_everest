
CREATE DATABASE ejercicio_practico2;

USE ejercicio_practico2;

CREATE TABLE clientes (
    id INT PRIMARY KEY AUTO_INCREMENT,
	nombre VARCHAR(255) NOT NULL,
	edad INT NOT NULL
);

INSERT INTO clientes (nombre, edad)
VALUES ('Paula Vásquez', 20),
       ('Jonnathan Perdomo', 21),
       ('Calors Daniel', 21);