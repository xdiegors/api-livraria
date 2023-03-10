// <auto-generated />
using System;
using Livraria.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Livraria.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230115121338_migracaoInicial")]
    partial class migracaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Livraria.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Livraria.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Livraria.Models.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Ano")
                        .HasColumnType("TEXT");

                    b.Property<int?>("AutorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("Livraria.Models.Livro", b =>
                {
                    b.HasOne("Livraria.Models.Autor", null)
                        .WithMany("Livros")
                        .HasForeignKey("AutorId");

                    b.HasOne("Livraria.Models.Categoria", null)
                        .WithMany("Livros")
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("Livraria.Models.Autor", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("Livraria.Models.Categoria", b =>
                {
                    b.Navigation("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}
