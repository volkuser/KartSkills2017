using System;
using Microsoft.EntityFrameworkCore;

namespace App.Models;

public sealed class ApplicationContext : DbContext
{
    public DbSet<Gender>? Genders { get; set; }
    public DbSet<Country>? Countries { get; set; }
    public DbSet<Sponsorship>? Sponsorships { get; set; }
    public DbSet<Racer>? Racers { get; set; }
    
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=iuh;database=KartSkills2017;", 
            new MySqlServerVersion(new Version(15, 1)));
    }
}