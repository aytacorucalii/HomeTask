CREATE DATABASE LibraryDb
USE LibraryDb

CREATE TABLE Authors(
id int identity PRIMARY KEY,
name nvarchar(100),
surName nvarchar(100)
);
INSERT INTO AUTHORS( name, surName)
VALUES('AYTAC', 'ORUC');
INSERT INTO AUTHORS( name, surName)
VALUES('NUR', 'ORUC');
INSERT INTO AUTHORS( name, surName)
VALUES('Elxan', 'Elatli');


CREATE TABLE Books(
id int identity PRIMARY KEY,
AuthorId int,
name nvarchar(100) not null check(len(name)>=2),
PageCount  int not null check(PageCount>=10),
Foreign key (AuthorId) References Authors(id)
);
INSERT INTO Books
VALUES(1,'Rena', 15);
INSERT INTO Books
VALUES(2,'xeste ruhlar', 210);
INSERT INTO Books
VALUES(3,'xeste ruhlar', 210);

CREATE VIEW BookDetails_vw
as
select  b.id BookId, b.name BookName , b.PageCount, a.name AuthorName, a.surName AuthorSurName from Books b
inner join Authors a 
on b.AuthorId = a.id;

SELECT * FROM BookDetails_vw


CREATE PROCEDURE SearchBooksByAuthorOrTitle (@searchTerm nvarchar(50))
AS
BEGIN
SELECT Books.Id, Books.Name, Books.PageCount, (Authors.Name + ' ' + Authors.Surname) AS AuthorFullName FROM Books
Join Authors 
on Books.AuthorId = Authors.Id
WHERE  Books.Name LIKE '%' + @searchTerm + '%' 
or Authors.Name LIKE '%' + @searchTerm + '%';
END;
 EXEC dbo.SearchBooksByAuthorOrTitle 'AYTAC'


 CREATE FUNCTION GetBooksAbovePageCount (@MinPageCount int = 10)
RETURNS INT
as
BEGIN
DECLARE @BookCount int;
select @BookCount = COUNT(*) from Books
WHERE PageCount > @MinPageCount;
RETURN @BookCount;
END;
select  dbo.GetBooksAbovePageCount(50);