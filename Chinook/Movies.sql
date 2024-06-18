-- DDL Data Definition Language
-- CREATE, ALTER, DROP


-- Server - CPU
    -- Databases - memory in structure
        -- Schemas - logical separation
            -- Tables - organization of data

/*
CREATE DATABASE MovieDB;
GO

CREATE SCHEMA Movie;
GO

CREATE TABLE Movie.Movie (
    --Every field of the table will need: Name, DataType, References, Constraints
    -- Name DataType, Constraints/References
    MovieID INT NOT NULL
);
GO

SELECT * FROM Movie.Movie;
GO

-- Alter will allow us to modify an  existing table
ALTER TABLE Movie.Movie ADD
    Title NVARCHAR(200) NOT NULL;
GO

-- Drop removes the entire structure from the memory
DROP TABLE Movie.Movie;
GO
*/

/*
-- Constraints
- NOT NULL - enforcing that a field must have a value
- NULL - (generally for documentation in the code) we allow a field to be null
- UNIQUE - the field cannot have any duplicate values (we can set multiple or combined fields to be unique)
- Primary Key - enforces UNIQUE and NOT NULL, and set a cluster index
- Foreign Key - allows for CASCADE behavior - ON DELETE CASCADE, ON UPDATE CASCADE
- DEFAULT - assign a default value to a field if it is not specified
- CHECK - enforce a boolean expression to validate an entry. it is compared on every insert or update
- IDENTITY(start=1, increment=1) - automatically increments with every entry. Particularly usefull when using an integer as a primary key!
*/



/*
-- DROP STATEMENTS ------------
DROP TABLE Movie.ActorMovie;
DROP TABLE Movie.Actor;
ALTER TABLE Movie.Movie DROP CONSTRAINT FK_Movie_Genre;
DROP TABLE Movie.Movie;
DROP TABLE Movie.Genre;
DROP SCHEMA Movie;
DROP DATABASE MovieDB;
GO
*/

CREATE DATABASE MovieDB;
GO

USE MovieDB;
GO

CREATE SCHEMA Movie;
GO

CREATE TABLE Movie.Movie (
    MovieId INT IDENTITY PRIMARY KEY, -- UNIQUE, NOT NULL
    Title NVARCHAR(200) NOT NULL,
    ReleaseDate DATE NOT NULL,
    Active BIT NOT NULL DEFAULT(1),
    CONSTRAINT U_Title_ReleaseDate UNIQUE (Title, ReleaseDate),
    CONSTRAINT CK_ReleaseDateNotTooEarly CHECK (ReleaseDate > '1900')
);
GO

CREATE TABLE Movie.Genre(
    GenreId INT NOT NULL IDENTITY,
    Name NVARCHAR(200) NOT NULL UNIQUE,
    Active BIT NOT NULL DEFAULT(1)
);
GO

ALTER TABLE Movie.Genre ADD
    CONSTRAINT PK_GenreId PRIMARY KEY (GenreId);
GO

ALTER TABLE Movie.Movie ADD
    GenreId INT NOT NULL DEFAULT(1),
    CONSTRAINT FK_Movie_Genre FOREIGN KEY (GenreId)
        REFERENCES Movie.Genre (GenreId)
        ON DELETE CASCADE;
GO

/*
Make an Actor table with:
- First and Last names that must be a unique combination
- an ID that is a primary KEY
*/

CREATE TABLE Movie.Actor(
    ActorId INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    CONSTRAINT U_FirstName_LastName UNIQUE (FirstName, LastName)
);
GO

/*
Create a many-to-many reference between actors and movies with an Actor_Movie table:
- each entry should have an actor reference and a movie reference
*/

CREATE TABLE Movie.ActorMovie(
    ID INT IDENTITY PRIMARY KEY,
    MovieId INT NOT NULL FOREIGN KEY REFERENCES Movie.Movie (MovieId) ON DELETE CASCADE ON UPDATE CASCADE,
    ActorId INT NOT NULL FOREIGN KEY REFERENCES Movie.Actor (ActorId) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

/*
    Actor           Actor/Movie         Movie
    1               1   /   2           1
    2               1   /   3           2
    3               2   /   3           3
    4               4   /   4           4
*/

SELECT * FROM Movie.Movie;
SELECT * FROM Movie.Genre;
SELECT * FROM Movie.Actor;
SELECT * FROM Movie.ActorMovie;
GO

-- DML Data Manipulation Language 
-- INSERT, UPDATE, DELETE

INSERT INTO Movie.Genre (Name) VALUES
    ('Action'),
    ('Drama'),
    ('Mystery'),
    ('Comedy');
GO

INSERT INTO Movie.Movie (Title, ReleaseDate, GenreId) VALUES
    ('Avengers: Endgame', '2019', (SELECT GenreId FROM Movie.Genre WHERE Name = 'Action')),
    ('Joker', '2019', 2),
    ('Citizen Kane', '1941', 3);
GO

INSERT INTO Movie.Actor (FirstName, LastName) VALUES
    ('David', 'Tennant'),
    ('Sean', 'Connery'),
    ('Scarlet', 'Johansen'),
    ('Robert', 'Downey'),
    ('Robert', 'De Niro'),
    ('Joaquin', 'Phoenix'),
    ('Chris', 'Evans'),
    ('Chris', 'Hemsworth');
GO

INSERT INTO Movie.ActorMovie (MovieId, ActorId) VALUES
    ((SELECT MovieId FROM Movie.Movie WHERE Title = 'Avengers: Endgame'),(SELECT ActorId FROM Movie.Actor WHERE FirstName = 'Chris' AND LastName = 'Evans')),
    (2,8),
    (2,4),
    (2,3),
    (3,6),
    (3,5),
    (3,1),
    (3,2),
    (2,1),
    (2,5);
GO

SELECT M.Title, A.FirstName + ' ' + A.LastName AS 'Actor Name'
    FROM Movie.Movie AS M
        JOIN Movie.ActorMovie AS AM ON AM.MovieId = M.MovieId
        JOIN Movie.Actor AS A ON AM.ActorId = A.ActorId
        ORDER BY M.Title;
GO

UPDATE Movie.Movie
    SET Title = 'Endgame' -- SET will act on EVERY matching field
    WHERE Title = 'Avengers: Endgame'; -- Use WHERE to filter to a specific entry or set of entries
GO

DELETE FROM Movie.ActorMovie -- DELETE will work similarly to UPDATE, deleting the data of a table 
    WHERE Id = 14;
GO

TRUNCATE TABLE Movie.ActorMovie; -- empties the rows (entries)
GO