using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace bankproject
{
    public class SBAccount
    {
       
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public decimal CurrentBalance { get; set; }

         public SBAccount(){

        }
        public SBAccount(int accno,string cn,string ca,decimal cb){
            AccountNumber=accno;
            CustomerName=cn;
            CustomerAddress=ca;
            CurrentBalance=cb;
        }

        public override string ToString()
        {
            return $"Account Number: {AccountNumber}, Name: {CustomerName}, Address: {CustomerAddress}, Balance: {CurrentBalance}";
        }
    }
}
