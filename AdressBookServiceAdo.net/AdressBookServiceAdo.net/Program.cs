
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
                        string zip = Console.ReadLine();
                        addressBook.zip = zip;
                        Console.WriteLine("Enter PhoneNumber");
                        string PhoneNum = Console.ReadLine();
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
                }
            }
            while (option != 0);
        }
    }
}




