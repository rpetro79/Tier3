﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEP3.DbContexts;

namespace SEP3.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20191112191158_mig")]
    partial class mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SEP3.DbModel.DbContactInfo", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("username");

                    b.ToTable("contactInfo");
                });

            modelBuilder.Entity("SEP3.DbModel.DbCustomer", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("username");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("SEP3.DbModel.DbCustomerCredentials", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("username");

                    b.ToTable("customerCredentials");
                });

            modelBuilder.Entity("SEP3.DbModel.DbITProvider", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("noOfReviews")
                        .HasColumnType("int");

                    b.Property<double>("review")
                        .HasColumnType("float");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("username");

                    b.ToTable("ITProviders");
                });

            modelBuilder.Entity("SEP3.DbModel.DbITProviderCredentials", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("username");

                    b.ToTable("ITProviderCredentials");
                });

            modelBuilder.Entity("SEP3.DbModel.DbTechnologies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("technology")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("technologies");
                });
#pragma warning restore 612, 618
        }
    }
}
