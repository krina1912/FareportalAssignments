using System;
using System.Collections.Generic;

namespace ClientSide.Models;

public partial class BookingDetails
{
    public string CustomerName { get; set; }
    public DateTime? Bookdate { get; set; }

    public int? Flightid { get; set; }

    public string FlightName {get; set; }

    public string DepartId{get;set;}
    public string ArrivalId{get;set;}
    

    public int? NofPasseng { get; set; }

    public double? TotalCost { get; set; }

    
   


  
}
