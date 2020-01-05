USE GuildCars
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='Sales')
	DROP TABLE Sales
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicle')
	DROP TABLE Vehicle
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Model')
	DROP TABLE Model
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
	DROP TABLE Make
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyStyle')
	DROP TABLE BodyStyle
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Transmission')
	DROP TABLE Transmission
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Color')
	DROP TABLE Color
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Special')
	DROP TABLE Special
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='State')
	DROP TABLE [State]
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='SalesType')
	DROP TABLE SalesType
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Contact')
	DROP TABLE Contact
GO


CREATE TABLE Make(
	MakeID int identity(1,1) not null primary key,
	MakeName nvarchar(20) not null,
	UserCreated nvarchar(128) null,
	DateCreated nvarchar(20) null
)

CREATE TABLE Model(
	ModelID int identity(1,1) not null primary key,
	MakeID int not null foreign key references Make(MakeID) ,
	ModelName nvarchar(20) not null,
	UserCreated nvarchar(128) null,
	DateCreated nvarchar(20) null
)

CREATE TABLE BodyStyle(
	BodyStyleID int identity(1,1) not null primary key,
	Body nvarchar(20) not null
)

CREATE TABLE Transmission(
	TransmissionID int identity(1,1) not null primary key,
	TransmissionType nvarchar(20) not null
)

CREATE TABLE Color(
	ColorID int identity(1,1) not null primary key,
	VehicleColor nvarchar(20) not null
)

CREATE TABLE [State](
	StateID nvarchar(2) not null primary key,
	StateName nvarchar(20) not null
)

CREATE TABLE Vehicle (
	VehicleID int identity(1,1) not null primary key,
	[VehicleYear] int not null,
	MakeID int not null foreign key references Make(MakeID),
	ModelID int not null foreign key references Model(ModelID),
	BodyStyleID int not null foreign key references BodyStyle(BodyStyleID),
	TransmissionID int not null foreign key references Transmission(TransmissionID),
	ColorID int not null foreign key references Color(ColorID),
	InteriorID int not null foreign key references Color(ColorID),
	Mileage int not null,
	VIN nvarchar(30) not null,
	Price int not null,
	MSRP int not null,
	IsFeatured bit null,
	IsNew bit null,
	IsSold bit null,
	VehicleDescription nvarchar(1500) not null
)

CREATE TABLE SalesType(
	SalesTypeID int identity(1,1) not null primary key,
	SalesTypeName nvarchar(28) not null
)

CREATE TABLE Sales(
	SaleID int identity(1,1) not null primary key,
	UserID nvarchar(128) not null foreign key references AspNetUsers(ID),
	VehicleID int not null foreign key references Vehicle(VehicleID),
	StateID nvarchar(2) not null foreign key references State(StateID),
	SalesTypeID int not null foreign key references SalesType(SalesTypeID),
	CustomerName nvarchar(50) not null,
	CustomerPhone nvarchar(14) null,
	CustomerEmail nvarchar(50) null,
	CustomerAdd1 nvarchar(50) not null,
	CustomerAdd2 nvarchar(50) null,
	City nvarchar(50) not null,
	Zipcode int not null,
	SalesPrice int not null,
	SalesDate nvarchar(20) not null
)

CREATE TABLE Special(
	SpecialID int identity(1,1) not null primary key,
	SpecialName nvarchar(50) not null,
	SpecialDescription nvarchar(1000) not null
)

CREATE TABLE Contact(
	ContactID int identity(1,1) not null primary key,
	ContactName nvarchar (50) not null,
	ContactEmail nvarchar (50) null,
	ContactPhone nvarchar(14) null,
	ContactReason nvarchar (1500) not null
)