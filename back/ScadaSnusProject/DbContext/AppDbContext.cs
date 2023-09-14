using Microsoft.EntityFrameworkCore;
using SCADA_Project.Model;
using ScadaSnusProject.Model;

namespace ScadaSnusProject.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<IBaseEntity> IBaseEntities { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Alarm> Alarms { get; set; }
    public DbSet<TagRecord> TagRecords { get; set; }
    public DbSet<AlarmRecord> AlarmRecords { get; set; }
    public DbSet<DigitalInput> DigitalInputs { get; set; }
    public DbSet<DigitalOutput> DigitalOutputs { get; set; }
    public DbSet<AnalogInput> AnalogInputs { get; set; }
    public DbSet<AnalogOutput> AnalogOutputs { get; set; }
    
}