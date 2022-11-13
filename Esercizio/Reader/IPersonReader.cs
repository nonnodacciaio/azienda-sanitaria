using Esercizio.Reader.Models;

namespace Esercizio.Reader;

public class IPersonReader
{
    List<PersonRead> Read();
    PersonRead Add(string name, int age);
}
