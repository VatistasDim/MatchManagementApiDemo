using MatchManagementApiDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchManagementApiDemo.Data
{
    /// <summary>
    /// Represents the database context for the Match Management application, including DbSet properties for Match and MatchOdds entities.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the context.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Match>()
                        .Property(m => m.ID)
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<MatchOdds>()
                        .HasOne(mo => mo.Match)
                        .WithMany(m => m.MatchOdds)
                        .HasForeignKey(mo => mo.MatchId);
        }

        /// <summary>
        /// Gets or sets the DbSet for Match entities in the database.
        /// </summary>
        public DbSet<Match> Matches { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for MatchOdds entities in the database.
        /// </summary>
        public DbSet<MatchOdds> MatchOdds { get; set; }
    }
}
