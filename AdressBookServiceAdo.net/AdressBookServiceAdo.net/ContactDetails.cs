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
                        address.ID = reader.GetString(0);
                        address.FirstName = reader.GetString(1);
                        address.SecondName = reader.GetString(2);
                        address.Address = reader.GetString(3);
                        address.City = reader.GetString(4);
                        address.State = reader.GetString(5);
                        address.zip = reader.GetString(6);
                        address.PhoneNumber = reader.GetString(7);
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
        public bool AddContact(AddressBook address)
        {
            try
            {
                using (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.Insertdetails", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", address.FirstName);
                    sqlCommand.Parameters.AddWithValue("@SecondName", address.SecondName);
                    sqlCommand.Parameters.AddWithValue("@Address", address.Address);
                    sqlCommand.Parameters.AddWithValue("@City", address.City);
                    sqlCommand.Parameters.AddWithValue("@State", address.State);
                    sqlCommand.Parameters.AddWithValue("@zip", address.zip);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", address.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Email", address.Email);
                    sqlCommand.Parameters.AddWithValue("@AddressBookName", address.AddressBookName);
                    sqlCommand.Parameters.AddWithValue("@Type", address.Type);
                    connection.Open();

                    var result = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                throw new AddressException(AddressException.ExceptionType.Contact_Not_Add, "Contact are not added");
            }
        }


    }
}








