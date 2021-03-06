﻿using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Montando as migrations 

            modelBuilder.Entity<Produto>().HasKey(t => t.Id);

            modelBuilder.Entity<Pedido>().HasKey(t => t.Id);
            modelBuilder.Entity<Pedido>()
                .HasMany(t => t.Itens)
                .WithOne(t => t.Pedido);

           
            modelBuilder.Entity<Pedido>()
                .HasOne(t => t.Cadastro)
                .WithOne(t => t.Pedido)
                .HasForeignKey<Pedido>(t => t.CadastroId)
                .IsRequired();

            modelBuilder.Entity<ItemPedido>().HasKey(t => t.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Produto);

            modelBuilder.Entity<Cadastro>().HasKey(t => t.Id);
            modelBuilder.Entity<Cadastro>().HasOne(t => t.Pedido);

        }
    }
}
