create table AUTHOR(
[AuthorId] [int] identity(1, 1) NOT NULL primary key,
[AuthorName] [varchar](50) NOT NULL,
[Address] [varchar](50) NOT NULL,
[Phone] [varchar](50) NOT NULL,
[PostCode] [varchar](50) NOT NULL,
[PostAddress] [varchar](50) NOT NULL
)