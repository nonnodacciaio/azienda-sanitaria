using Esercizio.Repositories.Models;

namespace Esercizio.Repositories.Interfaces
{
    public interface IPersonsRepository
    {
        List<Person> Persons { get; }
        IEnumerable<Person> PersonsBetween50and60 { get; }
        IEnumerable<Person> PersonsBetween60and70 { get; }

        IEnumerable<Person> PersonsNameBeginningWith(string firstLetter);

        Person Add(string name, int age);
    }
}
