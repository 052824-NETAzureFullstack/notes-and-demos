CREATE DATABASE MyDatabase;

/* 
docker container - memory/CPU -> running processes
DB Server - the logical side, the processing behind a db
Data Base - is JUST the orgainzation and storage of the data

we communicate to the server, the SERVER does all the heavy lifting and deals with the data-stuff.
    then returns a response.

ADS -> Docker Container(DB Server) 
*/

-- DQL - how we talk to the SERVER (and the server knows what to look in the database for)
SELECT 'Hello World'; -- strings in SQL are only single-quote ''
-- SELECT always returns a table
select 2; -- keywords are NOT case sensitive, but it helps make it readable (for me at least)
SELECT 2 + 2; -- the server is pretty powerfull, and kinda smart!
SELECT SYSUTCDATETIME();

-- use SELECT to specify that we want a response
-- use FROM to specify where we want the response to gater data from
SELECT * FROM [dbo].[Artist];
SELECT * FROM [dbo].[Customer];

-- use WHERE to filter a response
SELECT *
    FROM Customer
    WHERE Country = 'Canada'
        AND City = 'Vancouver'; 

-- Aggregate functions - the server is going to do some math for us!
SELECT COUNT(*)
    FROM Customer;

SELECT SUM(Total)
    FROM Invoice;

-- SELECT can be specific!
SELECT CustomerId, FirstName
    FROM Customer;

SELECT *
    FROM Invoice
    WHERE CustomerId = 15;

SELECT CustomerID, COUNT(Total)
    FROM Invoice
    GROUP BY CustomerId;

SELECT CustomerId, SUM(Total) AS Sum_Total
    FROM Invoice
    WHERE BillingCountry != 'USA'
    GROUP BY CustomerId
    HAVING SUM(Total) > 40
    ORDER BY Sum_Total DESC, CustomerId;

-- logical order of operations:

-- FROM
-- WHERE
-- GROUP BY
-- HAVING
-- SELECT
-- ORDER BY


-- JOINS - joins are way to retrieve information/entries that are related from across multiple tables
-- Multiplicity - the relationships between tables
-- all relationships in a database are based on the keys - primary and foreign
-- 1 to 1 - for every entry on table A, there is one and only one related entry on table B
-- 1 to many - for every entry on table A, there are one or many related entries on table B
-- many to many - for many entries on table A there, there are many related entries on table B

/*
1 to 1

1 - Z
2 - Y
3 - W
4 - X

1 to many
1 - A, Z
2 - B, Y
3 - C, W
4 - D, X

many to many 
Table A, Table B
1, 9 - A, Z
2, 8 - B, Y
3, 7 - C, W
4, 6 - D, X

Table A - Table C - Table B
many    to  one, one   to   many
Table C is the Linking Table


JOIN statements have several flavors:
INNER
OUTER
Left/Right
CROSS
