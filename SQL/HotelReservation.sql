SET NOCOUNT ON
GO

USE master
GO
if exists (select * from sysdatabases where name='HotelReservation')
		drop database HotelReservation
go

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE HotelReservation
  ON PRIMARY (NAME = N''HotelReservation'', FILENAME = N''' + @device_directory + N'hotelreservation.mdf'')
  LOG ON (NAME = N''HotelReservation_log'',  FILENAME = N''' + @device_directory + N'hotelreservation.ldf'')')
go

GO

set quoted_identifier on
GO

SET DATEFORMAT mdy
GO
use "HotelReservation"
go

if exists (select * from sysobjects where id = object_id('dbo.Room') and sysstat & 0xf = 3)
	drop table "dbo"."Room"
GO

if exists (select * from sysobjects where id = object_id('dbo.RoomRate') and sysstat & 0xf = 3)
	drop table "dbo"."RoomRate"
GO

if exists (select * from sysobjects where id = object_id('dbo.Customer') and sysstat & 0xf = 3)
	drop table "dbo"."Customer"
GO

if exists (select * from sysobjects where id = object_id('dbo.Promotion') and sysstat & 0xf = 3)
	drop table "dbo"."Promotion"
GO

if exists (select * from sysobjects where id = object_id('dbo.CustomerReservation') and sysstat & 0xf = 3)
	drop table "dbo"."CustomerReservation"
GO

if exists (select * from sysobjects where id = object_id('dbo.Addon') and sysstat & 0xf = 3)
	drop table "dbo"."Addon"
GO

if exists (select * from sysobjects where id = object_id('dbo.Bill') and sysstat & 0xf = 3)
	drop table "dbo"."Bill"
GO

if exists (select * from sysobjects where id = object_id('dbo.Amenities') and sysstat & 0xf = 3)
	drop table "dbo"."Amenities"
GO

if exists (select * from sysobjects where id = object_id('dbo.RoomAmenities') and sysstat & 0xf = 3)
	drop table "dbo"."RoomAmenities"
GO

if exists (select * from sysobjects where id = object_id('dbo.ReservedRooms') and sysstat & 0xf = 3)
	drop table "dbo"."ReservedRooms"
GO

if exists (select * from sysobjects where id = object_id('dbo.ReservationParty') and sysstat & 0xf = 3)
	drop table "dbo"."ReservationParty"
GO

if exists (select * from sysobjects where id = object_id('dbo.PurchasedAddon') and sysstat & 0xf = 3)
	drop table "dbo"."PurchasedAddon"
GO


CREATE TABLE Addon (
	AddonID int identity(1,1) primary key,
	AddonName nvarchar(30) not null,
	AddonPrice nvarchar(15) not null
)

CREATE TABLE Room (
	RoomID int identity(1,1) primary key,
	RoomNumber smallint not null,
	RoomFloor smallint not null,
	OccupancyLimit smallint not null,
	RoomType nvarchar(24) not null
)

CREATE TABLE PurchasedAddon (
	AddonID int foreign key references Addon(AddonID),
	RoomID int foreign key references Room(RoomID)
)

CREATE TABLE RoomRate (
	RateID int identity(1,1) primary key,
	RoomID int foreign key references Room(RoomID) null,
	RateStart datetime2 null,
	RateEnd datetime2 null,
	Rate nvarchar(15) not null
)

CREATE TABLE Customer (
	CustomerID int identity(1,1) primary key,
	FirstName nvarchar(20) not null,
	LastName nvarchar(10) not null,
	Age nvarchar(10) not null,
	Phone nvarchar(24) null,
	Email nvarchar(30) null,
	[Party] int null,
	CONSTRAINT "FK_Customer_Customer" FOREIGN KEY 
	(
		"Party"
	) REFERENCES "dbo"."Customer" (
		"CustomerID"
	),
)

CREATE TABLE Promotion (
	PromotionID int identity(1,1) primary key,
	PromotionName nvarchar(30) not null,
	PromotionStart datetime2 null,
	PromotionEnd datetime2 null,
	PromotionDiscount nvarchar(15) not null
)

CREATE TABLE CustomerReservation (
	ReservationID int identity(1,1) primary key,
	[CustomerID] int foreign key references Customer(CustomerID) not null,
	ReservationStart datetime2 not null,
	ReservationEnd datetime2 not null,
	PromotionID int foreign key references Promotion(PromotionID) null
)

CREATE TABLE ReservedRooms (
	RoomID int foreign key references Room(RoomID),
	ReservationID int foreign key references CustomerReservation(ReservationID)
)

CREATE TABLE Bill (
	BillID int identity(1,1) primary key,
	ReservationID int foreign key references CustomerReservation(ReservationID) not null,
	Tax nvarchar(15) not null,
	RoomTotal int not null,
	AddonTotal int null,
	GrandTotal int not null
)

CREATE TABLE Amenities (
	AmenityID int identity(1,1) primary key,
	AmenityName nvarchar(30) not null
)

CREATE TABLE RoomAmenities (
	AmenityID int foreign key references Amenities(AmenityID) not null,
	RoomID int foreign key references Room(RoomID) not null
)

CREATE TABLE ReservationParty (
	CustomerID int foreign key references Customer(CustomerID) not null,
	RoomID int foreign key references Room(RoomID) not null
)

GO