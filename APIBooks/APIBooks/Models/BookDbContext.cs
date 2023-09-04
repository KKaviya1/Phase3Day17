using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIBooks.Models;

public partial class BookDbContext : DbContext
{
    public BookDbContext()
    {
    }

    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-PE7BHIE;database=BookDb;trusted_connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Bid).HasName("PK__Book__C6DE0CC14064A1A3");

            entity.ToTable("Book");

            entity.Property(e => e.Bid)
                .ValueGeneratedNever()
                .HasColumnName("BId");
            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.BookName).HasMaxLength(50);

            entity.HasOne(d => d.BookCategoryNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookCategory)
                .HasConstraintName("FK__Book__BookCatego__3A81B327");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__Category__C1F8DC395DF79E23");

            entity.ToTable("Category");

            entity.HasIndex(e => e.Cname, "UQ__Category__85D445AA4A5BC36B").IsUnique();

            entity.Property(e => e.Cid)
                .ValueGeneratedNever()
                .HasColumnName("CId");
            entity.Property(e => e.Cname)
                .HasMaxLength(50)
                .HasColumnName("CName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
