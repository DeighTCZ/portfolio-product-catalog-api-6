using Microsoft.EntityFrameworkCore;

#pragma warning disable CS1591
namespace product_catalog_data_access.EfModels;

/// <summary>
/// Kontext vygenerovaný pomocí
/// </summary>
public partial class ProductCatalogDbContext : DbContext
{
    public ProductCatalogDbContext()
    {
    }

    public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("product");

            entity.HasIndex(e => e.ProductName, "uk_dbo_product")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnName("description");

            entity.Property(e => e.ImageUri)
                .HasMaxLength(50)
                .HasColumnName("image_uri");

            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");

            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("product_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user", "security");

            entity.HasIndex(e => e.Login, "uk_security_user")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("login");

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
