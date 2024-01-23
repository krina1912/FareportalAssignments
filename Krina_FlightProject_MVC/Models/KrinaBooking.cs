using System;
using System.Collections.Generic;

namespace Krina_FlightProject.Models;

public partial class KrinaBooking
{
    public int Bid { get; set; }

    public int? Cid { get; set; }

    public DateTime? Bookdate { get; set; }

    public int? Flightid { get; set; }

    public int? NofPasseng { get; set; }

    public double? TotalCost { get; set; }

    public virtual KrinaCustomer? CidNavigation { get; set; }

    public virtual KrinaFlight? Flight { get; set; }

   


    public virtual ICollection<KrinaOpassenger> KrinaOpassengers { get; set; } = new List<KrinaOpassenger>();
}
