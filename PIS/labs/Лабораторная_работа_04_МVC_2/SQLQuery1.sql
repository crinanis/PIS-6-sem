use PhoneBook;

create table PhoneBook
(
	id int identity(1,1),
	surname nvarchar(50),
	phoneNumber nvarchar(13)
)

insert into PhoneBook values ('Nikolaeva', '+375297456648');
drop table PhoneBook;
select*from PhoneBook;