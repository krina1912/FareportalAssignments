using System;
using System.Collections.Generic;

namespace ServerSide.Models;

public partial class KrinaFlight
{
    public int Fid { get; set; }

    public string? DepartId { get; set; }

    public string? ArrivalId { get; set; }

    public string? Flightname { get; set; }

    public DateTime? DepartTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public double? TotalCost { get; set; }

    public virtual KrinaAirport? Arrival { get; set; }

    public virtual KrinaAirport? Depart { get; set; }

    public virtual ICollection<KrinaBooking> KrinaBookings { get; set; } = new List<KrinaBooking>();
}
