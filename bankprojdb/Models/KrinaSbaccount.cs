using System;
using System.Collections.Generic;

namespace bankprojdb.Models;

public partial class KrinaSbaccount
{
    public int Accno { get; set; }

    public string? Cname { get; set; }

    public string? CurrAddr { get; set; }

    public double? CurrBal { get; set; }

    public virtual ICollection<KrinaSbtransaction> KrinaSbtransactions { get; set; } = new List<KrinaSbtransaction>();
    // public KrinaSbaccount(){

    //     }
    // public KrinaSbaccount(int accno,string cn,string ca,double cb){
    //     Accno=accno;
    //     Cname=cn;
    //     CurrAddr=ca;
    //     CurrBal=cb;
    // }
    public override string ToString()
        {
            return $"Account Number: {Accno}, Name: {Cname}, Address: {CurrAddr}, Balance: {CurrBal}";
        }
    }

