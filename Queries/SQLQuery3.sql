create table PUBLISHER(
PublisherId int primary key identity (1, 1) NOT NULL,
PublisherName varchar(50) NOT NULL,
[Description] varchar(1000) NULL,
[Address] varchar(50) NULL,
Phone varchar(50) NULL,
PostCode varchar(50) NULL,
PostAddress varchar(50) NULL,
Email varchar(50) NULL,
)