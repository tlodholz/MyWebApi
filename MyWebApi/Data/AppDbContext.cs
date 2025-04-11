﻿using Microsoft.EntityFrameworkCore;
using MyWebApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Project> Projects { get; set; }
}

