﻿// <auto-generated />
using GoToMo.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoToMo.Data.Migrations
{
	[DbContext(typeof(GoToMoContext))]
    [Migration("20250307152958_Second_Migration")]
    partial class Second_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GoToMo.Domain.Movies.MovieCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("MovieCollection", (string)null);
                });

            modelBuilder.Entity("GoToMo.Domain.Movies.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BundleId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int?>("LengthInMinutes")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("MovieCollectionId")
                        .HasColumnType("int");

                    b.Property<int?>("PrimaryGenre")
                        .HasColumnType("int");

                    b.Property<int>("ProductionType")
                        .HasColumnType("int");

                    b.Property<int?>("Season")
                        .HasColumnType("int");

                    b.Property<int?>("SecondaryGenre")
                        .HasColumnType("int");

                    b.Property<int>("SequenceIndex")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BundleId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("MovieCollectionId");

                    b.ToTable("Production", (string)null);
                });

            modelBuilder.Entity("GoToMo.Domain.Movies.ProductionBundle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfProductions")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfSeasons")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductionBundle");
                });

            modelBuilder.Entity("GoToMo.Domain.Movies.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("ProductionId")
                        .HasColumnType("int");

                    b.Property<double>("RatingValue")
                        .HasColumnType("float");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductionId");

                    b.HasIndex("UserId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("GoToMo.Domain.Movies.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductionId")
                        .HasColumnType("int");

                    b.Property<int>("StaffType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductionId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("GoToMo.Domain.Movies.StreamingService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductionId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductionId");

                    b.ToTable("StreamingService", (string)null);
                });

            modelBuilder.Entity("GoToMo.Domain.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("MovieCollectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieCollectionId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("GoToMo.Domain.Movies.MovieCollection", b =>
                {
                    b.HasOne("GoToMo.Domain.Users.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("GoToMo.Domain.Movies.Production", b =>
                {
                    b.HasOne("GoToMo.Domain.Movies.ProductionBundle", "Bundle")
                        .WithMany()
                        .HasForeignKey("BundleId");

                    b.HasOne("GoToMo.Domain.Movies.Staff", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId");

                    b.HasOne("GoToMo.Domain.Movies.MovieCollection", null)
                        .WithMany("Productions")
                        .HasForeignKey("MovieCollectionId");

                    b.Navigation("Bundle");

                    b.Navigation("Director");
                });

            modelBuilder.Entity("GoToMo.Domain.Movies.Rating", b =>
                {
                    b.HasOne("GoToMo.Domain.Movies.Production", null)
                        .WithMany("Ratings")
                        .HasForeignKey("ProductionId");

                    b.HasOne("GoToMo.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GoToMo.Domain.Movies.Staff", b =>
                {
                    b.HasOne("GoToMo.Domain.Movies.Production", null)
                        .WithMany("Actors")
                        .HasForeignKey("ProductionId");
                });

            modelBuilder.Entity("GoToMo.Domain.Movies.StreamingService", b =>
                {
                    b.HasOne("GoToMo.Domain.Movies.Production", null)
                        .WithMany("StreamingServices")
                        .HasForeignKey("ProductionId");
                });

            modelBuilder.Entity("GoToMo.Domain.Users.User", b =>
                {
                    b.HasOne("GoToMo.Domain.Movies.MovieCollection", null)
                        .WithMany("Users")
                        .HasForeignKey("MovieCollectionId");
                });

            modelBuilder.Entity("GoToMo.Domain.Movies.MovieCollection", b =>
                {
                    b.Navigation("Productions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("GoToMo.Domain.Movies.Production", b =>
                {
                    b.Navigation("Actors");

                    b.Navigation("Ratings");

                    b.Navigation("StreamingServices");
                });
#pragma warning restore 612, 618
        }
    }
}
