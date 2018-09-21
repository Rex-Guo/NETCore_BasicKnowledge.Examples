﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORMDemo.EF;

namespace ORMDemo.EF.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20180914030247_TestRelationshipConventions")]
    partial class TestRelationshipConventions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ORMDemo.EF.Model.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BlogId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Rating");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnName("Url")
                        .HasMaxLength(500);

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("ORMDemo.EF.Model.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogId");

                    b.Property<string>("Content")
                        .HasMaxLength(500);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ORMDemo.EF.Model.PostExtension", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<string>("ExtensionField1");

                    b.HasKey("PostId");

                    b.ToTable("PostExtensions");
                });

            modelBuilder.Entity("ORMDemo.EF.Model.Post", b =>
                {
                    b.HasOne("ORMDemo.EF.Model.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ORMDemo.EF.Model.PostExtension", b =>
                {
                    b.HasOne("ORMDemo.EF.Model.Post", "Post")
                        .WithOne("Extension")
                        .HasForeignKey("ORMDemo.EF.Model.PostExtension", "PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
