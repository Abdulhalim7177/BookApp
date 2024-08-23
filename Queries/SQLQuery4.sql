create table CATEGORY(
[CategoryId] [int] primary key identity(1, 1) NOT NULL,
[CategoryName] [varchar](50) NOT NULL UNIQUE,
[Description] [varchar](1000) NOT NULL
)