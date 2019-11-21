create database IBA;

use IBA;

create table books (
	bookID int primary key auto_increment not null,
    bookName nvarchar(20),
    bookPages int not null);
    
    
insert into books(bookName, bookPages)
values ('MiddleBook', 100),
		('BigBook', 3000),
        ('DirectX', 15)

    