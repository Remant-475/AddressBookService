USE AddressBookServiceDB
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE SortContactAlphabetically
@City varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	select * from AddressBookTable where @City = City order by FirstName ASC
END
GO