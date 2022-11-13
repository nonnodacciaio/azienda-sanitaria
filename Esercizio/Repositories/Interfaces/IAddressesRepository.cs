using Esercizio.Repositories.Models;

namespace Esercizio.Repositories.Interfaces
{
    public interface IAddressesRepository
    {
        List<Address> Addresses { get; }
        Address Add(string name, string address);
    }
}
