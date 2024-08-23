insert into BOOK (Title, ISBN, PublisherId, AuthorId, CategoryId)
values 
(
'Introduction To Computer System',
'12-23-4522222-2',
(select PublisherId from PUBLISHER where PublisherName = 'Mukhtar Ibrahim'),
(select AuthorId from AUTHOR where AuthorName = 'Munneer Ammani'),
(select CategoryId from CATEGORY where CategoryName = 'Programming')
)

GO

insert into BOOK (Title, ISBN, PublisherId, AuthorId, CategoryId)
values 
(
'General Physics',
'67676767-2222-2',
(select PublisherId from PUBLISHER where PublisherName = 'Ahmad Yusuf'),
(select AuthorId from AUTHOR where AuthorName = 'Nura Zubair'),
(select CategoryId from CATEGORY where CategoryName = 'Science')
)

insert into BOOK (Title, ISBN, PublisherId, AuthorId, CategoryId)
values 
(
'History of Africa',
'1332-23-42222-2',
(select PublisherId from PUBLISHER where PublisherName = 'Hashim Bashir'),
(select AuthorId from AUTHOR where AuthorName = 'Munneer Ammani'),
(select CategoryId from CATEGORY where CategoryName = 'History')
)

insert into BOOK (Title, ISBN, PublisherId, AuthorId, CategoryId)
values 
(
'The New World',
'122-23-452222-2',
(select PublisherId from PUBLISHER where PublisherName = 'Umar Yahaya'),
(select AuthorId from AUTHOR where AuthorName = 'Muhammad Sarki'),
(select CategoryId from CATEGORY where CategoryName = 'Novels')
)