USE [AddressBookServiceDB]
GO
/****** Object:  StoredProcedure [dbo].[GetContactdetailsByCityOrState]    Script Date: 04-05-2022 07:21:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetContactdetailsByCityOrState]
(
	@City varchar(50),
	@State varchar(30)
	)
	
AS
BEGIN

	SET NOCOUNT ON;
select * from AddressBookTable where City=@City and State=@State
End