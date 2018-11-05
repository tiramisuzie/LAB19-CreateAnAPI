﻿// <auto-generated />
using System;
using LAB19CreateAnAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LAB19CreateAnAPI.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20181105003059_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LAB19CreateAnAPI.Data.Todo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsComplete");

                    b.Property<int>("ListId");

                    b.Property<string>("Name");

                    b.Property<long?>("TodoListId");

                    b.HasKey("Id");

                    b.HasIndex("TodoListId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("LAB19CreateAnAPI.Data.TodoList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TodoList");
                });

            modelBuilder.Entity("LAB19CreateAnAPI.Data.Todo", b =>
                {
                    b.HasOne("LAB19CreateAnAPI.Data.TodoList")
                        .WithMany("Items")
                        .HasForeignKey("TodoListId");
                });
#pragma warning restore 612, 618
        }
    }
}
