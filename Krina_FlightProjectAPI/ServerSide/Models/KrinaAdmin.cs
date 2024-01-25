using System;
using System.Collections.Generic;

namespace ServerSide.Models;

public partial class KrinaAdmin
{
    public int Aid { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Pwd { get; set; }
}
