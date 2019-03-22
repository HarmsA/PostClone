using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostClone.Models
{
    [Table("posts")]
    public class Post
    {
       [Key]
       public int PostId {get;set;}
       public int UserId {get;set;}
       [Required]
       [MaxLength(45, ErrorMessage = "Thats way to long!")]
       public string Topic {get;set;}
       [Required]
       public string Content {get;set;}
       public DateTime CreatedAt {get;set;} = DateTime.Now;
       public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // NAVIGATION PROPERTIES
        //ALLOWS TO GRAB A USER BUT DOES NOT LIVE IN THE DB
       public User Creator {get;set;}
    }
}