-- DDL Data Definition Language
-- CREATE, ALTER, DROP


-- Server - CPU
    -- Databases - memory in structure
        -- Schemas - logical separation
            -- Tables - organization of data

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
    CONSTRAINT U_FirstNamr_LastName UNIQUE (FirstName, LastName)
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


SELECT * FROM Movie.Movie;
SELECT * FROM Movie.Genre;
SELECT * FROM Movie.Actor;
SELECT * FROM Movie.ActorMovie;