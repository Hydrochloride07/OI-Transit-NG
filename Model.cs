using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

public class TransContext : DbContext
{
    public DbSet<Problem> Problems { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\Ikarus\\source\\repos\\DynTransit\\wwwroot\\db\\transit.sqlite");
    }
}

[Table("Problems")]
public class Problem
{
    [Key]
    [Required]
    public int Id { get; set; } = 0;

    public string Name { get; set; } = "";
    public string Url { get; set; } = "";
    public string Date { get; set; } = "";

    public string Tags { get; set; } = "";
    public string Descriptions { get; set; } = "[]";
    public string Solutions { get; set; } = "[]";
    public string Comments { get; set; } = "[]";

    public int RelatedProblem { get; set; } = 0;
}

[Table("Tags")]
public class Tag
{
    [Key]
    [Required]
    public string Name { get; set; } = "";

    public string Comments { get; set; } = "";
    public string LastVisit { get; set; } = "00.00.00";
}