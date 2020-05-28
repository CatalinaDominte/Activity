create database "Activity"
use "Activity"

create table "Players" (
PlayerID int identity (1,1) primary key,
PlayerName nvarchar(50) not null)
insert into "Players" (PlayerName)
values ('Catalin'),('Catalina'),('Andreea'), ('Veronica')

create table Teams(
TeamsID int identity(1,1) primary key,
TeamName nvarchar(50) not null,
Score int default 0)
alter table Teams
ADD  players nvarchar(250) null
select * from Teams

create table History(
historyID int identity (1,1) primary key,
 DateGame date not null,
 TeamsID int foreign key references Teams(TeamsId))

 create table Words (
WordsID int identity (1,1) primary key,
Word nvarchar(50) not null,
PlayerID int foreign key references Players(PlayerID)
)
select * from Teams



