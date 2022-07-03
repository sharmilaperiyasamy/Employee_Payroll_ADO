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
    }
}
