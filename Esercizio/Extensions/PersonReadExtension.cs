using Esercizio.Reader.Models;
using Esercizio.Repositories.Models;

namespace Esercizio.Extensions;

public static class PersonReadExtension
{
    public static Person ToPerson(this PersonRead personRead)
    {
        return new Person(personRead.Name, personRead.Age);
    }
}
