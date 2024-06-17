-- On the Chinook DB, practice writing queries with the following exercises
USE MyDatabase;
GO

-- List all customers (full name, customer id, and country) who are not in the USA
SELECT FirstName + ' ' + LastName AS FullName, CustomerId, Country 
    FROM [Customer] 
    WHERE country != 'USA';

    -- Select, From, Where, String Concatenation with an Alias (AS)
     
--  Interesting.


-- List all customers from Brazil
SELECT * FROM Customer 
    Where Country = 'Brazil';
    -- remember that strings (VARCHAR) are single quotes!


-- List all sales agents
SELECT * 
    FROM Employee
    WHERE Title LIKE 'Sales%';

    -- use the LIKE keyword with the WHERE filtering keyword to perform a similarity search


-- Retrieve a list of all countries in billing addresses on invoices
SELECT BillingCountry
    FROM Invoice
    GROUP BY BillingCountry;

    -- GROUP BY to aggregate the results into categories.


-- Retrieve how many invoices there were in 2009, and what was the sales total for that year?
    -- (challenge: find the invoice count sales total for every year using one query)
SELECT COUNT(*) AS InvoiceCount, SUM(Total) AS InvoiceTotal FROM INVOICE
    WHERE YEAR(InvoiceDate) = 2009;
    
-- invoiceDate (need to extract just the year?)

    -- COUNT and SUM to aggregate data from a table
    -- use AS to alias a column
    -- use YEAR/MONTH/DAY to retrieve a value from a DATETIME


-- how many line items were there for invoice #37
SELECT COUNT(InvoiceLineID) AS InvoiceLines FROM InvoiceLine WHere InvoiceID = 37; 


-- SELECT COUNT(InvoiceLineID) FROM InvoiceLine WHere InvoiceID = 37; (This works too)
-- SELECT COUNT(*) FROM InvoiceLine WHere InvoiceID = 37; (This works too)


-- how many invoices per country? BillingCountry  # of invoices -
SELECT COUNT(InvoiceId) As InvoiceIdCount, BillingCountry FROM Invoice GROUP BY BillingCountry;


-- Retrieve the total sales per country, ordered by the highest total sales first.
SELECT SUM(Total) AS countrySales, BillingCountry FROM Invoice GROUP BY BillingCountry Order By countrySales DESC;

    --aggregate function with SUM()
    --GROUP By to aggregate the BillingCountry
    -- ORDER BY to sort and order the results based on total sales



-- JOINS CHALLENGES
-- Every Album by Artist
SELECT Title As AlbumTitle, Name AS ArtistName 
    FROM Album 
        INNER JOIN Artist ON Album.ArtistID = Artist.ArtistID;
                            --  Foreign Key         Primary Key

-- All songs of the rock genre
SELECT T.Name AS Track_Name, AR.Name AS Artist_Name
    FROM Track AS T
        INNER JOIN Genre AS G ON G.GenreId = T.GenreId
        JOIN Album AS AL ON T.AlbumId = AL.AlbumId -- Track to Album
        JOIN Artist AS AR ON AL.ArtistId = AR.ArtistId -- Album to Artist
    WHERE G.Name = 'Rock';


-- Show all invoices of customers from brazil (mailing address not billing)
SELECT InvoiceId AS ID, InvoiceDate, FirstName AS CustomerName
    FROM Invoice
        JOIN Customer ON Customer.CustomerId = Invoice.CustomerId
        WHERE Customer.Country = 'Brazil';

-- Tables used: Invoice and Customer?
-- Customer - CustomerId (possible join on), Country
-- Invoice - CustomerId


-- Show all invoices together with the name of the sales agent for each one
Select Employee.FirstName + ' ' + Employee.LastName AS SalesAgent, Invoice.InvoiceId
    FROM Invoice
        Join Customer ON Invoice.CustomerId = Customer.CustomerId
        Join Employee ON Employee.EmployeeId = Customer.SupportRepID; 
 
