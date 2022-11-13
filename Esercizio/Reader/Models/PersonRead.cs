namespace Esercizio.Reader.Models
{
    public interface PersonRead
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? SurName { get; set; }
        public int Age { get; set; }
    }
}
