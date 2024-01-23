using System;
using System.Collections.Generic;

namespace Krina_FlightProject.Models;

public partial class KrinaAirport
{
    public string Airportcode { get; set; } = null!;

    public string? Airportname { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<KrinaFlight> KrinaFlightArrivals { get; set; } = new List<KrinaFlight>();

    public virtual ICollection<KrinaFlight> KrinaFlightDeparts { get; set; } = new List<KrinaFlight>();
}
