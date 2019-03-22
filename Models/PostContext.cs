using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PostClone.Models
{
    public class PostCloneContext : DbContext
    {
        public PostCloneContext(DbContextOptions options) : base(options) {}

        public DbSet<Post> Posts {get;set;}
        public DbSet<User> Users {get;set;}
    }
}