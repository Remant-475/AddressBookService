using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace AdressBookServiceAdo.net
{
    public class ContactDetails
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog =AddressBookServiceDB; Integrated Security = True;";
        static SqlConnection connection = new SqlConnection(connectionString);
        public void EstablishConnection()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    throw new AddressException(AddressException.ExceptionType.Connection_Failed, "connection failed");

                }

            }
        }
        public void CloseConnection()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Open))
            {
                try
                {
                    connection.Close();
                }
                catch (Exception)
                {
                    throw new AddressException(AddressException.ExceptionType.Connection_Failed, "connection failed");
                }
            }
        }
        public List<AddressBook> GetContactDetails()
        {
            List<AddressBook> contactlist = new List<AddressBook>();
            AddressBook address = new AddressBook();
            SqlConnection connection = new SqlConnection(connectionString);
            string Spname = "dbo.GetallDetails";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(Spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        address.ID = reader.GetInt32(0);
                        address.FirstName = reader.GetString(1);
                        address.SecondName = reader.GetString(2);
                        address.Address = reader.GetString(3);
                        address.City = reader.GetString(4);
                        address.State = reader.GetString(5);
                        address.zip = (int)reader.GetInt64(6);
                        address.PhoneNumber = (int)reader.GetInt64(7);
                        address.Email = reader.GetString(8);
                        address.AddressBookName = reader.GetString(9);
                        address.Type = reader.GetString(10);
                        Console.WriteLine(address.FirstName + "," + address.SecondName + "," + address.PhoneNumber + "," + address.Email + "," + address.City);

                    }
                }
                connection.Close();
            }
            return contactlist;

        }
        
    }
}








