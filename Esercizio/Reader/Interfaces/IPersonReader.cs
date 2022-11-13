using Esercizio.Reader.Models;

namespace Esercizio.Reader.Interfaces
{
    public interface IPersonReader
    {
        List<PersonRead> Read();
        PersonRead Add(string name, int age);
    }
}
