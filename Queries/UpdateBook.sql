if exists (select name from sysobjects 
where name = 'UpdateBook' 
AND Type = 'P')
Drop Procedure UpdateBook 
Go

Create Procedure UpdateBook
@BookId int,
@Title varchar(50),
@ISBN varchar(20),
@PublisherName varchar(50),
@AuthorName varchar(50),
@CategoryName varchar(50)
AS

if not exists (select * from CATEGORY where CategoryName = @CategoryName)
INSERT into CATEGORY (CategoryName) values (@CategoryName)

if not exists (select * from AUTHOR where AuthorName = @AuthorName)
INSERT into AUTHOR (AuthorName) values (@AuthorName)

if not exists (select * from PUBLISHER where PublisherName = @PublisherName)
INSERT into PUBLISHER (PublisherName) values (@PublisherName)

UPDATE BOOK set 
Title = @Title,
ISBN = @ISBN,
PublisherId = (select PublisherId from PUBLISHER where PublisherName = @PublisherName),
AuthorId = (select AuthorId from AUTHOR where AuthorName = @AuthorName),
CategoryId = (select CategoryId from CATEGORY where CategoryName = @CategoryName)

where 
BookId = @BookId

Go