using iTest.Data.Models.Implementations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        //public DbSet<UserTest> UserTest { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<UserTest>()
                .HasKey(x => new { x.UserId, x.TestId });

            builder
                .Entity<UserTest>()
                .HasOne(x => x.User)
                .WithMany(x => x.Tests)
                .HasForeignKey(x => x.TestId);

            builder
                .Entity<UserTest>()
                .HasOne(x => x.Test)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.UserId);

            builder.Entity<Test>().ToTable("Tests");
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Result>().ToTable("Results");
            builder.Entity<Question>().ToTable("Questions");
            builder.Entity<Answer>().ToTable("Answers");


            base.OnModelCreating(builder);
        }
    }
}
