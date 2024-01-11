namespace oopseg{
    class Employeeinterfacce{
        public int Empid{get;set;}
        public string? empname{get;set;}
        public float salary{get;set;}
        public DateTime DOJ{get;set;}

        public virtual void AcceptDetails(){
            Console.WriteLine("Enter Name");
            empname = Console.ReadLine();
            Console.WriteLine("Enter EMP ID");
            Empid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Salary");
            salary = float.Parse(Console.ReadLine());
            Console.WriteLine("DOJ?");
            DOJ = Convert.ToDateTime(Console.ReadLine());
        }

         public virtual void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {Empid}");
            Console.WriteLine($"Employee Name: {empname}");
            Console.WriteLine($"Salary: {salary}");
            Console.WriteLine($"Date of Joining: {DOJ.ToShortDateString()}");
        }
        
        public virtual void CalculateSalary(){
            
        }
    }

    class Permenant: Employeeinterfacce, iEmployee{
        public float Basicpay{get;set;}
        public float HRA{get;set;}
        public float DA{get;set;}
        public float PF{get;set;}

        public void AcceptDetails(){
            base.AcceptDetails();
            Console.WriteLine("Basic Pay");
            Basicpay= float.Parse(Console.ReadLine());
            Console.WriteLine("HRA");
            HRA= float.Parse(Console.ReadLine());
            Console.WriteLine("DA");
            DA= float.Parse(Console.ReadLine());
            Console.WriteLine("PF");
            PF= float.Parse(Console.ReadLine());

        }
            public override void CalculateSalary()
        {
           float totalSalary = Basicpay+HRA+DA+PF;
           Console.WriteLine("Permenant Employee Salary: "+totalSalary);
        }
        public void DisplayDetails(){
            base.DisplayDetails();
             Console.WriteLine($"Basic Pay: {Basicpay}");
            Console.WriteLine($"HRA: {HRA}");
            Console.WriteLine($"DA: {DA}");
            Console.WriteLine($"PF: {PF}");
            


        }
    }

    class Trainee:Employeeinterfacce, iEmployee{
        public float bonus{get;set;}
        public string ProjectName{get;set;}

        public void AcceptDetails(){
            base.AcceptDetails();
            Console.WriteLine("Bonus");
            bonus = float.Parse(Console.ReadLine());
            Console.WriteLine("Project Name");
            ProjectName = Console.ReadLine();
        }
         public void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Bonus: {bonus}");
            Console.WriteLine($"Project Name: {ProjectName}");
        }

        public override void CalculateSalary()
        {
            if(ProjectName=="Banking"){
                salary = (5/100)*bonus + salary;
            }
            if(ProjectName=="Insurance"){
                salary = (1/10)*bonus + salary;
            }
             Console.WriteLine($"Total Salary for Trainee: {salary}");
        }


    }


}