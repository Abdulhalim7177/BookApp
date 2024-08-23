if exists (select name from sysobjects 
where name = 'DeleteBook'
AND type = 'P')
DROP procedure DeleteBook
GO

Create procedure DeleteBook 
@BookId int 
AS
delete from BOOK where BookId = @BookId
Go

