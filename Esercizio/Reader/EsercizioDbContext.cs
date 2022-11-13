using Esercizio.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Esercizio.Reader;

public class EsercizioDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql(Config.Settings.DbConnectionString, ServerVersion.AutoDetect(Config.Settings.DbConnectionString));

    public EsercizioDbContext(DbContextOptions<EsercizioDbContext> options) : base(options)
    {

    }

    public DbSet<PersonRead> PersonsRead { get; set; }
}
