namespace oopseg{
    class EmployeeClient{
        public static void Main(){
            Employee e = new Permenant();
          
            e.AcceptDetails();
            e.CalculateSalary();
            e.DisplayDetails();
            e= new Trainee();
            e.AcceptDetails();
            e.DisplayDetails();
            e.CalculateSalary();
        }
    }
}