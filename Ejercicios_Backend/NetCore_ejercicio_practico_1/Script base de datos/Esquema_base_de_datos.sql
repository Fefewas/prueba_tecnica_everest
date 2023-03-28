
CREATE DATABASE ejercicio_practico1;

USE ejercicio_practico1;

CREATE TABLE IF NOT EXISTS productos (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(255) NOT NULL,
    descripcion TEXT
);

-- Se insertan datos iniciales para que la tabla no esté vacia 
INSERT INTO productos (nombre, descripcion)
VALUES ('Producto 1', 'Primer producto'),
       ('Producto 2', 'Segundo producto'),
       ('Producto 3', 'Tercer producto');