-- Invoice.CustomerId -> Customer -> Employee
-- InvoiceID, Employee ID, name:   EmployeeID, SupportRepID
-- Show all playlists ordered by the total number of tracks they have


-- Which sales agent made the most sales in 2009?

-- How many customers are assigned to each sales agent?

-- Which track was purchased the most ing 20010?

-- Show the top three best selling artists.

-- Which customers have the same initials as at least one other customer?



-- solve these with a mixture of joins, subqueries, CTE, and set operators.
-- solve at least one of them in two different ways, and see if the execution
-- plan for them is the same, or different.

-- 1. which artists did not make any albums at all?

-- 2. which artists did not record any tracks of the Latin genre?

-- 3. which video track has the longest length? (use media type table)

-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)

-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.


-- DML exercises

-- 1. insert two new records into the employee table.

-- 2. insert two new records into the tracks table.

-- 3. update customer Aaron Mitchell's name to Robert Walter

-- 4. delete one of the employees you inserted.

-- 5. delete customer Robert Walter.



--schema 
-- dbo is the default schema

-- Create Schema newschema;
-- CREATE TABLE NewTable;
-- SELECT * FROM newschema.NewTable;


SELECT * FROM dbo.Customer;

SELECT FirstName From Customer WHERE LEN(FirstName) = 6;

-- User-Defined Functions
-- Functions CAN NOT modify the data of a table, they are "read-only"
-- Only really useful for SELECT statements

Go --use GO to "batch" your statements
CREATE FUNCTION dbo.TotalNumberOfCustomers()
RETURNS INT
AS
    BEGIN  
        DECLARE @result INT;
        SELECT @result = COUNT(*) FROM dbo.Customer;
        RETURN @result;
    END
GO

SELECT dbo.TotalNumberOfCustomers();

SELECT COUNT(*) FROM dbo.Customer;


GO
CREATE FUNCTION dbo.CustomersWithFirstNameLengthOf( @length INT )
RETURNS TABLE -- Stored / user defined functions can return an entire table
AS
    RETURN( SELECT * FROM dbo.Customer WHERE LEN(FirstName) = @length);
GO

-- use the select statement on the return from the function, because IT IS A TABLE!
SELECT FirstName FROM dbo.CustomersWithFirstNameLengthOf(7);


-- Stored Procedures are similar to a function, except that they CAN modify the database.
GO
CREATE OR ALTER PROCEDURE dbo.UpdateAllCustomers(@postalcode INT, @modified INT OUTPUT) -- use OUTPUT as a parameter to take the place of a RETURN
AS
BEGIN
    BEGIN TRY
        IF (NOT EXISTS (SELECT * FROM dbo.Customer))
        BEGIN
            RAISERROR ('No data found in table',15, 1);
        END
        SET @modified = (SELECT COUNT(*) FROM dbo.Customer);
        UPDATE dbo.Customer SET PostalCode = @postalcode;
    END TRY
    BEGIN CATCH
        PRINT 'ERROR'
    END CATCH
END
GO


SELECT PostalCode FROM dbo.Customer;

DECLARE @result INT;
EXECUTE dbo.UpdateAllCustomers 98765, @result OUTPUT;
SELECT @result;

SELECT PostalCode FROM dbo.Customer;


-- Triggers

-- Some code that will run instead of, or after
-- you insert, update, or delete to a specified table

GO
CREATE TRIGGER Playlist.DateModified ON Playlist.Name
AFTER UPDATE
AS
    BEGIN
        UPDATE Playlist.Name
        SET DateModified = SYSUTCDATETIME() -- the SQL way to retireve the current system date time convert to the UTC region
        WHERE Id IN (SELECT Id FROM Inserted) --triggers get access to two special table-valued variables, Inserted and Deleted.
    END
GO

GO
CREATE TRIGGER PreventDelete ON dbo.Playlist
INSTEAD OF DELETE
AS
    BEGIN TRY
    BEGIN
        RAISERROR('Delete not authorized', 15, 1)
    END
    END TRY
    BEGIN CATCH
        PRINT 'ERROR'
    END CATCH
GO
