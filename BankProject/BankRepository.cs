using System;
using System.Collections;
using System.Collections.Generic;
// using System.Transactions;

namespace bankproject{
    class BankRepository: IBankRepository{
        int tranid=0;
        public List <SBAccount> accounts;
  
       public List <SBTransaction> transactions ;
                public BankRepository()
        {
            accounts = new List<SBAccount>();
            transactions = new List<SBTransaction>();
        }
  public void NewAccount(SBAccount acc)
        {
            accounts.Add(acc);
            
        }

    
        public void DepositAmount(int accno, decimal amt)
        {
            tranid++;
            
            string trantype = "Deposit";
            foreach (SBAccount item in accounts){
                if(item.AccountNumber==accno){
                    item.CurrentBalance+=amt;
                    
                }
            }
            transactions.Add(new SBTransaction(tranid,DateTime.Now,accno,amt,trantype));
        }

        public SBAccount GetAccountDetails(int accno)
        {
           
            foreach(SBAccount item in accounts){
                if(item.AccountNumber==accno){
                    return item;
                    
                }
            }
             
            return new SBAccount();
            // throw new NotImplementedException();
        }

      public List<SBAccount> GetAllAccounts()
        {
           
            return accounts;
        }

        public List<SBTransaction> GetTransactions(int accno)
        {
            List<SBTransaction> ll = new List<SBTransaction>();
            foreach(SBTransaction item in transactions){
                if(item.AccountNumber==accno){
                    ll.Add(item);
                }
            }
            return ll;
        }

      
        public void WithdrawAmount(int accno, decimal amt)
        {
            
             tranid++;
            
            string trantype = "Withdraw";
            foreach (SBAccount item in accounts){
                if(item.AccountNumber==accno){
                  item.CurrentBalance=-amt;
                    
                }
            }
            transactions.Add(new SBTransaction(tranid,DateTime.Now,accno,amt,trantype));
        }
    }
}