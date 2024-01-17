
using System.Collections.Generic;
using bankprojdb.Models;

namespace bankprojectDb
{
    public interface IBankRepository
    {
       
        void NewAccount(KrinaSbaccount sb );
        List<KrinaSbaccount> GetAllAccounts();
        KrinaSbaccount GetAccountDetails(int accno);
        void DepositAmount(int accno, double amt);
        void WithdrawAmount(int accno, double amt);
        List<KrinaSbtransaction> GetTransactions(int accno);
    }
}