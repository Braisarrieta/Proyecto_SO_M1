DROP DATABASE IF EXISTS BBDDM1_Poker;
CREATE DATABASE BBDDM1_Poker;
USE BBDDM1_Poker;

CREATE TABLE Usuarios (
    ID_j INT PRIMARY KEY NOT NULL,
    Nombre VARCHAR(255) NOT NULL,
    Correo VARCHAR(255) NOT NULL,
    Contraseña INT NOT NULL
) ENGINE = InnoDB;

CREATE TABLE Partidas (
    ID_partida INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Num_jug INT,
    Duracion FLOAT,
    Jugador1 INT NOT NULL,
    Jugador2 INT NOT NULL,
    Jugador3 INT NOT NULL,
    Jugador4 INT NOT NULL,
    Puntos_T1 INT,
    Puntos_T2 INT,
    FOREIGN KEY (Jugador1) REFERENCES Usuarios(ID_j),
    FOREIGN KEY (Jugador2) REFERENCES Usuarios(ID_j),
    FOREIGN KEY (Jugador3) REFERENCES Usuarios(ID_j),
    FOREIGN KEY (Jugador4) REFERENCES Usuarios(ID_j)
) ENGINE = InnoDB;

CREATE TABLE Ranking (
    ID_r INT PRIMARY KEY NOT NULL,
    Jugador INT NOT NULL,
    Partida INT NOT NULL,
    FOREIGN KEY (Jugador) REFERENCES Usuarios(ID_j),
    FOREIGN KEY (Partida) REFERENCES Partidas(ID_partida)
) ENGINE = InnoDB;

CREATE TABLE Cartas (
    ID INT PRIMARY KEY NOT NULL,
    Palo VARCHAR(30),
    Numero INT
) ENGINE = InnoDB;

INSERT INTO Usuarios(ID_j, Nombre, Correo, Contraseña)
VALUES (1, 'a', 'a', 1), (2, 'b', 'b', 2), (3, 'c', 'c', 3), (4, 'd', 'd', 4), (5, 's', 's', 5);

INSERT INTO Cartas(ID, Palo, Numero)
VALUES 
    (1, 'corazones', 1), (2, 'corazones', 2), (3, 'corazones', 3), (4, 'corazones', 4), (5, 'corazones', 5),
    (6, 'corazones', 6), (7, 'corazones', 7), (8, 'corazones', 8), (9, 'corazones', 9), (10, 'corazones', 10),
    (11, 'corazones', 11), (12, 'corazones', 12), (13, 'corazones', 13),(14, 'picas', 1), (15, 'picas', 2), (16, 'picas', 3), (17, 'picas', 4), (18, 'picas', 5),
    (19, 'picas', 6), (20, 'picas', 7), (21, 'picas', 8), (22, 'picas', 9), (23, 'picas', 10),
    (24, 'picas', 11), (25, 'picas', 12), (26, 'picas', 13),(27, 'tréboles', 1), (28, 'tréboles', 2), (29, 'tréboles', 3), (30, 'tréboles', 4), (31, 'tréboles', 5),
    (32, 'tréboles', 6), (33, 'tréboles', 7), (34, 'tréboles', 8), (35, 'tréboles', 9), (36, 'tréboles', 10),
    (37, 'tréboles', 11), (38, 'tréboles', 12), (39, 'tréboles', 13),(40, 'diamantes', 1), (41, 'diamantes', 2), (42, 'diamantes', 3), (43, 'diamantes', 4),
    (44, 'diamantes', 5), (45, 'diamantes', 6), (46, 'diamantes', 7), (47, 'diamantes', 8),
    (48, 'diamantes', 9), (49, 'diamantes', 10), (50, 'diamantes', 11), (51, 'diamantes', 12),
    (52, 'diamantes', 13);
