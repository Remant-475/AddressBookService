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
        public bool EditContact(AddressBook address)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.EditContactdetails", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", address.FirstName);
                    command.Parameters.AddWithValue("@LastName", address.SecondName);
                    command.Parameters.AddWithValue("@Address", address.Address);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@State", address.State);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
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
                throw new AddressException(AddressException.ExceptionType.Contact_Not_Add, "not add");
                return false;
            }
        }
        public void RemoveContact(AddressBook address)
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.DeleteContactdetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", address.FirstName);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("Contact is Deleted");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetDataFromCityAndState(AddressBook address)
        {
            try
            {
                
                using (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.GetContactdetailsByCityOrState", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(@"City", address.City);
                    sqlCommand.Parameters.AddWithValue(@"State", address.State);
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
                            address.Type = reader.GetString(9);
                            address.AddressBookName = reader.GetString(10);
                            Console.WriteLine(address.ID + "," + address.FirstName + "," + address.SecondName + "," + address.Address + "," + address.City + ","
                                + address.State + "," + address.zip + "," + address.PhoneNumber + "," + address.Email + "," + address.Type + "," + address.AddressBookName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }


        }
        public void GetCountByCityOrState(AddressBook address)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SpGetCountByCityState", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                   
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            address.State = reader.GetString(0);
                            address.City = reader.GetString(1);
                            int count = reader.GetInt32(2);

                            Console.WriteLine(address.State + "  " + address.City + "  " + count);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Table is empty");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void SortContactByUsingCity(AddressBook address)
        {
            using (connection)
            {
                List<AddressBook> list = new List<AddressBook>();
                SqlCommand cmd = new SqlCommand("dbo.SortContactAlphabetically", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"City", address.City);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
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
                        address.PhoneNumber = reader.GetInt64(7);
                        address.Email = reader.GetString(8);
                        address.Type = reader.GetString(9);
                        address.AddressBookName = reader.GetString(10);
                        Console.WriteLine(address.ID + "," + address.FirstName + "," + address.SecondName + "," + address.Address + "," + address.City + ","
                            + address.State + "," + address.zip + "," + address.PhoneNumber + "," + address.Email + "," + address.Type + "," + address.AddressBookName);
                    }
                }
                else
                {
                    Console.WriteLine("No Data Found");
                }
                connection.Close();
            }
        }
        public void GetCountByContactType(AddressBook address)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.CountByContactType", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"Type", address.Type);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            
                            
                            var count = reader.GetInt32(0);


                            Console.WriteLine("No Of Contacts " + count);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Table is empty");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}








