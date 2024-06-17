-- in SQL, the -- denotes a commented line

-- DDL - Data Definition Language - Defining the structure of the data and the database
-- DML - Data Manipulation Language - Defining (and manipulating) the data withing the structure of the database
-- DQL - Data Query Language - Defining the ways we can retrieve data from the database

/*
Database
------------------------------------------------------
|   Table
|   |-----------------------------------------
|   |   entries | value 1 | value 2 | value 3
|   |   -------------------------------------
|   |   entry 1 | e1v1    | e1v2    | e1v3   
|   |   entry 2 | e2v1
|   |   entry 3 | e3v1
|   |------------------------------------------
|------------------------------------------------------



-- Keys
    -- Primary Key - a UNIQUE identifier for each entry in the table, may not be null - describes/references the entries on a table
    -- Foreign Key - a Unique identifier to reference another table from the first - lets us "connect the dots" between entries on different tables