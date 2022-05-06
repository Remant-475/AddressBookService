create or alter procedure SpGetCountByCityState
as
begin
Select state,city,Count(ID) as No_Of_Peoples from AddressBookTable  group by city,state
end

select * from AddressBookTable