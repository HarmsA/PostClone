using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostClone.Models
{
    public class User
    {
       [Key]
       public int UserId {get;set;}
       [Required]
       public string Fname {get;set;}
       [Required]
       public string Lname {get;set;}
       [Required]
       [EmailAddress]
       public string Email {get;set;}
       [Required]
       [DataType(DataType.Password)]
       [MinLength(8, ErrorMessage="Password needs to be 8 characters long.")]
       public string Password {get;set;}
       [NotMapped]
       [DataType(DataType.Password)]
       [Compare("Password")]
       public string Confirm {get;set;}
       public DateTime DOB {get;set;}
       public DateTime CreatedAt {get;set;} = DateTime.Now;
       public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // NAVIGATION PROPERTIES
        //ALLOWS TO GRAB A USER BUT DOES NOT LIVE IN THE DB
       public List<Post> Posts {get;set;}
    }

    public class LoginUser
    {
        [EmailAddress]
        [Required]
        [Display(Name="Email")]
        public string Email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password {get;set;}
    }
}