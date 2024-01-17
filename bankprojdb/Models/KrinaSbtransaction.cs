using System;
using System.Collections.Generic;

namespace bankprojdb.Models;

public partial class KrinaSbtransaction
{
    public int Transid { get; set; }

    public DateTime? Transdate { get; set; }

    public int? Accno { get; set; }

    public double? Amt { get; set; }

    public string? Tt { get; set; }

    public virtual KrinaSbaccount? AccnoNavigation { get; set; }
    public override string ToString()
        {
            return $"Transaction ID: {Transid}, Date: {Transdate}, Account: {Accno}, Amount: {Amt}, Type: {Tt}";
        }

}
