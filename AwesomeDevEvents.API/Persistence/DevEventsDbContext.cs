using AwesomeDevEvents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeDevEvents.API.Persistence
{
    public class DevEventsDbContext : DbContext
    {
        public DevEventsDbContext(DbContextOptions<DevEventsDbContext> options) : base(options)
        {
        }
        public DbSet<DevEvent> DevEvents { get; set; }
        public DbSet<DevEventSpeaker> DevEventsSpeaker { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DevEvent>(e =>
            {
                e.HasKey(de => de.Id);

                e.Property(de => de.Title).IsRequired(false);
                e.Property(de => de.Description)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");
                e.Property(de => de.StartDate)
                    .HasColumnName("Start_date");
                e.Property(de => de.EndDate)
                    .HasColumnName("End_date");
                //Declarando que existem muitos Speakers para um evento (List<Speaker>) e que sua chave é a DevEventId
                e.HasMany(de => de.Speakers)
                    .WithOne()
                    .HasForeignKey(de => de.DevEventId);

            });

            builder.Entity<DevEventSpeaker>(e =>
            {
                e.HasKey(de => de.Id);
            });
        }

    }
}
