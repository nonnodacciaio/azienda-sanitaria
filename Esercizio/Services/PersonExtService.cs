using Esercizio.Extensions;
using Esercizio.Repositories.Interfaces;
using Esercizio.Repositories.Models;
using Esercizio.Services.Models;

namespace Esercizio.Services;

public class PersonExtService
{
    IPersonsRepository personsRepository;
    IAddressesRepository addressesRepository;

    public PersonExtService(IPersonsRepository personsRepository, IAddressesRepository addressesRepository)
    {
        this.personsRepository = personsRepository;
        this.addressesRepository = addressesRepository;
    }

    public IEnumerable<SvcPersonExt> PersonsExt => personsRepository.Persons.ToPersonsExt(addressesRepository.Addresses);
    public IEnumerable<SvcPersonExt> PersonsEsameColesterolo => personsRepository.PersonsBetween50and60.ToPersonsExt(addressesRepository.Addresses);
    public IEnumerable<SvcPersonExt> PersonsEsameProstata => personsRepository.PersonsBetween60and70.ToPersonsExt(addressesRepository.Addresses);
    public IEnumerable<SvcPersonExt> GetPersonsNameBeginningWith(string firstLetter)
    {
        return personsRepository.PersonsNameBeginningWith(firstLetter).ToPersonsExt(addressesRepository.Addresses);
    }
    public SvcPersonExt AddPerson(string name, int age, string address)
    {
        var newPerson = personsRepository.Add(name, age);
        var newAddress = addressesRepository.Add(name, address);

        return newPerson.ToPersonExt(new List<Address>() { newAddress });
    }
}
