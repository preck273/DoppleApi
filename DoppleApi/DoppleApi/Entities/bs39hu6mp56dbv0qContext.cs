using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DoppleApi.Entities
{
    public partial class bs39hu6mp56dbv0qContext : DbContext
    {
        public bs39hu6mp56dbv0qContext()
        {
        }

        public bs39hu6mp56dbv0qContext(DbContextOptions<bs39hu6mp56dbv0qContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Instruction> Instructions { get; set; }
        public virtual DbSet<Operator> Operators { get; set; }
        public virtual DbSet<Operatorposition> Operatorpositions { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Testresult> Testresults { get; set; }
        public virtual DbSet<Turnovertime> Turnovertimes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=yjo6uubt3u5c16az.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;port=3306;user=sm2p93rnfo9ctvxh;password=lck1q8l6r8sqg779;database=bs39hu6mp56dbv0q");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>(entity =>
            {
                entity.HasKey(e => e.TagId)
                    .HasName("PRIMARY");

                entity.ToTable("carriers");

                entity.HasIndex(e => e.OrderIdO, "orderID_Carrier_FK");

                entity.HasIndex(e => e.StationId, "stationID_Carrier_FK");

                entity.Property(e => e.TagId)
                    .HasMaxLength(20)
                    .HasColumnName("tagID");

                entity.Property(e => e.OrderIdO)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("OrderID_O");

                entity.Property(e => e.StationId).HasColumnName("StationID");

                entity.Property(e => e.StatusCarrier)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.OrderIdONavigation)
                    .WithMany(p => p.Carriers)
                    .HasForeignKey(d => d.OrderIdO)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderID_Carrier_FK");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Carriers)
                    .HasForeignKey(d => d.StationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stationID_Carrier_FK");
            });

            modelBuilder.Entity<Instruction>(entity =>
            {
                entity.ToTable("instructions");

                entity.HasIndex(e => e.StationId, "StationID")
                    .IsUnique();

                entity.Property(e => e.InstructionId)
                    .HasMaxLength(10)
                    .HasColumnName("InstructionID")
                    .IsFixedLength(true);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StationId).HasColumnName("StationID");

                entity.HasOne(d => d.Station)
                    .WithOne(p => p.Instruction)
                    .HasForeignKey<Instruction>(d => d.StationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StationID_Instruction_FK");
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.ToTable("operator");

                entity.Property(e => e.OperatorId)
                    .HasMaxLength(20)
                    .HasColumnName("operatorID");

                entity.Property(e => e.Authorization)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Operatorposition>(entity =>
            {
                entity.HasKey(e => e.OperatorId)
                    .HasName("PRIMARY");

                entity.ToTable("operatorposition");

                entity.HasIndex(e => e.StationId, "stationID_Station_FK");

                entity.Property(e => e.OperatorId)
                    .HasMaxLength(20)
                    .HasColumnName("operatorID");

                entity.Property(e => e.StationId).HasColumnName("stationID");

                entity.HasOne(d => d.Operator)
                    .WithOne(p => p.Operatorposition)
                    .HasForeignKey<Operatorposition>(d => d.OperatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("operatorID_OPerator_FK");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Operatorpositions)
                    .HasForeignKey(d => d.StationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stationID_Station_FK");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(10)
                    .HasColumnName("OrderID");

                entity.Property(e => e.CradleColor)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EarshellColor)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FaceplateText)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.StatusOrder)
                    .IsRequired()
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("station");

                entity.Property(e => e.StationId).HasColumnName("StationID");

                entity.Property(e => e.StatusStation)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.HasIndex(e => e.OrderId, "orderID_FK_Test");

                entity.HasIndex(e => e.TagId, "tagID_FK_Test");

                entity.Property(e => e.TestId).HasColumnName("testID");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("orderID");

                entity.Property(e => e.TagId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("tagID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderID_FK_Test");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tagID_FK_Test");
            });

            modelBuilder.Entity<Testresult>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PRIMARY");

                entity.ToTable("testresult");

                entity.HasIndex(e => e.OperatorCompanyId, "OperatorCompanyID")
                    .IsUnique();

                entity.Property(e => e.TestId).HasColumnName("testID");

                entity.Property(e => e.OperatorCompanyId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("OperatorCompanyID");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.OperatorCompany)
                    .WithOne(p => p.Testresult)
                    .HasForeignKey<Testresult>(d => d.OperatorCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CompanyID_TR_FK");

                entity.HasOne(d => d.Test)
                    .WithOne(p => p.Testresult)
                    .HasForeignKey<Testresult>(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("testID_TR_FK");
            });

            modelBuilder.Entity<Turnovertime>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("turnovertime");

                entity.HasIndex(e => e.StationId, "StationID")
                    .IsUnique();

                entity.HasIndex(e => e.OrderId, "orderID_TOT_FK");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("OrderID");

                entity.Property(e => e.StationId).HasColumnName("StationID");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderID_TOT_FK");

                entity.HasOne(d => d.Station)
                    .WithOne()
                    .HasForeignKey<Turnovertime>(d => d.StationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StationID_TOT_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<DoppleApi.Models.InstructionModel> InstructionModel { get; set; }

        public DbSet<Models.StationModel> StationModel { get; set; }
    }
}
