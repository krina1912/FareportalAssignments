using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Serialization;

namespace Krina_FlightProject.Models;

public partial class KrinaAdmin
{
    public int Aid { get; set; }



    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Phone { get; set; }

    [Required(ErrorMessage ="Enter your Email")]

    public string? Email { get; set; }
    [Display(Name ="Password")]

    [Required(ErrorMessage ="Enter your Password")]

    public string? Pwd { get; set; }
}
