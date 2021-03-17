using Microsoft.EntityFrameworkCore;
using midTerm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace midTerm.Data
{
    public class SurveyContext : DbContext
    {
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SurveyUser> SurveyUsers { get; set; }
        public SurveyContext(DbContextOptions<SurveyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>().HasKey(x => x.Id);
            modelBuilder.Entity<Answers>().HasOne(x => x.Option).WithMany().HasForeignKey(x => x.OptionId);
            modelBuilder.Entity<Answers>().HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Option>().HasKey(x => x.Id);
            modelBuilder.Entity<Option>().HasOne(x => x.Question).WithMany(x => x.Options).HasForeignKey(x => x.QuestionId);

            modelBuilder.Entity<Question>().HasKey(x => x.Id);
            modelBuilder.Entity<Question>().HasMany(x => x.Options).WithOne(x => x.Question).HasForeignKey(x => x.QuestionId);

            modelBuilder.Entity<SurveyUser>().HasKey(x => x.Id);
        }
    }
}
