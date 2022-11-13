using Esercizio.Repositories.Models;
using Esercizio.Services.Models;
using Eserczio.Configuration;

namespace Esercizio.Extensions;

public static class PersonsExtension
{
    public static IEnumerable<SvcPersonExt> ToPersonsExt(this IEnumerable<Person> persons, IEnumerable<Address> addresses)
    {
        if (persons == null)
        {
            yield break;
        }

        foreach (var person in persons)
        {
            yield return person.ToPersonExt(addresses);
        }
    }

    public static SvcPersonExt ToPersonExt(this Person person, IEnumerable<Address> addresses)
    {
        var address = addresses.FirstOrDefault(address => address.Name == person.Name) != null ?
            addresses.FirstOrDefault(address => address.Name == person.Name).StreetName : Config.Settings.NullAddressIfNameNotFound ? null : "";

        return new SvcPersonExt()
        {
            Address = address,
            Age = person.Age,
            Name = person.Name
        };
    }

    public static IEnumerable<Person> FilterByAge(this IEnumerable<Person> persons, int lowerAge, int higherAge)
    {
        return persons.Where(person => person.Age >= lowerAge && person.Age <= higherAge);
    }

    public static IEnumerable<Person> FilterByFirstLetter(this IEnumerable<Person> persons, string letter)
    {
        return persons.Where(person => person.Name.StartsWith(letter));
    }
}
