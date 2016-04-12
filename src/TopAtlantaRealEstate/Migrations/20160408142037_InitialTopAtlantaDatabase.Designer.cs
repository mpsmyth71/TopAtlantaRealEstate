using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TopAtlantaRealEstate.Models;

namespace TopAtlantaRealEstate.Migrations
{
    [DbContext(typeof(TopAtlantaContext))]
    [Migration("20160408142037_InitialTopAtlantaDatabase")]
    partial class InitialTopAtlantaDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TopAtlantaRealEstate.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Company");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("JobTitle");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.HasKey("CustomerId");
                });

            modelBuilder.Entity("TopAtlantaRealEstate.Models.Email", b =>
                {
                    b.Property<int>("EmailId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerCustomerId");

                    b.Property<string>("EmailAddress");

                    b.Property<bool>("IsPrimary");

                    b.HasKey("EmailId");
                });

            modelBuilder.Entity("TopAtlantaRealEstate.Models.Phone", b =>
                {
                    b.Property<int>("PhoneId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerCustomerId");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PhoneType");

                    b.HasKey("PhoneId");
                });

            modelBuilder.Entity("TopAtlantaRealEstate.Models.Email", b =>
                {
                    b.HasOne("TopAtlantaRealEstate.Models.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerCustomerId");
                });

            modelBuilder.Entity("TopAtlantaRealEstate.Models.Phone", b =>
                {
                    b.HasOne("TopAtlantaRealEstate.Models.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerCustomerId");
                });
        }
    }
}
