// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_biblioteca.Models;

namespace WebAPI_biblioteca.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220929210022_PrimeiraMigration")]
    partial class PrimeiraMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("WebAPI_biblioteca.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmprestimoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmprestimoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("WebAPI_biblioteca.Models.Emprestimo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataEmprestimo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("WebAPI_biblioteca.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmprestimoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmprestimoId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("WebAPI_biblioteca.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GeneroLivro")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("WebAPI_biblioteca.Models.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Autor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Editora")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GenerosId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ISBN")
                        .HasColumnType("TEXT");

                    b.Property<int>("Paginas")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Publicacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GenerosId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("WebAPI_biblioteca.Models.Cliente", b =>
                {
                    b.HasOne("WebAPI_biblioteca.Models.Emprestimo", null)
                        .WithMany("Clientes")
                        .HasForeignKey("EmprestimoId");
                });

            modelBuilder.Entity("WebAPI_biblioteca.Models.Funcionario", b =>
                {
                    b.HasOne("WebAPI_biblioteca.Models.Emprestimo", null)
                        .WithMany("Funcionarios")
                        .HasForeignKey("EmprestimoId");
                });

            modelBuilder.Entity("WebAPI_biblioteca.Models.Livro", b =>
                {
                    b.HasOne("WebAPI_biblioteca.Models.Genero", "Generos")
                        .WithMany("Livros")
                        .HasForeignKey("GenerosId");

                    b.Navigation("Generos");
                });

            modelBuilder.Entity("WebAPI_biblioteca.Models.Emprestimo", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("WebAPI_biblioteca.Models.Genero", b =>
                {
                    b.Navigation("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}
