using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebSurvey.Data.Models;

namespace WebSurvey.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<AnswerQuestion> AnswersQuestions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerQuestion>()
                .HasOne(q => q.Question)
                .WithMany(x => x.Answers)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
