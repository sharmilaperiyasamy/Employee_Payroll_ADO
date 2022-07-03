Employee_ADO_NET.Payroll_DB_Connection payroll = new Employee_ADO_NET.Payroll_DB_Connection();
Console.WriteLine("SQL Operations:\n0.Exit\n1.Display the data\n2.Create a new record\n3.Update the data\n4.Delete the record\nEnter your choice : ");
int choice = Convert.ToInt32(Console.ReadLine());
while (choice != 0)
{
    switch (choice)
    {
        case 1:
            payroll.getDataFromDB();
            break;
        case 2:
            payroll.createRecord();
            break;
        case 3:
            payroll.updateBasicPay();
            break;
        case 4:
            payroll.deleteRecord();
            break;
        default:
            Console.WriteLine("Enter the valid choice : ");
            break;
    }
    Console.WriteLine("SQL Operations:\n0.Exit\n1.Display the data\n2.Create a new record\n3.Update the data\n4.Delete the record\nEnter your choice : ");
    choice = Convert.ToInt32(Console.ReadLine());
}