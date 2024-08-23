create table BOOK (
BookId int primary key identity (1, 1) NOT NULL,
Tittle varchar(50) NOT NULL UNIQUE,
ISBN varchar(20) NOT NULL,
AuthorId int NOT NULL foreign key references [AUTHOR] ([AuthorId]) ,
PublisherId int NOT NULL foreign key  references [PUBLISHER] ([PublisherId]),
CategoryId int NOT NULL foreign key references [CATEGORY] ([CategoryId]),
[Description] varchar(1000),
[Year] [Date] NULL,
[Edition] int NULL,
AverageRating [Float] NULL,
)