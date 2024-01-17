using System.Runtime.InteropServices;
using System.Collections.Generic;
using bankprojdb.Models;
namespace bankproject{
    class Client{
        public static void Main(){
            BankRepository b = new BankRepository();
            while(true){
            System.Console.WriteLine("What you want to do?\n1.Create New Account\n2.Get all accounts\n3.Get Acc Details\n4.Deposit Amt\n5.Withdraw amt\n6.Get transactions");

            int choice = Convert.ToInt32(System.Console.ReadLine());
            if(choice == 1){
                KrinaSbaccount s1 = new KrinaSbaccount();

                System.Console.WriteLine("enter acc no");
                int accno= Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("enter cus name");
                string cn = System.Console.ReadLine();
                System.Console.WriteLine("enter cus addr");
                string ca = System.Console.ReadLine();
                System.Console.WriteLine("enter salary");
                double sal = Convert.ToDouble(System.Console.ReadLine());
                s1.Accno = accno;
                s1.Cname=cn;
                s1.CurrAddr=ca;
                s1.CurrBal=sal;
                b.NewAccount(s1);

            }
            else if(choice ==2){
                var acc = b.GetAllAccounts();
                foreach(var item in acc){
                    System.Console.WriteLine(item.ToString());
                }
            }
            else if(choice==3){
                System.Console.WriteLine("Enter acc no ");
                int accno= Convert.ToInt32(Console.ReadLine());
                try{
                KrinaSbaccount acc = b.GetAccountDetails(accno);
               
                    System.Console.WriteLine(acc.ToString());
                }
                catch(Exception ex){
                    System.Console.WriteLine(ex.Message);
                }
            }
            else if(choice==4){
                System.Console.WriteLine("Enter acc no ");
                int accno= Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Enter amount ");
                double amt = Convert.ToDouble(System.Console.ReadLine());
                b.DepositAmount(accno,amt);
                System.Console.WriteLine("Amount deposited");
            }
            else if(choice==5){
                 System.Console.WriteLine("Enter acc no ");
                int accno= Convert.ToInt32(Console.ReadLine());
                try{
                System.Console.WriteLine("Enter amount ");
                double amt = Convert.ToDouble(System.Console.ReadLine());
                b.WithdrawAmount(accno,amt);
                System.Console.WriteLine("amt withdrawn");
                }
                catch(Exception ex){
                    System.Console.WriteLine(ex.Message);
                }
            }
            else if(choice==6){
                 System.Console.WriteLine("Enter acc no ");
                int accno= Convert.ToInt32(Console.ReadLine());
                var acc = b.GetTransactions(accno);
                foreach(var item in acc){
                    System.Console.WriteLine(item.ToString());
                }
                
            }
            else{
                System.Console.WriteLine("Please enter valid request");
            }
            }

        }
    }
}