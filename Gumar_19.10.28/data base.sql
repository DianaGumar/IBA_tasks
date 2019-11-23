create database RandomBase;
use RandomBase;

create table a ( aID int primary key not null auto_increment,
				aName nvarchar(10) not null);
                
create table b ( bID int primary key not null auto_increment,
				bName nvarchar(10) not null,
                aID int );

alter table b add foreign key (aID)
	references a (aID) on delete cascade;
