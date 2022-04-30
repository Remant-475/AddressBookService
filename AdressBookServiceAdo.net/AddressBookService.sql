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

-- UC6- Retrieve Person belonging to a City or State
select * from AddressBookTable
where City='Dhanbad' or State='Jharkhand'

-- UC 7: Ability to Retrieve Count of Person belonging to a City or State
Insert into AddressBookTable(FirstName,SecondName,Address,City,State,zip,PhoneNumber,Email) 
values('Sachin','Pratap','Sakchi','Jamshedpur','Jharkhand',835205,7903466210,'Sachin963@gmail.com')
select Count(*) as Number_of_People,State,City 
from AddressBookTable
Group by State,City

-- UC 8:  Retrieve Person retrieve entries sorted alphabetically by Person’s name by City
select * from AddressBookTable
where City='kolkata'
order by(FirstName)

------ UC 9: Identify each Address Book with name andType ------

alter table AddressBookTable
add AddressBookName varchar(100),
Type varchar(100)

--Update values for Type=Friends--
update AddressBookTable
set AddressBookName='FriendName',Type='Friends'
where FirstName='Aman' or FirstName='Sachin' or  FirstName='Shubham' 

--Update values for Type=Profession--
update AddressBookTable
set AddressBookName='FamilyName',Type='Family'
where FirstName='Hemant'

-- UC10- Get number of contact persons by Type
Select Count(*) as Number_Of_Contacts,Type
from AddressBookTable
Group by Type

--UC11-- Add person to friend and family
insert into AddressBookTable(FirstName, SecondName, Address, City, State, Zip, PhoneNumber, Email, AddressBookName,Type)
values
('Rahul', 'Mahato', 'Ashoknagar', 'Ahmedabad', 'Gujarat', 382002, 9572846335, 'rahulmahato123@gmail.com','FriendBook', 'Friend'),
('Kumud', 'Kumari', 'Bidhannagar', 'Durgapur', 'WB', 713212, 790456123, 'kumud963@gmail.com', 'FamilyBook','Family');
select * from AddressBookTable;
select Address_BookName,Concat(FirstName,' ',SecondName) as Name,Concat(Address,' ,',City,' ,',State,' ,',zip) as Address,PhoneNumber,Email,ContactType_Name
from Address_Book 



--ERDiagram

Full JOIN Contact_Person on Address_Book.Address_BookID=AddressBook_ID 
Full JOIN TypeManager on TypeManager.Contact_Identity=Contact_ID
Full JOIN ContactType on TypeManager.ContactType_Identity=ContactType_ID



select Address_BookName,Concat(FirstName,' ',SecondName) as Name,Concat(Address,' ,',City,' ,',State,' ,',zip) as Address,PhoneNumber,Email,ContactType_Name
from Address_Book 
Full JOIN Contact_Person on Address_Book.Address_BookID=AddressBook_ID 
Full JOIN TypeManager on TypeManager.Contact_Identity=Contact_ID
Full JOIN ContactType on TypeManager.ContactType_Identity=ContactType_ID

------  UseCase 12------  

-- 1: Ability to Retrieve Person belonging to a City or State --

select Address_BookName,Concat(FirstName,' ',SecondName) as Name,Concat(Address,' ,',City,' ,',State,' ,',zip) as Address,PhoneNumber,Email,ContactType_Name
from Contact_Person 
INNER JOIN  Address_Book on Address_Book.Address_BookID=AddressBook_ID and (City='Bangalore' or State='Karnataka')
INNER JOIN TypeManager on TypeManager.Contact_Identity=Contact_ID
INNER JOIN ContactType on TypeManager.ContactType_Identity=ContactType_ID

------ 2: Ability to Retrieve Count of Person belonging to a City or State ------

select Count(*),state,City
from Contact_Person 
INNER JOIN  Address_Book on Address_Book.Address_BookID=AddressBook_ID 
Group by state,City

------ 3: Ability to retrieve entries sorted alphabetically ------

select Address_BookName,(FirstName+' '+SecondName) as Name,Concat(Address,' ,',City,' ,',State,' ,',zip) as Address,PhoneNumber,Email,ContactType_Name
from Contact_Person 
INNER JOIN  Address_Book on Address_Book.Address_BookID=AddressBook_ID and (City='Bangalore')
INNER JOIN TypeManager on TypeManager.Contact_Identity=Contact_ID
INNER JOIN ContactType on TypeManager.ContactType_Identity=ContactType_ID
order by(FirstName)

------ 4: Ability to get number of contact persons by Type------

select Count(*) as NumberOfContacts,ContactType.ContactType_Name
from Contact_Person 
INNER JOIN  Address_Book on Address_Book.Address_BookID=AddressBook_ID
INNER JOIN TypeManager on TypeManager.Contact_Identity=Contact_ID
INNER JOIN ContactType on TypeManager.ContactType_Identity=ContactType_ID
Group by ContactType_Name

