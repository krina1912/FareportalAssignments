using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientSide.Models;

public partial class KrinaAdmin
{
    public int Aid { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    [Display(Name = "Password")]

    public string? Pwd { get; set; }
}
