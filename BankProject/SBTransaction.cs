
using System;

namespace bankproject
{
    public class SBTransaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }

        public SBTransaction(){}

        public SBTransaction(int ti,DateTime td,int accno,decimal amt,string tt){
            TransactionId=ti;
            TransactionDate = td;
            AccountNumber=accno;
            Amount=amt;
            TransactionType=tt;
        }

        public override string ToString()
        {
            return $"Transaction ID: {TransactionId}, Date: {TransactionDate}, Account: {AccountNumber}, Amount: {Amount}, Type: {TransactionType}";
        }
    }
}
