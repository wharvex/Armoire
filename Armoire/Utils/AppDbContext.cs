﻿using System;
using System.Diagnostics;
using System.Linq;
using Armoire.Models;
using Microsoft.EntityFrameworkCore;

namespace Armoire.Utils;

// https://medium.com/@PoulLorca/integrating-entity-framework-with-avalonia-ui-using-sqlite-a-gentle-introduction-8fdf4772a2c9
public class AppDbContext : DbContext
{
    public DbSet<Drawer> Drawers { get; set; }
    public DbSet<Item> Items { get; set; }
    public string DbPath { get; }
    private const bool CanSave = true;
    private const bool CanInspect = true;

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "ArmoireData.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Data Source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<Drawer>()
            .HasOne(d => d.Parent)
            .WithMany(d => d.Drawers)
            .HasForeignKey(d => d.ParentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<Item>()
            .HasOne(d => d.Parent)
            .WithMany(d => d.Items)
            .HasForeignKey(d => d.ParentId);
    }

    public bool TryAddDrawer(Drawer drawer)
    {
        if (!CanInspect)
            return false;
        if (Drawers.Any(d => d.Id == drawer.Id))
        {
            Debug.WriteLine("Drawer already exists; skipping...");
            return false;
        }
        Drawers.Add(drawer);
        return true;
    }

    public bool TryAddItem(Item item)
    {
        if (!CanInspect)
            return false;
        if (Items.Any(i => i.Id == item.Id))
        {
            Debug.WriteLine("Item already exists; skipping...");
            return false;
        }
        Items.Add(item);
        return true;
    }

    public override int SaveChanges()
    {
        return !CanSave ? 0 : base.SaveChanges();
    }
}
