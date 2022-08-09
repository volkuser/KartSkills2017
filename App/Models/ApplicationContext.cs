using System;
using Microsoft.EntityFrameworkCore;

namespace App.Models;

public sealed class ApplicationContext : DbContext
{
    public DbSet<Gender>? Genders { get; set; }
    public DbSet<Country>? Countries { get; set; }
    public DbSet<Sponsorship>? Sponsorships { get; set; }
    public DbSet<Racer>? Racers { get; set; }
    public DbSet<Charity>? Charities { get; set; }
    
    public ApplicationContext() { }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseMySql("server=localhost;user=root;password=iuh;database=KartSkills2017;", 
                new MySqlServerVersion(new Version(15, 1)));
    }
}