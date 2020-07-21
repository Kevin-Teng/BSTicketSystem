namespace BSTicketSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BSTicketDBContext : DbContext
    {
        public BSTicketDBContext()
            : base("name=BSTicketDBContext")
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Authority> Authority { get; set; }
        public virtual DbSet<Img> Img { get; set; }
        public virtual DbSet<Map> Map { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Seat> Seat { get; set; }

        public virtual DbSet<ImgProduct> ImgProduct { get; set; }
        public virtual DbSet<ImgActivity> ImgActivity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Activity)
                .HasForeignKey(e => e.Activity_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Activity)
                .HasForeignKey(e => e.Activity_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Authority>()
                .Property(e => e.Authority_Name)
                .IsFixedLength();

            modelBuilder.Entity<Authority>()
                .HasMany(e => e.Member)
                .WithRequired(e => e.Authority)
                .HasForeignKey(e => e.Authority_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Map>()
                .HasMany(e => e.Activity)
                .WithOptional(e => e.Map)
                .HasForeignKey(e => e.Map_Id);

            modelBuilder.Entity<Member>()
                .Property(e => e.Tel)
                .IsFixedLength();

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Activity)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.Member_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.Member_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Seat)
                .WithOptional(e => e.Member)
                .HasForeignKey(e => e.Member_Id);

            modelBuilder.Entity<Order>()
                .Property(e => e.Price)
                .HasPrecision(18, 1);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetail)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.Order_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 1);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetail)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Product_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seat>()
                .Property(e => e.C_left)
                .IsFixedLength();

            modelBuilder.Entity<Seat>()
                .Property(e => e.C_top)
                .IsFixedLength();

            modelBuilder.Entity<Seat>()
                .Property(e => e.Price)
                .HasPrecision(18, 1);

            modelBuilder.Entity<Seat>()
                .HasMany(e => e.Map)
                .WithRequired(e => e.Seat)
                .HasForeignKey(e => e.Seat_Id)
                .WillCascadeOnDelete(false);



            //¦Û©w¸qModels
            modelBuilder.Entity<Product>()
                .HasMany(e => e.ImgProduct)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Product_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Img>()
                .HasMany(e => e.ImgProduct)
                .WithRequired(e => e.Img)
                .HasForeignKey(e => e.Img_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.ImgActivity)
                .WithRequired(e => e.Activity)
                .HasForeignKey(e => e.Activity_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Img>()
                .HasMany(e => e.ImgActivity)
                .WithRequired(e => e.Img)
                .HasForeignKey(e => e.Img_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ImgProduct>()
                .HasKey(p => new { p.Img_Id, p.Product_Id});
        }
    }
}
