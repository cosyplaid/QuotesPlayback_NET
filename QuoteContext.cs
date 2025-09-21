using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace QuotesPlayback_NET
{
    public class QuoteContext: DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options) : base(options) { }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>().HasKey(x => x.Id);
            modelBuilder.Entity<Quote>().Property(x => x.QuoteText).HasMaxLength(300);
            base.OnModelCreating(modelBuilder);
        }
    }
}
