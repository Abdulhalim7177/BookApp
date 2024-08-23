if exists (select name	from sysobjects 
where name = 'CreateBook'
and type = 'P')

Drop procedure CreateBook
Go

Create Procedure CreateBook 
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

if not exists (select * from BOOK where Title = @Title)
INSERT into BOOK (Title, ISBN, PublisherId, AuthorId, CategoryId) 
values
(
@Title,
@ISBN,
(select PublisherId from PUBLISHER where PublisherName = @PublisherName),
(select AuthorId from AUTHOR where AuthorName = @AuthorName),
(select CategoryId from CATEGORY where CategoryName = @CategoryName)
)
GO