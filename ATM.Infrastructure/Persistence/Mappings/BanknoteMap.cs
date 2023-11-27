using ATM.Domain.Entities;
using ATM.Infrastructure.Persistence.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATM.Infrastructure.Persistence.Mappings
{
    internal sealed class BanknoteMap
    {
        public BanknoteMap(EntityTypeBuilder<Banknote> e)
        {
            e.ToTable(Table.Banknote);

            e.HasKey(x => x.Id);

            e.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(50)");

            e.Property(x => x.Amount)
                .HasColumnName("Amount")
                .HasColumnType("int");
        }
    }
}
