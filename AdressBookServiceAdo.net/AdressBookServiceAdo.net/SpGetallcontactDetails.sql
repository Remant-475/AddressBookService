USE [AddressBookServiceDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE GetallDetails
	As
Begin
SELECT ID,FirstName,SecondName,Address,City,State,Zip,PhoneNumber,Email,AddressBookNAme,Type
FROM AddressBookTable

END
select * from AddressBookTable

delete from AddressBookTable where FirstName='Remant'