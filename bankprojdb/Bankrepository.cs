using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.Intrinsics.Arm;
using bankprojdb.Models;
using bankprojectDb;
// using System.Transactions;

namespace bankproject{
    class BankRepository: IBankRepository{
    private static Ace52024Context db = new Ace52024Context();

    static int tranid = 2;
    //     public List <SBAccount> accounts;
  
    //    public List <SBTransaction> transactions ;
        //         public BankRepository()
        // {
        //     accounts = new List<SBAccount>();
        //     transactions = new List<SBTransaction>();
        // }
  public void NewAccount(KrinaSbaccount acc)
        {
         
           if(db.KrinaSbaccounts.Find(acc.Accno)==null){

            db.KrinaSbaccounts.Add(acc);
            db.SaveChanges();
           }else{
            System.Console.WriteLine("Account already exist");
           }
    

            
        }

    
        public void DepositAmount(int accno, double amt)
        {
            
            
            try{
            tranid++;
            string trantype = "Deposit";
            KrinaSbaccount ka = GetAccountDetails(accno);
            ka.CurrBal+=amt;
            db.KrinaSbaccounts.Update(ka);
            db.SaveChanges();
            KrinaSbtransaction k = new KrinaSbtransaction();
            k.Transid=tranid;
            k.Transdate=DateTime.Now;
            k.Accno=accno;
            k.Amt=amt;
            k.Tt=trantype;
            db.KrinaSbtransactions.Add(k);
            db.SaveChanges();
            
            }
            catch(Exception ex){
                System.Console.WriteLine(ex.Message);
            }
           
            
           
            
        }

        public KrinaSbaccount GetAccountDetails(int accno)
        {
          
             foreach (KrinaSbaccount item in db.KrinaSbaccounts){
                if(item.Accno==accno){
                    return item;
                    
                }
            }
           
             
            // return null;
            throw new Exception("Account not found");
            // throw new NotImplementedException();
        }

      public List<KrinaSbaccount> GetAllAccounts()
        {
           
            return db.KrinaSbaccounts.ToList();
        }

        public List<KrinaSbtransaction> GetTransactions(int accno)
        {

            List<KrinaSbtransaction> ll = new List<KrinaSbtransaction>();
            foreach(KrinaSbtransaction item in db.KrinaSbtransactions){
                if(item.Accno==accno){
                    ll.Add(item);
                }
            }
            return ll;
        }

      
        public void WithdrawAmount(int accno, double amt)
        {
            
            
              try{
                 tranid++;
            
            string trantype = "Withdraw";
            KrinaSbaccount ka = GetAccountDetails(accno);
            ka.CurrBal-=amt;
            KrinaSbtransaction k = new KrinaSbtransaction();
            k.Transid=tranid;
            k.Transdate=DateTime.Now;
            k.Accno=accno;
            k.Amt=amt;
            k.Tt=trantype;
            db.KrinaSbtransactions.Add(k);
            db.KrinaSbaccounts.Update(ka);
            db.SaveChanges();
            }
            catch(Exception ex){
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}