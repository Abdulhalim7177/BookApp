if exists (select name From sysobjects 
where name = 'GetBookData'
AND Type = 'V')
Drop VIEW GetBookData
Go

Create View GetBookData
AS

SELECT
BOOK.BookId,
BOOk.AuthorName,
BOOK.Title,
BOOK.ISBN,
PUBLISHER.PublisherName,
CATEGORY.CategoryName

from BOOK

inner join AUTHOR On BOOK.AuthorId = AUTHOR.AuthorId
inner join PUBLISHER On BOOK.PublisherId = PUBLISHER.PublisherId
inner join CATEGORY On BOOK.CategoryId = CATEGORY.CategoryId

GO