USE GuildCars
GO

IF EXISTS(
	SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
	WHERE ROUTINE_NAME = 'StateSelectAll')
		DROP PROCEDURE StateSelectAll
GO

CREATE PROCEDURE StateSelectAll
AS
BEGIN
	SELECT *
	FROM [State]
END
GO

IF EXISTS(
	SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
	WHERE ROUTINE_NAME = 'StateSelectByID')
		DROP PROCEDURE StateSelectByID
GO

CREATE PROCEDURE StateSelectByID(@SearchID varchar(2))
AS
BEGIN
	SELECT *
	FROM [State]
	WHERE @SearchID = StateID
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ColorSelectAll')
		DROP PROCEDURE ColorSelectAll
GO

CREATE PROCEDURE ColorSelectAll 
AS
BEGIN
	SELECT *
	FROM Color
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ColorSelectByID')
		DROP PROCEDURE ColorSelectByID
GO

CREATE PROCEDURE ColorSelectByID(@SearchID int) 
AS
BEGIN
	SELECT *
	FROM Color
	WHERE ColorID = @SearchID
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodySelectAll')
		DROP PROCEDURE BodySelectAll
GO

CREATE PROCEDURE BodySelectAll 
AS
BEGIN
	SELECT *
	FROM BodyStyle
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodySelectByID')
		DROP PROCEDURE BodySelectByID
GO

CREATE PROCEDURE BodySelectByID(@SearchID int) 
AS
BEGIN
	SELECT *
	FROM BodyStyle
	WHERE BodyStyleID = @SearchID
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeSelectAll')
		DROP PROCEDURE MakeSelectAll
GO

CREATE PROCEDURE MakeSelectAll 
AS
BEGIN
	SELECT *
	FROM Make
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeSelectByID')
		DROP PROCEDURE MakeSelectByID
GO

CREATE PROCEDURE MakeSelectByID(@SearchID int) 
AS
BEGIN
	SELECT *
	FROM Make
	WHERE MakeID = @SearchID
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelSelectAll')
		DROP PROCEDURE ModelSelectAll
GO

CREATE PROCEDURE ModelSelectAll 
AS
BEGIN
	SELECT *
	FROM Model
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelSelectByID')
		DROP PROCEDURE ModelSelectByID
GO

CREATE PROCEDURE ModelSelectByID(@SearchID int) 
AS
BEGIN
	SELECT *
	FROM Model
	WHERE ModelID = @SearchID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelSelectByMakeID')
		DROP PROCEDURE ModelSelectByMakeID
GO

CREATE PROCEDURE ModelSelectByMakeID(@SearchID int) 
AS
BEGIN
	SELECT *
	FROM Model
	WHERE MakeID = @SearchID
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SalesTypeSelectAll')
		DROP PROCEDURE SalesTypeSelectAll
GO

CREATE PROCEDURE SalesTypeSelectAll 
AS
BEGIN
	SELECT *
	FROM SalesType
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SalesTypeSelectByID')
		DROP PROCEDURE SalesTypeSelectByID
GO

CREATE PROCEDURE SalesTypeSelectByID(@SearchID int) 
AS
BEGIN
	SELECT *
	FROM SalesType
	WHERE SalesTypeID = @SearchID
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialSelectAll')
		DROP PROCEDURE SpecialSelectAll
GO

CREATE PROCEDURE SpecialSelectAll 
AS
BEGIN
	SELECT *
	FROM Special
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialSelectByID')
		DROP PROCEDURE SpecialSelectByID
GO

CREATE PROCEDURE SpecialSelectByID(@SearchID int) 
AS
BEGIN
	SELECT *
	FROM Special
	WHERE SpecialID = @SearchID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransmissionSelectAll')
		DROP PROCEDURE TransmissionSelectAll
GO

CREATE PROCEDURE TransmissionSelectAll 
AS
BEGIN
	SELECT *
	FROM Transmission
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransmissionSelectByID')
		DROP PROCEDURE TransmissionSelectByID
GO

CREATE PROCEDURE TransmissionSelectByID(@SearchID int) 
AS
BEGIN
	SELECT *
	FROM Transmission
	WHERE TransmissionID = @SearchID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleSelectAll')
		DROP PROCEDURE VehicleSelectAll
GO

