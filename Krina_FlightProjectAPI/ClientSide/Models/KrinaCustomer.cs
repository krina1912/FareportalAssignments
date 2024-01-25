using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientSide.Models;

public partial class KrinaCustomer
{
    public int Cid { get; set; }

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
    [StringLength(maximumLength:10,MinimumLength =10,ErrorMessage = "Phone no should be of 10 digits")]

    public string? Phone { get; set; }

    [Required(ErrorMessage = "Please enter your Email")]

    public string? Email { get; set; }

    [Display(Name ="Password")]
    [Required(ErrorMessage = "Please Enter your Password")]

    public string? Pwd { get; set; }

    
    [NotMapped]
    [Compare("Pwd",ErrorMessage = "Password do not match")]
    public string? ConfirmPassword{get;set;}

    
}
