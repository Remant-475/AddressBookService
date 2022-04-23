--UC1-Create Database
create database AddressBookServiceDB;
-- UC2- Create Table 
create table AddressBookTable
(FirstName varchar(100),
SecondName varchar(100),
Address varchar(250),
City varchar(100),
State varchar(100),
zip BigInt,
PhoneNumber BigInt,
Email varchar(200)
)
select * from AddressBookTable

--UC3-Insert Values to Table
Insert into AddressBookTable(FirstName,SecondName,Address,City,State,zip,PhoneNumber,Email) 
values('Hemant','Mahato','Digwadih','Dhanbad','Jharkhand',828110,7979736171,'hemant402@gmail.com'),
('Remant','Mahato','Sokha Kulhi','Dhanbad','Jharkhand',828112,8271630771,'remantmahato9798@gmail.com'),
('Aman','Singh','Newtown','Kolkata','WB',700059,9798777067,'aman410@gmail.com'),
('Shubham','Singh','Adarshnagar','Patna','Bihar',847451,790348851,'shubham510@gmail.com');

select * from AddressBookTable

 --UC4-Edit Contact Person Based on their Name 
Update AddressBookTable
set Email='remant444@gmail.com'
where FirstName='Remant'

--UC5- Delete Contact Person Based on their Name 
delete from AddressBookTable
where FirstName='Remant' ;