CREATE PROCEDURE VehicleSelectAll 
AS
BEGIN
	SELECT *
	FROM Vehicle
	WHERE IsSold = 0
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleSelectFeatured')
		DROP PROCEDURE VehicleSelectFeatured
GO

CREATE PROCEDURE VehicleSelectFeatured 
AS
BEGIN
	SELECT TOP 15 *
	FROM Vehicle
	WHERE IsFeatured = 1
	AND IsSold = 0;
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleSelectByID')
		DROP PROCEDURE VehicleSelectByID
GO

CREATE PROCEDURE VehicleSelectByID(@SearchID int) 
AS
BEGIN
	SELECT *
	FROM Vehicle
	WHERE VehicleID = @SearchID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleSelectUsed')
		DROP PROCEDURE VehicleSelectUsed
GO

CREATE PROCEDURE VehicleSelectUsed
AS
BEGIN
	SELECT *
	FROM Vehicle
	WHERE IsNew = 0
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleSelectNew')
		DROP PROCEDURE VehicleSelectNew
GO

CREATE PROCEDURE VehicleSelectNew
AS
BEGIN
	SELECT *
	FROM Vehicle
	WHERE IsNew = 1
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleInsert')
		DROP PROCEDURE VehicleInsert
GO

CREATE PROCEDURE VehicleInsert( @VehicleID int OUTPUT,
			@VehicleYear int, @MakeID int, @ModelID int, 
			@BodyStyleID int, @TransmissionID int, @ColorID int, 
			@InteriorID int, @Mileage int, 
			@VIN nvarchar(30), @Price int, @MSRP int, 
			@IsFeatured bit, @IsNew bit, @IsSold bit, 
			@VehicleDescription nvarchar(1000)) 
	AS
	BEGIN
	INSERT INTO Vehicle( VehicleYear, MakeID, ModelID, BodyStyleID, TransmissionID, ColorID, InteriorID, Mileage, VIN, 
			Price, MSRP, IsFeatured, IsNew, IsSold, VehicleDescription)
	VALUES(@VehicleYear, @MakeID, @ModelID, @BodyStyleID, @TransmissionID, @ColorID, @InteriorID, @Mileage, @VIN, @Price, @MSRP, 
			@IsFeatured, @IsNew, @IsSold, @VehicleDescription)
	SET @VehicleID = SCOPE_IDENTITY();
	END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleUpdate')
		DROP PROCEDURE VehicleUpdate
GO

CREATE PROCEDURE VehicleUpdate( @VehicleID int,
			@VehicleYear int, @MakeID int, @ModelID int, 
			@BodyStyleID int, @TransmissionID int, @ColorID int, 
			@InteriorID int, @Mileage int, 
			@VIN nvarchar(30), @Price int, @MSRP int, 
			@IsFeatured bit, @IsNew bit, @IsSold bit, 
			@VehicleDescription nvarchar(1000)) 
	AS
	BEGIN
	UPDATE Vehicle SET 
		VehicleYear = @VehicleYear, 
		MakeID = @MakeID, 
		ModelID = @ModelID, 
		BodyStyleID = @BodyStyleID, 
		TransmissionID = @TransmissionID, 
		ColorID = @ColorID, 
		InteriorID = @InteriorID, 
		Mileage = @Mileage, 
		VIN = @VIN, 
		Price = @Price, 
		MSRP = @MSRP, 
		IsFeatured = @IsFeatured, 
		IsNew = @IsNew, 
		IsSold = @IsSold, 
		VehicleDescription = @VehicleDescription
	WHERE VehicleID = @VehicleID
	END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleDelete')
		DROP PROCEDURE VehicleDelete
GO

CREATE PROCEDURE VehicleDelete(@VehicleID int) AS
BEGIN
	BEGIN TRANSACTION
	
	DELETE FROM Sales WHERE VehicleID = @VehicleID;
	DELETE FROM Vehicle WHERE VehicleID = @VehicleID;

	COMMIT TRANSACTION
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UserSelectAll')
		DROP PROCEDURE UserSelectAll
GO

CREATE PROCEDURE UserSelectAll 
AS
BEGIN
	SELECT Id, FirstName, LastName, UserRole, Email
	FROM AspNetUsers
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UserSelectByID')
		DROP PROCEDURE UserSelectByID
