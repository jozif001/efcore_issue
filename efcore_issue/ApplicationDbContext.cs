using Microsoft.EntityFrameworkCore;

namespace efcore_issue
{
    public partial class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// default constructor with option builder
        /// </summary>
        /// <param name="options">the options builder</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Root> Roots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Root>()
                .OwnsOne(e => e.Child1, options =>
                {
                    options.ToTable("child1s");
                });

            modelBuilder.Entity<Root>()
                .OwnsOne(e => e.Child2, options =>
                {
                    options.ToTable("child2s");
                });

            modelBuilder.Entity<Root>()
                .OwnsMany(e => e.Child3, options =>
                {
                    options.ToTable("child3s");
                });
        }
    }
}
