namespace Esercizio.Reader;

internal class DbContextInitializer
{
    private readonly EsercizioDbContext dbContext;

    public DbContextInitializer(EsercizioDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Initialize()
    {
        if (!dbContext.PersonsRead.Any())
        {
            var initialPersons = new JsonPersonReader().Read();
            foreach (PersonRead person in initialPersons)
            {
                dbContext.PersonsRead.Add(person);
            }
            dbContext.SaveChanges();
        }
    }
}
