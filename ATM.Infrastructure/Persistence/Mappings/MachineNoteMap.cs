using ATM.Domain.Entities;
using ATM.Infrastructure.Persistence.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATM.Infrastructure.Persistence.Mappings
{
    internal sealed class MachineNoteMap
    {
        public MachineNoteMap(EntityTypeBuilder<MachineNote> e)
        {
            e.ToTable(Table.MachineNote);

            e.HasKey(x => x.Id);

            e.Property(x => x.Id)
               .HasColumnName("Id")
               .ValueGeneratedNever();

            e.Property(x => x.MachineId)
               .HasColumnName("MachineId");

            e.Property(x => x.BanknoteId)
               .HasColumnName("BanknoteId");

            e.Property(x => x.Amount)
               .HasColumnName("Amount")
               .HasColumnType("int");

            e.HasOne(x => x.Machine)
                .WithMany(x => x.MachineNotes)
                .HasForeignKey(x => x.MachineId);

            e.HasOne(x => x.Banknote);
        }
    }
}
