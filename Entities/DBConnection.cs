using Microsoft.EntityFrameworkCore;

namespace dotnet_crud_api_00.Entities
{
    public partial class DBConnection : DbContext
    {
        public DBConnection(DbContextOptions<DBConnection> options) : base(options) { }

        public virtual DbSet<Post> Post { get; set; } = null!;
        //public virtual DbSet<Post>? Post { get; set; } ;


        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=4_post_comment_db");
        //     }
        // }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // modelBuilder.Entity<User>(entity =>
        //     // {
        //     //     entity.ToTable("user");

        //     //     entity.Property(e => e.Id).HasColumnType("int(11)");

        //     //     entity.Property(e => e.FirstName)
        //     //         .IsRequired()
        //     //         .HasMaxLength(45);

        //     //     entity.Property(e => e.LastName)
        //     //         .IsRequired()
        //     //         .HasMaxLength(45);

        //     //     entity.Property(e => e.Password)
        //     //         .IsRequired()
        //     //         .HasMaxLength(45);

        //     //     entity.Property(e => e.Username)
        //     //         .IsRequired()
        //     //         .HasMaxLength(45);
        //     // });


        //     // modelBuilder.Entity<Post>(entity =>
        //     // {
        //     //     entity.ToTable("post");
        //     //     // entity.Property(e => e.Id).HasColumnType("int(11)");
        //     //     entity.Property(e => e.title)
        //     //         .IsRequired()
        //     //         .HasMaxLength(45);
        //     //     entity.Property(e => e.content)
        //     //         .IsRequired()
        //     //         .HasMaxLength(45);
        //     // });


        //     OnModelCreatingPartial(modelBuilder);
        // }

        // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}