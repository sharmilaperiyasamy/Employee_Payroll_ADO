Employee_ADO_NET.Payroll_DB_Connection payroll = new Employee_ADO_NET.Payroll_DB_Connection();
Console.WriteLine("SQL Operations:\n0.Exit\n1.Display the data\n2.Update the data\n3.Create a new record\n4.Delete the record\nEnter your choice : ");
int choice = Convert.ToInt32(Console.ReadLine());
while (choice != 0)
{
    switch (choice)
    {
        case 1:
            payroll.getDataFromDB();
            break;
        default:
            Console.WriteLine("Enter the valid choice : ");
            break;
    }
    Console.WriteLine("SQL Operations:\n0.Exit\n1.Display the data\n2.Update the data\n3.Create a new record\n4.Delete the record\nEnter your choice : ");
    choice = Convert.ToInt32(Console.ReadLine());
}