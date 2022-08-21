﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShop.DataLayer.Entities;

namespace MyShop.DataLayer.Context
{
    public class MyShopContext:DbContext
    {
        public MyShopContext(DbContextOptions<MyShopContext> options) : base(options)
        {

        }

        #region User

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        #endregion

        #region Product

        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentDocument> AgentDocuments { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Agent)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.AgentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}