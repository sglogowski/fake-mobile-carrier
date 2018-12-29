create table dbo.Users (
	UserId int not null identity(1,1),
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	PhoneNumber varchar(9) not null,
	PESEL varchar(11) not null
)