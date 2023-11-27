using ATM.Domain.Entities;
using ATM.Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ATM.Infrastructure.Persistence
{
    public sealed class SqlDBContext : DbContext
    {
        public SqlDBContext(DbContextOptions<SqlDBContext> options) : base(options)
        { }

        public DbSet<Machine> Machine { get; set; }
        public DbSet<Banknote> Banknote { get; set; }
        public DbSet<MachineNote> MachineNote { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Machine>(e => new MachineMap(e));
            builder.Entity<Banknote>(e => new BanknoteMap(e));
            builder.Entity<MachineNote>(e => new MachineNoteMap(e));
        }
    }
}
