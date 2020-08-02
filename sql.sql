create database SurveyDatabase
go
create table EmailData
(Id int primary key identity(1,1),
EmailAddress varchar(200),
EmailSent bit not null default(0),
SentDate datetime not null default('1900-01-01'),
IsViewed bit not null default(0))
go

--insert into emaildata (EmailAddress) values ('sridhargiri1@gmail.com'),('sridhargiri1@gmail.com'),('sridhargiri1@gmail.com'),('sridhargiri1@gmail.com'),('sridhargiri1@gmail.com'),('sridhargiri1@gmail.com')

select * from EmailData
--update EmailData set emailaddress='sridhargiri1@gmail.com'
--update EmailData set sentdate='2020-08-02 00:00:00.000' where id=2