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

            //modelBuilder.Entity<Fornecedor>()
            //    .Property(p => p.Id);

            modelBuilder.Entity<Modelo>()
                .HasData(
                    new Modelo { codigoRef="batatinha123", cor="Amarelo", id_fornecedor=1, nome="Round6",
                    tamanho=42, id=1}
                );

            modelBuilder.Entity<Fornecedor>()
                .HasData(
                    new Fornecedor
                    {
                        CNPJ = "00000000000100",
                        Endereco = "Rua da Tia Cotinha, 230",
                        Nome = "Netflix",
                        Id = 1
                    }, new Fornecedor
                    {
                        CNPJ = "11111111000111",
                        Endereco = "Rua da Tio Manuel, 222",
                        Nome = "Amazon Prime Video",
                        Id = 2
                    }

                );
        }
    }
}
