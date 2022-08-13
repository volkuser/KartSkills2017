using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace App.Models;

public sealed class ApplicationContext : DbContext
{
    public DbSet<Gender>? Genders { get; set; }
    public DbSet<Country>? Countries { get; set; }
    public DbSet<Sponsorship>? Sponsorships { get; set; }
    public DbSet<Racer>? Racers { get; set; }
    public DbSet<Charity>? Charities { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<DbFile>? DbFiles { get; set; }
    
    public ApplicationContext() { }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseMySql("server=localhost;user=root;password=iuh;database=KartSkills2017;", 
                new MySqlServerVersion(new Version(15, 1)));
    }
    
    public static bool IsValid(object args)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(args);
        if (!Validator.TryValidateObject(args, context, results, true))
            return false;
        return true;
    }
}