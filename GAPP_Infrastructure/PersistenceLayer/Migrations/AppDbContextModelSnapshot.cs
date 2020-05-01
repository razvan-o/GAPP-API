﻿// <auto-generated />
using System;
using GAPP_Infrastructure.PersistenceLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GAPP_Infrastructure.PersistenceLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GAPP_Infrastructure.Domain.InstagramAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InstagramAccounts");
                });

            modelBuilder.Entity("GAPP_Infrastructure.Domain.InstagramPost", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CommentsCount")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hashtags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("InstagramAccountId")
                        .HasColumnType("bigint");

                    b.Property<long>("LikesCount")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstagramAccountId");

                    b.ToTable("InstagramPosts");
                });

            modelBuilder.Entity("GAPP_Infrastructure.Domain.InstagramPost", b =>
                {
                    b.HasOne("GAPP_Infrastructure.Domain.InstagramAccount", "InstagramAccount")
                        .WithMany("Instagramposts")
                        .HasForeignKey("InstagramAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}