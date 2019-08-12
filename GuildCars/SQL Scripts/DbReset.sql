USE GuildCars
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DbReset')
		DROP PROCEDURE DbReset
GO
CREATE PROCEDURE DbReset AS
BEGIN

	DELETE FROM Sales;
	DELETE FROM Vehicle;
	DELETE FROM Transmission;
	DELETE FROM [State];
	DELETE FROM Special;
	DELETE FROM SalesType;
	DELETE FROM Model;
	DELETE FROM Make;
	DELETE FROM Contact;
	DELETE FROM Color;
	DELETE FROM BodyStyle;
	DELETE FROM AspNetUsers;




	SET IDENTITY_INSERT BodyStyle ON;
	INSERT INTO BodyStyle(BodyStyleID, Body)
	VALUES
		(1, 'Car'),
		(2, 'Truck'),
		(3, 'SUV'),
		(4, 'Van')
	SET IDENTITY_INSERT BodyStyle OFF;

	SET IDENTITY_INSERT Color ON;
	INSERT INTO Color (ColorID, VehicleColor)
	VALUES
		(1, 'Red'),
		(2, 'Yellow'),
		(3, 'Blue')
	SET IDENTITY_INSERT Color OFF;
	
	SET IDENTITY_INSERT Contact ON;
	INSERT INTO Contact (ContactID, ContactName, ContactEmail, ContactPhone, ContactReason)
	VALUES
		(1, 'Paul', 'Paul@test.com', '888-888-8888', 'Need new car'),
		(2, 'Samantha', 'Samantha@test.com', '555-555-5555', 'Quote wanted on truck'),
		(3, 'Phil', 'Phil@test.com', '333-333-3333', 'Want to trade vehicle')

	SET IDENTITY_INSERT Contact OFF;

	SET IDENTITY_INSERT Make ON;
	INSERT INTO Make (MakeID, MakeName, UserCreated, DateCreated)
	VALUES
		(1, 'Ford', 'test1@test.com', '1-1-2019'),
		(2, 'Toyota', 'test1@test.com', '1-1-2019'),
		(3, 'Hyundai', 'test1@test.com', '1-1-2019')
	SET IDENTITY_INSERT Make OFF;
	
	SET IDENTITY_INSERT Model ON;
	INSERT INTO Model (ModelID, ModelName, MakeID,  UserCreated, DateCreated)
	VALUES
		(1, 'Mustang', 1, 'test1@test.com', '1-1-2019'),
		(2,'Explorer', 1, 'test1@test.com', '1-1-2019'),
		(3, 'Fiesta', 1, 'test1@test.com', '1-1-2019'),
		(4, 'Camry', 2, 'test1@test.com', '1-1-2019'),
		(5, 'Prius', 2, 'test1@test.com', '1-1-2019'),
		(6, 'Corolla', 2, 'test1@test.com', '1-1-2019'),
		(7, 'Optima', 3, 'test1@test.com', '1-1-2019'),
		(8, 'Sorento', 3, 'test1@test.com', '1-1-2019'),
		(9, 'Soul', 3, 'test1@test.com', '1-1-2019')
	SET IDENTITY_INSERT Model OFF;

	SET IDENTITY_INSERT SalesType ON;
	INSERT INTO SalesType (SalesTypeID, SalesTypeName)
	VALUES
		(1, 'Bank Finance'),
		(2, 'Dealer Finance'),
		(3, 'Cash')
	SET IDENTITY_INSERT SalesType OFF;
	
	SET IDENTITY_INSERT Special ON;
	INSERT INTO Special (SpecialID, SpecialName, SpecialDescription)
	VALUES
		(1, 'Cash Back', 'Get cash back on your purchase!'),
		(2, 'Free TV', 'Free 60in HD 4K TV with vehicle purchase!'),
		(3, '0% Intrest Financing', 'No interest for the first year when you finance with us!')
	SET IDENTITY_INSERT Special OFF;
	
	INSERT INTO [State](StateID, StateName)
		VALUES	('OH', 'Ohio'), 
		('KY', 'Kentucky'), 
		('MN', 'Minnesota')

	SET IDENTITY_INSERT Transmission ON;
	INSERT INTO Transmission (TransmissionID, TransmissionType)
	VALUES
		(1, 'Manual'),
		(2, 'Automatic')
	SET IDENTITY_INSERT Transmission OFF;

	SET IDENTITY_INSERT Vehicle ON;
	INSERT INTO Vehicle (VehicleID, VehicleYear, MakeID, ModelID, BodyStyleID, TransmissionID, ColorID, InteriorID, Mileage, VIN, Price,
				MSRP, IsFeatured, IsNew, IsSold, VehicleDescription)
	VALUES 
		(1, 2000, 1, 1, 1, 1, 1, 1, 3000, 'TestVIN', 3000, 2800, 0, 0, 0, 'Car'),
		(2, 2001, 1, 1, 1, 1, 1, 1, 3000, 'TestVIN', 3000, 2800, 0, 0, 1, 'Car'),
		(3, 2002, 1, 1, 1, 1, 1, 1, 3000, 'TestVIN', 3000, 2800, 0, 1, 0, 'Car'),
		(4, 2003, 1, 1, 1, 1, 1, 1, 3000, 'TestVIN', 3000, 2800, 1, 0, 0, 'Car'),
		(5, 2004, 1, 1, 1, 1, 1, 1, 3000, 'TestVIN', 3000, 2800, 1, 1, 0, 'Car'),
		(6, 2005, 1, 1, 1, 1, 1, 1, 3000, 'TestVIN', 3000, 2800, 1, 1, 1, 'Car')
	SET IDENTITY_INSERT Vehicle OFF;

END