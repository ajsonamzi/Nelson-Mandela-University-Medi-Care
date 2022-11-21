using MediCare2._0.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MediCare2._0.Models;

namespace MediCare2._0.Data;

public class MediCare2_0Context : IdentityDbContext<MediCare2_0User>
{
    public MediCare2_0Context(DbContextOptions<MediCare2_0Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }

    public DbSet<MediCare2._0.Models.Company> Company { get; set; }

    public DbSet<MediCare2._0.Models.Drug> Drug { get; set; }

    public DbSet<MediCare2._0.Models.DrugAdmin> DrugAdmin { get; set; }

    public DbSet<MediCare2._0.Models.Phase> Phase { get; set; }

    public DbSet<MediCare2._0.Models.Region> Region { get; set; }

    public DbSet<MediCare2._0.Models.Schedule> Schedule { get; set; }

    public DbSet<MediCare2._0.Models.SideEffect> SideEffect { get; set; }

    public DbSet<MediCare2._0.Models.Symptom> Symptom { get; set; }

    public DbSet<MediCare2._0.Models.Alternative> Alternative { get; set; }

    public DbSet<MediCare2._0.Models.Contraindication> Contraindiction { get; set; }

}
