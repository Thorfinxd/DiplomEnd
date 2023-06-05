using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Diplom1.BDModels
{
    public partial class CoreModel : DbContext
    {


        public static CoreModel instanse;

        public static CoreModel init()
        {
            if (instanse == null)
            {
                instanse = new CoreModel();
            }
            return instanse;
        }
        public CoreModel()
        {
        }

        public CoreModel(DbContextOptions<CoreModel> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryTov> CategoryTovs { get; set; } = null!;
        public virtual DbSet<Dolzhnost> Dolzhnosts { get; set; } = null!;
        public virtual DbSet<Klienti> Klientis { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrdersProduct> OrdersProducts { get; set; } = null!;
        public virtual DbSet<Postavka> Postavkas { get; set; } = null!;
        public virtual DbSet<Postavshik> Postavshiks { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Sklad> Sklads { get; set; } = null!;
        public virtual DbSet<Sotrudniki> Sotrudnikis { get; set; } = null!;
        public virtual DbSet<Tovar> Tovars { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=ISPr22-43_BelyakovDI;password=ISPr22-43_BelyakovDI;database=ISPr22-43_BelyakovDI_Diplom1;character set=utf8", ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<CategoryTov>(entity =>
            {
                entity.HasKey(e => e.CaterogyTovid)
                    .HasName("PRIMARY");

                entity.ToTable("CategoryTov");

                entity.Property(e => e.Category).HasMaxLength(64);
            });

            modelBuilder.Entity<Dolzhnost>(entity =>
            {
                entity.ToTable("Dolzhnost");

                entity.Property(e => e.Dolzhnostid).ValueGeneratedNever();

                entity.Property(e => e.DolzhnostSotr).HasMaxLength(86);
            });

            modelBuilder.Entity<Klienti>(entity =>
            {
                entity.HasKey(e => e.KlientId)
                    .HasName("PRIMARY");

                entity.ToTable("Klienti");

                entity.Property(e => e.KlientId).HasColumnName("Klient_id");

                entity.Property(e => e.KlientAdres).HasMaxLength(100);

                entity.Property(e => e.KlientCompany).HasMaxLength(100);

                entity.Property(e => e.KlientName).HasMaxLength(85);

                entity.Property(e => e.KlientSecondName).HasMaxLength(85);

                entity.Property(e => e.KlientSurname).HasMaxLength(85);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrdersId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.KlientiKlientId, "fk_Orders_Klienti1_idx");

                entity.Property(e => e.OrdersId).HasColumnName("Orders_id");

                entity.Property(e => e.KlientiKlientId).HasColumnName("Klienti_Klient_id");

                entity.Property(e => e.OrdersDate).HasColumnType("datetime");

                entity.HasOne(d => d.KlientiKlient)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.KlientiKlientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Orders_Klienti1");
            });

            modelBuilder.Entity<OrdersProduct>(entity =>
            {
                entity.HasKey(e => new { e.OrdersId, e.ProductsId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("OrdersProduct");

                entity.HasIndex(e => e.ProductsId, "fkOrdProdHasProd_idx");

                entity.Property(e => e.OrdersId).HasColumnName("Orders_Id");

                entity.Property(e => e.ProductsId).HasColumnName("Products_Id");

                entity.Property(e => e.ProductsCount).HasColumnName("Products_Count");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.OrdersProducts)
                    .HasForeignKey(d => d.OrdersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkOrdProdHasOrders");

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.OrdersProducts)
                    .HasForeignKey(d => d.ProductsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkOrdProdHasProd");
            });

            modelBuilder.Entity<Postavka>(entity =>
            {
                entity.ToTable("Postavka");

                entity.Property(e => e.PostavkaId).HasColumnName("Postavka_id");

                entity.Property(e => e.PostavkaDesc).HasMaxLength(100);

                entity.Property(e => e.PostavkaNamePost).HasMaxLength(100);

                entity.Property(e => e.PostavkaNameTov).HasMaxLength(100);
            });

            modelBuilder.Entity<Postavshik>(entity =>
            {
                entity.ToTable("Postavshik");

                entity.Property(e => e.Postavshikid).ValueGeneratedNever();

                entity.Property(e => e.PostavshikName).HasMaxLength(86);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Rolesid)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UsersUsersId, "fk_Roles_Users1_idx");

                entity.Property(e => e.Role1).HasColumnName("Role");

                entity.Property(e => e.UsersUsersId).HasColumnName("Users_Users_id");

                entity.HasOne(d => d.UsersUsers)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.UsersUsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Roles_Users1");
            });

            modelBuilder.Entity<Sklad>(entity =>
            {
                entity.ToTable("Sklad");

                entity.Property(e => e.NameTov).HasMaxLength(86);
            });

            modelBuilder.Entity<Sotrudniki>(entity =>
            {
                entity.ToTable("Sotrudniki");

                entity.Property(e => e.Sotrudnikiid).ValueGeneratedNever();

                entity.Property(e => e.SotrudnikiAdres).HasMaxLength(45);

                entity.Property(e => e.SotrudnikiName).HasMaxLength(45);

                entity.Property(e => e.SotrudnikiSecondName).HasMaxLength(45);

                entity.Property(e => e.SotrudnikiSurname).HasMaxLength(45);
            });

            modelBuilder.Entity<Tovar>(entity =>
            {
                entity.ToTable("Tovar");

                entity.HasIndex(e => e.TovarCategoryid, "fk_Tov_category_idx");

                entity.HasIndex(e => e.CategoryCategoryId, "fk_Tovar_Category_idx");

                entity.Property(e => e.TovarId).HasColumnName("Tovar_id");

                entity.Property(e => e.CategoryCategoryId).HasColumnName("Category_Category_id");

                entity.Property(e => e.DescTov).HasMaxLength(100);

                entity.Property(e => e.NaimTov).HasMaxLength(100);

                entity.HasOne(d => d.CategoryCategory)
                    .WithMany(p => p.TovarCategoryCategories)
                    .HasForeignKey(d => d.CategoryCategoryId)
                    .HasConstraintName("fk_Tovar_Category");

                entity.HasOne(d => d.TovarCategory)
                    .WithMany(p => p.TovarTovarCategories)
                    .HasForeignKey(d => d.TovarCategoryid)
                    .HasConstraintName("fk_Tov_category");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UsersRolesid, "FK_Users_Roles_idx");

                entity.Property(e => e.UsersId).HasColumnName("Users_id");

                entity.Property(e => e.UsersLogin).HasMaxLength(128);

                entity.Property(e => e.UsersName).HasMaxLength(64);

                entity.Property(e => e.UsersPassword).HasMaxLength(128);

                entity.Property(e => e.UsersSecondName).HasMaxLength(64);

                entity.Property(e => e.UsersSurname).HasMaxLength(64);

                entity.HasOne(d => d.UsersRoles)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UsersRolesid)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
