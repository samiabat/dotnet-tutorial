using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using postgressdb.Models;

namespace postgressdb.Data;

public class ApiDbContext : DbContext
{
    public virtual DbSet<Driver> ?Drivers { get; set; }
    public virtual DbSet<Team> ?Teams { get; set; }
    public virtual DbSet<DriverMedia> ?DriverMedias { get; set; }
    
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Driver>(entity=>{
            entity.HasOne(t=>t.Team)
            .WithMany(d=>d.Drivers)
            .HasForeignKey(t=>t.TeamId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Driver_Team");

            entity.HasOne(dm=>dm.DriverMedia)
            .WithOne(d=>d.Driver)
            .HasForeignKey<DriverMedia>(x=>x.DriverId);
        });
    }
}