GO

CREATE PROCEDURE UserSelectByID(@UserID nvarchar(128)) 
AS
BEGIN
	SELECT Id, FirstName, LastName, UserRole, Email
	FROM AspNetUsers
	WHERE Id = @UserID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialInsert')
		DROP PROCEDURE SpecialInsert
GO

CREATE PROCEDURE SpecialInsert( @SpecialName nvarchar(50), @SpecialDescription nvarchar(1000)) 
AS
BEGIN
	INSERT INTO Special(SpecialName, SpecialDescription)
	VALUES(@SpecialName, @SpecialDescription)
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialDelete')
		DROP PROCEDURE SpecialDelete
GO

CREATE PROCEDURE SpecialDelete( @SpecialID int) 
AS
BEGIN
	DELETE FROM Special
	WHERE SpecialID = @SpecialID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeInsert')
		DROP PROCEDURE MakeInsert
GO

CREATE PROCEDURE MakeInsert( @MakeName nvarchar(30), @DateCreated nvarchar(30), @UserCreated nvarchar(50)) 
AS
BEGIN
	INSERT INTO Make(MakeName, DateCreated, UserCreated)
	VALUES(@MakeName, @DateCreated, @UserCreated)
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelInsert')
		DROP PROCEDURE ModelInsert
GO

CREATE PROCEDURE ModelInsert( @ModelName nvarchar(30), @MakeID int, @DateCreated nvarchar(30), @UserCreated nvarchar(50)) 
AS
BEGIN
	INSERT INTO Model(ModelName, MakeID, DateCreated, UserCreated)
	VALUES(@ModelName, @MakeID, @DateCreated, @UserCreated)
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactInsert')
		DROP PROCEDURE ContactInsert
GO

CREATE PROCEDURE ContactInsert(@ContactName nvarchar(60), @ContactEmail nvarchar(60), @ContactPhone nvarchar(15), @ContactReason nvarchar(1000)) 
AS
BEGIN
	INSERT INTO Contact(ContactName, ContactEmail, ContactPhone, ContactReason)
	VALUES(@ContactName, @ContactEmail, @ContactPhone, @ContactReason)
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseInsert')
		DROP PROCEDURE PurchaseInsert
GO

CREATE PROCEDURE PurchaseInsert(@VehicleID int, @UserID nvarchar(128), @CustomerName nvarchar(50), 
								@CustomerPhone nvarchar(14), @CustomerEmail nvarchar(50), @CustomerAdd1 nvarchar(50), @CustomerAdd2 nvarchar(50), 
								@City nvarchar(50), @StateID nvarchar(2), @Zipcode int, 
								@SalesPrice int, @SalesTypeID int, @SalesDate nvarchar(20)) 
	AS
	BEGIN
	INSERT INTO Sales(VehicleID, UserID, CustomerName, CustomerPhone, CustomerEmail, CustomerAdd1, CustomerAdd2, City, StateID, 
			Zipcode, SalesPrice, SalesTypeID, SalesDate)
	VALUES(@VehicleID, @UserID, @CustomerName, @CustomerPhone, @CustomerEmail, @CustomerAdd1, @CustomerAdd2, @City, @StateID, @Zipcode, @SalesPrice, @SalesTypeID, 
			@SalesDate)
	UPDATE Vehicle SET
		IsSold = 1
		WHERE VehicleID = @VehicleID
	END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InvReportNew')
		DROP PROCEDURE InvReportNew
GO

CREATE PROCEDURE InvReportNew 
AS
BEGIN
	SELECT COUNT(*) AS [Count],
		   VehicleYear,
		   MakeID,
		   ModelID,
		   SUM(MSRP) AS [Value]
	FROM Vehicle v
	WHERE IsNew = 1 AND IsSold = 0
	GROUP BY VehicleYear, MakeID, ModelID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InvReportUsed')
		DROP PROCEDURE InvReportUsed
GO

CREATE PROCEDURE InvReportUsed 
AS
BEGIN
	SELECT COUNT(*) AS [Count],
		   VehicleYear,
		   MakeID,
		   ModelID,
		   SUM(MSRP) AS [Value]
	FROM Vehicle v
	WHERE IsNew = 0 AND IsSold = 0
	GROUP BY VehicleYear, MakeID, ModelID
END
GO