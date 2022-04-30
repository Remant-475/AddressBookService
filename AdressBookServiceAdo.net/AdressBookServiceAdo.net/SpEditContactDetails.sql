USE [AddressBookServiceDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE EditContactdetails
(
	@FirstName varchar(50),
	@LastName varchar(50),
	@Address varchar(200),
    @City varchar(50),
    @State varchar(50))
AS
BEGIN

	SET NOCOUNT ON;
	update AddressBookTable set SecondName = @LastName,Address = @Address, City = @City, State = @State where FirstName = @FirstName;
	End