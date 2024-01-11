namespace oopseg{
    class iEmployeeClient{
        public static void Main(){
            Employeeinterfacce e = new Permenant();
          
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