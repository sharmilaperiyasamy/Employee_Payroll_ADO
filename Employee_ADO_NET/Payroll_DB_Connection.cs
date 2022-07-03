using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Employee_ADO_NET
{
    internal class Payroll_DB_Connection
    {
        public static string connectionString = "Data Source = DESKTOP-VMLSH89\\SQLEXPRESS;Database = payroll_service;Trusted_Connection=true";

        //uc2 to get the data from database

        public void getDataFromDB()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            Employee_Profile profile = new Employee_Profile();
            using (connection)
            {
                connection.Open();
                string query = "Select * from employee_payroll";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("Id\tName\tSalary\t\tstartdate\t\tgender\tphoneno\t\tdepartment\taddress\tbasic_pay\tdeductions\tTaxable_pay\tincome_tax\tnet_pay");
                    while (reader.Read())
                    {
                        profile.id = reader.GetInt32(0);
                        profile.name = reader.GetString(1);
                        profile.salary = reader.GetDecimal(2);
                        profile.startdate = reader.GetDateTime(3);
                        profile.gender = reader.GetString(4);
                        profile.phone_no = reader.GetString(5);
                        profile.department = reader.GetString(6);
                        profile.address = reader.GetString(7);
                        profile.basic_pay = reader.GetDecimal(8);
                        profile.deductions = reader.GetDecimal(9);
                        profile.taxable_pay = reader.GetDecimal(10);
                        profile.income_tax = reader.GetDecimal(11);
                        profile.net_pay = reader.GetDecimal(12);
                        Console.WriteLine(profile.id + "\t" + profile.name + "\t" + profile.salary + "\t" + profile.startdate + "\t" + profile.gender + "\t" +
                            profile.phone_no + "\t" + profile.department + "\t" + profile.address + "\t" + profile.basic_pay + "\t" + profile.deductions + "\t" + profile.taxable_pay + "\t" + profile.income_tax + "\t" + profile.net_pay);
                    }
                }
                else
                {
                    Console.WriteLine("No records in database.");
                }
                reader.Close();
                connection.Close();
            }
        }
        //uc3-create a new record in database
        public void createRecord()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                Employee_ADO_NET.Employee_Profile profile = new Employee_ADO_NET.Employee_Profile();
                Console.WriteLine("Name of the employee: ");
                profile.name = Console.ReadLine();
                Console.WriteLine("Salary of the Employee : ");
                profile.salary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter the startdate : ");
                profile.startdate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Gender : ");
                profile.gender = Console.ReadLine();
                Console.WriteLine("Phone number : ");
                profile.phone_no = Console.ReadLine();
                Console.WriteLine("Department : ");
                profile.department = Console.ReadLine();
                Console.WriteLine("Address of the Employee : ");
                profile.address = Console.ReadLine();
                Console.WriteLine("Basic Pay : ");
                profile.basic_pay = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Deductions : ");
                profile.deductions = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Taxable_pay : ");
                profile.taxable_pay = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Income_tax : ");
                profile.income_tax = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Net_pay : ");
                profile.net_pay = Convert.ToDecimal(Console.ReadLine());
                SqlCommand command = new SqlCommand("SpAddEmployeeDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", profile.name);
                command.Parameters.AddWithValue("@salary", profile.salary);
                command.Parameters.AddWithValue("@startdate", profile.startdate);
                command.Parameters.AddWithValue("@gender", profile.gender);
                command.Parameters.AddWithValue("@phone_no", profile.phone_no);
                command.Parameters.AddWithValue("@department", profile.department);
                command.Parameters.AddWithValue("@address", profile.address);
                command.Parameters.AddWithValue("@basic_pay", profile.basic_pay);
                command.Parameters.AddWithValue("@deductions", profile.deductions);
                command.Parameters.AddWithValue("@taxable_pay", profile.taxable_pay);
                command.Parameters.AddWithValue("@income_tax", profile.income_tax);
                command.Parameters.AddWithValue("@net_pay", profile.net_pay);
                command.ExecuteNonQuery();
                Console.WriteLine("Records are created successfully.");
                connection.Close();
            }
        }
        //uc4 update basicpay

        public void updateBasicPay()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    Console.WriteLine("Enter the name of the Employee to update the basic pay:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the basic pay to update:");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());
                    connection.Open();
                    string query = "update employee_payroll set salary =" + salary + "where name='" + name + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Records updated successfully.");
                }
                connection.Close();
            }
            catch (FormatException)
            {
                Console.WriteLine("-------------------\nError:Records are not updated.\n-----------------");
            }
        }
        //uc5 delete the record
        public void deleteRecord()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                Console.WriteLine("Enter the name of the Employee to delete the record from database.");
                string name = Console.ReadLine();
                string query = "delete from employee_payroll where name='" + name + "'";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Records are deleted successfully.");
                connection.Close();
            }
        }
    }
}
