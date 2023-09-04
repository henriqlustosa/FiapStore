using FiapStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(o => o.NomeProduto)
                .HasColumnType("VARCHAR(100)");

            builder.HasOne(o => o.Usuario)
                .WithMany(u => u.Pedidos)
                .HasPrincipalKey(u => u.Id);
        }
    }
}

