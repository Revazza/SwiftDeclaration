﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwiftDeclaration.Persistance.Context;

#nullable disable

namespace SwiftDeclaration.Persistance.Migrations
{
    [DbContext(typeof(SwiftDeclarationDbContext))]
    [Migration("20240118133847_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SwiftDeclaration.Domain.Entities.Declarations.Declaration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("HeadLine")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("HeadLine");

                    b.ToTable("Declarations");
                });

            modelBuilder.Entity("SwiftDeclaration.Domain.Entities.Declarations.Declaration", b =>
                {
                    b.OwnsOne("SwiftDeclaration.Domain.ValueObjects.Images.Image", "Image", b1 =>
                        {
                            b1.Property<int>("DeclarationId")
                                .HasColumnType("int");

                            b1.Property<byte[]>("Data")
                                .IsRequired()
                                .HasColumnType("varbinary(max)");

                            b1.Property<string>("FileName")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("nvarchar(256)");

                            b1.HasKey("DeclarationId");

                            b1.ToTable("Declarations");

                            b1.WithOwner()
                                .HasForeignKey("DeclarationId");
                        });

                    b.Navigation("Image")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
