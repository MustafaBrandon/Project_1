using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project_1.Models
{
    public class databaseContext : DbContext
    {
        public databaseContext(DbContextOptions<databaseContext> options) : base (options)
        {
            //empty I suppose
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating (ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );

            mb.Entity<Task>().HasData(
                new Task
                {
                    TaskId = 1,
                    TaskName = "Get a good grade on project 1",
                    DueDate = new DateTime(2022,2,9),
                    CategoryId = 2,
                    Quadrant = 1,
                    Completed = true
                }    
            );
        }

    }
}
