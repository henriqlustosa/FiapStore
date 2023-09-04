
using FiapStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FiapStore.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(u => u.Nome)
                .HasColumnType("VARCHAR(100)");

            builder.Property(u => u.NomeUsuario)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(u => u.Permissao)
                .HasConversion<int>()
                .IsRequired();

            builder.HasMany(u => u.Pedidos)
                .WithOne(o => o.Usuario)
                .HasForeignKey(o => o.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }   
   
}
