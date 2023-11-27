using ATM.Domain.Entities;
using ATM.Infrastructure.Persistence.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATM.Infrastructure.Persistence.Mappings
{
    internal sealed class MachineMap
    {
        public MachineMap(EntityTypeBuilder<Machine> e)
        {
            e.ToTable(Table.Machine);

            e.HasKey(x => x.Id);

            e.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(50)");

            e.HasMany(x => x.MachineNotes)
               .WithOne(x => x.Machine)
               .HasForeignKey(x => x.MachineId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
