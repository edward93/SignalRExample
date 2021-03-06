﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using PushAPI.DAL.Entities;

namespace PushAPI.DAL.Context
{
    public class EntityDbContext : Microsoft.EntityFrameworkCore.DbContext, IEntityDbContext
    {
        public EntityDbContext(DbContextOptions<EntityDbContext> options)
            : base(options)
        {
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<SystemMessage> SystemMessages { get; set; }
    }
}