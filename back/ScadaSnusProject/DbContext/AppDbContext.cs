using Microsoft.EntityFrameworkCore;
using ScadaSnusProject.Model;

namespace ScadaSnusProject.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Alarm> Alarms { get; set; }
    public DbSet<DigitalInput> DigitalInputs { get; set; }
    public DbSet<DigitalOutput> DigitalOutputs { get; set; }
    public DbSet<AnalogInput> AnalogInputs { get; set; }
    public DbSet<AnalogOutput> AnalogOutputs { get; set; }
    public DbSet<TagValue> TagValues { get; set; }
    public DbSet<AlarmActivation> AlarmActivations { get; set; }

}