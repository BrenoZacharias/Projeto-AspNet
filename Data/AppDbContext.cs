using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Loja_Sapatos.Models;

namespace Projeto_Loja_Sapatos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedor>()
                .Property(p => p.Nome)
                .HasMaxLength(200);

            modelBuilder.Entity<Fornecedor>()
                .Property(p => p.Endereco)
                .HasMaxLength(200);

            modelBuilder.Entity<Fornecedor>()
                .Property(p => p.CNPJ)
                .HasMaxLength(14)
                .IsRequired();

            modelBuilder.Entity<Modelo>()
                .Property(p => p.id_fornecedor).IsRequired();

            modelBuilder.Entity<Modelo>()
                .Property(p => p.id_categoria).IsRequired();

            modelBuilder.Entity<Modelo>()
                .Property(p => p.valor).IsRequired();

            modelBuilder.Entity<Modelo>()
                .Property(p => p.codigoRef)
                .HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Modelo>()
                .Property(p => p.cor)
                .HasMaxLength(50);

            modelBuilder.Entity<Modelo>()
                .Property(p => p.tamanho);


            modelBuilder.Entity<Estoque>()
                .Property(p => p.Id_Modelo).IsRequired();

            modelBuilder.Entity<Estoque>()
                .Property(p => p.Qtd).IsRequired();


            modelBuilder.Entity<Categoria>()
                .Property(p => p.Nome)
                .HasMaxLength(100).IsRequired();


            modelBuilder.Entity<Cliente>()
                .Property(p => p.Nome)
                .HasMaxLength(300);

            modelBuilder.Entity<Cliente>()
                .Property(p => p.CPF)
                .HasMaxLength(11).IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(p => p.Endereco)
                .HasMaxLength(300).IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(p => p.Sexo)
                .HasMaxLength(1);


            modelBuilder.Entity<Venda>()
                .Property(p => p.id_modelo).IsRequired();

            modelBuilder.Entity<Venda>()
                .Property(p => p.id_cliente).IsRequired();

            modelBuilder.Entity<Venda>()
                .Property(p => p.quantidade).IsRequired();

            modelBuilder.Entity<Venda>()
                .Property(p => p.dtVenda)
                .IsRequired();
        }
    }
}
