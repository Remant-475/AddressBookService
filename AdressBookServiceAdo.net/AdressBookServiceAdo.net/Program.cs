
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
                   
                }
            }
            while (option != 0);
        }
    }
}




