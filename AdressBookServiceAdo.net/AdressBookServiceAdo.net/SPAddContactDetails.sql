USE [AddressBookServiceDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure Insertdetails
(
	@FirstName varchar(50),
	@SecondName varchar(50),
	@Address varchar(100),
	@City varchar(25),
	@State varchar(25),
	@Zip varchar(6),
	@PhoneNumber varchar(10),
	@Email varchar(50),
	@AddressBookName varchar(20),
	@Type varchar (10)
	)
AS
BEGIN
	SET NOCOUNT ON;
	insert into AddressBookTable(FirstName,SecondName,Address,City,State,Zip,PhoneNumber,Email,AddressBookName,Type) values (@FirstName,@SecondName,@Address,@City,@State,@Zip,@PhoneNumber,@Email,@AddressBookName,@Type)
END
GO
select * from AddressBookTable

