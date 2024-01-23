using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Krina_FlightProject.Models;

public partial class KrinaOpassenger
{
    public int Oid { get; set; }

    public int? Custid { get; set; }

    public int? Bookid { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "Please Enter Your First Name")]

    public string? Fname { get; set; }

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Please Enter Your Last Name")]

    public string? Lname { get; set; }

    [Required(ErrorMessage = "Please enter age")]

    public int? Age { get; set; }

    [Display(Name ="Mobile Number")]
    [Required(ErrorMessage = "Please enter Mobile Number")]

    public string? Phone { get; set; }

    public virtual KrinaBooking? Book { get; set; }

    public virtual KrinaCustomer? Cust { get; set; }
}
