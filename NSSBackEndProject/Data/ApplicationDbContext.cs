using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NSSBackEndProject.Models;

namespace NSSBackEndProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookQuiz> BookQuiz { get; set; }
        public DbSet<BookShelf> BookShelf  { get; set; }
        public DbSet<FanFiction> FanFiction { get; set; }
        public DbSet<Friendship> Friendship { get; set; }
        public DbSet<QuizAnswers> QuizAnswers { get; set; }
        public DbSet<QuizQuestions> QuizQuestions { get; set; }
        public DbSet<Recommendations> Recommendations  { get; set; }






    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
