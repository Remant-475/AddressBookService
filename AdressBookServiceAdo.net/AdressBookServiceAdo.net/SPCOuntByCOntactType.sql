USE AddressBookServiceDB
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE CountByContactType
@Type varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	select count (FirstName) no_Of_Contacts from AddressBookTable where @Type=Type
END
GO
select *from AddressBookTable