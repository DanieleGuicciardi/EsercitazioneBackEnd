using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Anagrafica> Anagrafica { get; set; }
    public DbSet<TipoViolazione> TipiViolazione { get; set; }
    public DbSet<Verbale> Verbale { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Verbale>()
            .HasOne(v => v.Anagrafica)
            .WithMany(a => a.Verbali)
            .HasForeignKey(v => v.IdAnagrafica);

        modelBuilder.Entity<Verbale>()
            .HasOne(v => v.TipoViolazione)
            .WithMany(tv => tv.Verbali)
            .HasForeignKey(v => v.IdViolazione);
    }
}
