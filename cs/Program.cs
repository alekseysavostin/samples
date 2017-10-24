using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlSample
{
    class Program
    {
        class Customer
        {
            public string CompanyName { get; set; }
            public string Id { get; set; }
        }
        const string sqlSelectCustomers = "SELECT CustomerID, CompanyName FROM Customers";

        private static IEnumerable<Customer> GetCustomers(string sqlConnectionString)
        {
            List<Customer> customers = new List<Customer>();
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);

            using (sqlConnection)
            {
                SqlCommand sqlCommand = new SqlCommand(sqlSelectCustomers, sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    {
                        Customer customer = new Customer();
                        customer.Id = (string) sqlDataReader["CustomerID"];
                        customer.CompanyName = (string) sqlDataReader["CompanyName"];
                        customers.Add(customer);
                    }
                }
            }
            return customers;
        }

        static void Main(string[] args)
        {
            //A.Insert the following code segment at line 17: while (sqlDataReader.GetValues())
            //B.Insert the following code segment at line 14: sqlConnection.Open();
            //C.Insert the following code segment at line 14: sqlConnection.BeginTransaction();
            //D.Insert the following code segment at line 17: while (sqlDataReader.Read())
            //E.Insert the following code segment at line 17: while (sqlDataReader.NextResult())
        }
    }
}
