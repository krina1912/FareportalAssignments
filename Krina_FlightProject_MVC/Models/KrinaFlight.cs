using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Krina_FlightProject.Models;

public partial class KrinaFlight
{
    public int Fid { get; set; }

    [Display(Name = "Source")]
    [Required(ErrorMessage = "Select your Source ")]

    public string? DepartId { get; set; }

[Display(Name = "Destination")]
    [Required(ErrorMessage = "Select your Destination")]
    public string? ArrivalId { get; set; }


[Display(Name = "Airline")]

    public string? Flightname { get; set; }


[Display(Name = "Departure Time")]
[Required(ErrorMessage ="Please Select your Date of Travel")]

    public DateTime? DepartTime { get; set; }

[Display(Name = "Arrival Time")]


    public DateTime? ArrivalTime { get; set; }

[Display(Name = "Cost ")]

    public double? TotalCost { get; set; }

    public virtual KrinaAirport? Arrival { get; set; }

    public virtual KrinaAirport? Depart { get; set; }

    public virtual ICollection<KrinaBooking> KrinaBookings { get; set; } = new List<KrinaBooking>();
}
