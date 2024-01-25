using System;
using System.Collections.Generic;

namespace ServerSide.Models;

public partial class KrinaCustomer
{
    public int Cid { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public int? Age { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Pwd { get; set; }

    public virtual ICollection<KrinaBooking> KrinaBookings { get; set; } = new List<KrinaBooking>();
}
