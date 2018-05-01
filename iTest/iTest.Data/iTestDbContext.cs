using iTest.Data.Models.Abstract;
using iTest.Data.Models.Implementations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace iTest.Data
{
    public class iTestDbContext : IdentityDbContext<User>
    {
        public iTestDbContext(DbContextOptions<iTestDbContext> options)
            : base(options)
        {
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<UserTest>()
                .HasKey(x => new { x.UserId, x.TestId }); // composite primary key

            builder
                .Entity<UserTest>()
                .HasOne(x => x.Test)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.TestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<UserTest>()
                .HasOne(x => x.User)
                .WithMany(x => x.Tests)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Test>().ToTable("Tests");
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Result>().ToTable("Results");
            builder.Entity<Question>().ToTable("Questions");
            builder.Entity<Answer>().ToTable("Answers");


            base.OnModelCreating(builder);
        }

        private void ApplyAuditInfoRules()
        {
            var newlyCreatedEntities = this.ChangeTracker.Entries()
                .Where(e => e.Entity is IEditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            foreach (var entry in newlyCreatedEntities)
            {
                var entity = (IAuditable)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == null)
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
