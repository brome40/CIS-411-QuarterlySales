namespace QuarterlySales.Models
{
    public static class Validate
    {
        public static string CheckEmployee(SalesContext context, Employee emp)
        {
            var employee = context.Employees.FirstOrDefault(e =>
                e.FirstName == emp.FirstName &&
                e.LastName == emp.LastName &&
                e.DOB == emp.DOB
            );

            if ( employee == null )
            {
                return "";
            }
            else
            {
                return $"{employee.FullName} (DOB: {employee.DOB?.ToShortDateString()}) is already in the database.";
            }
        }

        public static string CheckManagerEmployeeMatch(SalesContext context, Employee emp)
        {
            var manager = context.Employees.Find(emp.ManagerId);

            if (manager != null &&
                manager.FirstName == emp.FirstName &&
                manager.LastName == emp.LastName &&
                manager.DOB == emp.DOB)
            {
                return "Manager and employee can't be the same person.";
            }
            else
            {
                return "";
            }
        }

        public static string CheckSales(SalesContext context, Sales sl)
        {
            var sales = context.Sales.FirstOrDefault(s => 
                s.Quarter == sl.Quarter &&
                s.Year == sl.Year &&
                s.EmployeeId == sl.EmployeeId
            );

            if (sales == null)
            {
                return "";
            }
            else
            {
                var emp = context.Employees.Find(sl.EmployeeId);
                return $"Sales for {emp?.FullName} for {sl.Year} Q{sl.Quarter} are already in the database.";
            }
        }
    }
}
