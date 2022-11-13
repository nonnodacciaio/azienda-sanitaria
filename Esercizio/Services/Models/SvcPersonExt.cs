namespace Esercizio.Services.Models;

public class SvcPersonExt
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string? Address { get; set; }

    public override string ToString()
    {
        return $"Nome: {Name}, Età: {Age}, Indirizzo: {Address}";
    }
}
