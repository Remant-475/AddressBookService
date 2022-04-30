USE [AddressBookServiceDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE DeleteContactdetails
(
	@FirstName varchar(50)
	)
	
AS
BEGIN

	SET NOCOUNT ON;
	delete from AddressBookTable where FirstName=@FirstName
	End
	select * from AddressBookTable