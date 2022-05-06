
using System;

namespace AdressBookServiceAdo.net
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in Address Book System Ado.Net");
            ContactDetails details = new ContactDetails();
            int option = 0;
            do
            {
                Console.WriteLine("1: For Establish Connection");
                Console.WriteLine("2: For Close Connection");
                Console.WriteLine("3: Get all details from AddressBook");
                Console.WriteLine("4: Add Contact Details ");
                Console.WriteLine("5: Edit ContactDetails");
                Console.WriteLine("6: Delete ContactDetails");
                Console.WriteLine("7: GetDetails By City Or State");
                Console.WriteLine("8: Get count by City or State");
                Console.WriteLine("0: For Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        details.EstablishConnection();
                        Console.WriteLine("Connection is Open");
                        break;
                    case 2:
                        details.CloseConnection();
                        Console.WriteLine("Connection is closed");
                        break;
                    case 3:
                        details.GetContactDetails();
                        break;
                    case 4:
                        AddressBook addressBook = new AddressBook();
                        Console.WriteLine("Enter First Name");
                        string FirstName = Console.ReadLine();
                        addressBook.FirstName = FirstName;
                        Console.WriteLine("Enter Last Name");
                        string SecondName = Console.ReadLine();
                        addressBook.SecondName = SecondName;
                        Console.WriteLine("Enter Address");
                        string Address = Console.ReadLine();
                        addressBook.Address = Address;
                        Console.WriteLine("Enter City");
                        string City = Console.ReadLine();
                        addressBook.City = City;
                        Console.WriteLine("Enter state");
                        string state = Console.ReadLine();
                        addressBook.State = state;
                        Console.WriteLine("Enter Zip");
                        int zip = int.Parse(Console.ReadLine());
                        addressBook.zip = zip;
                        Console.WriteLine("Enter PhoneNumber");
                        Int64 PhoneNum = Int64.Parse(Console.ReadLine());
                        addressBook.PhoneNumber = PhoneNum;
                        Console.WriteLine("Enter Email");
                        string Email = Console.ReadLine();
                        addressBook.Email = Email;
                        Console.WriteLine("Enter a Address Book Name");
                        string AddressBookName = Console.ReadLine();
                        addressBook.AddressBookName = AddressBookName;
                        Console.WriteLine("Enter ContactType");
                        string ContactTypeName = Console.ReadLine();
                        addressBook.Type = ContactTypeName;

                        details.AddContact(addressBook);
                        Console.WriteLine("New Contact is Added");
                        break;
                    case 5:
                        AddressBook addressbook = new AddressBook();
                        Console.WriteLine("Enter a First Name for Edit Contact");
                        string firstname = Console.ReadLine();
                        addressbook.FirstName = firstname;
                        Console.WriteLine("Edit Last Name");
                        string lastname = Console.ReadLine();
                        addressbook.SecondName = lastname;
                        Console.WriteLine("Edit Address");
                        string address = Console.ReadLine();
                        addressbook.Address = address;
                        Console.WriteLine("Edit City");
                        string city = Console.ReadLine();
                        addressbook.City = city;
                        Console.WriteLine("Edit State");
                        string State = Console.ReadLine();
                        addressbook.State = State;
                        details.EditContact(addressbook);
                        Console.WriteLine("Contact is Edited");
                        break;
                    case 6:
                        AddressBook delete = new AddressBook();
                        Console.WriteLine("Enter a First Name For Delete The Contact");
                        string first_name = Console.ReadLine();
                        delete.FirstName = first_name;
                        details.RemoveContact(delete);
                        break;
                    case 7:
                        AddressBook getData = new AddressBook();
                        Console.Write("Enter the City Name:-");
                        string cityname = Console.ReadLine();
                        getData.City = cityname;
                        Console.Write("Enter the State Name:-");
                        string statename = Console.ReadLine();
                        getData.State = statename;
                        details.GetDataFromCityAndState(getData);
                        break;
                    case 8:AddressBook book=new AddressBook();
                        details.GetCountByCityOrState(book);
                        break;
                }
            }
            while (option != 0);
        }
    }
}




