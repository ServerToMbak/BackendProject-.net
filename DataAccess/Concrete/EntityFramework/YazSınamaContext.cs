using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class YazSınamaContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=YazSınamaProject;Trusted_Connection=true");
        }
        public DbSet<Category> Categories { get; set; }   
        public DbSet<Comment> Comments { get; set; } 
        public DbSet<Question> Questions { get; set; } 
        public DbSet<QuestionImage> QuestionImage { get; set; } 
        
    }
}
