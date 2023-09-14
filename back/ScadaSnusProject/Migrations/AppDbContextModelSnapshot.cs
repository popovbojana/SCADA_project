﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScadaSnusProject.DbContext;

#nullable disable

namespace ScadaSnusProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("ScadaSnusProject.Model.Alarm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActivatedTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.ToTable("Alarms");
                });

            modelBuilder.Entity("ScadaSnusProject.Model.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IOAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Tag");
                });

            modelBuilder.Entity("ScadaSnusProject.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ScadaSnusProject.Model.AnalogInput", b =>
                {
                    b.HasBaseType("ScadaSnusProject.Model.Tag");

                    b.Property<double>("HighLimit")
                        .HasColumnType("REAL")
                        .HasColumnName("AnalogInput_HighLimit");

                    b.Property<bool>("IsScanOn")
                        .HasColumnType("INTEGER")
                        .HasColumnName("AnalogInput_IsScanOn");

                    b.Property<double>("LowLimit")
                        .HasColumnType("REAL")
                        .HasColumnName("AnalogInput_LowLimit");

                    b.Property<string>("ScanTime")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("AnalogInput_ScanTime");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("AnalogInput_Unit");

                    b.HasDiscriminator().HasValue("AnalogInput");
                });

            modelBuilder.Entity("ScadaSnusProject.Model.AnalogOutput", b =>
                {
                    b.HasBaseType("ScadaSnusProject.Model.Tag");

                    b.Property<double>("HighLimit")
                        .HasColumnType("REAL");

                    b.Property<double>("LowLimit")
                        .HasColumnType("REAL");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("AnalogOutput");
                });

            modelBuilder.Entity("ScadaSnusProject.Model.DigitalInput", b =>
                {
                    b.HasBaseType("ScadaSnusProject.Model.Tag");

                    b.Property<bool>("IsScanOn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ScanTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("DigitalInput");
                });

            modelBuilder.Entity("ScadaSnusProject.Model.DigitalOutput", b =>
                {
                    b.HasBaseType("ScadaSnusProject.Model.Tag");

                    b.HasDiscriminator().HasValue("DigitalOutput");
                });

            modelBuilder.Entity("ScadaSnusProject.Model.Alarm", b =>
                {
                    b.HasOne("ScadaSnusProject.Model.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");
                });
#pragma warning restore 612, 618
        }
    }
}
