using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Esercizio.Controllers;

[Produces("application/json")]
[Route("api.esercizio/v1/[controller]/[action]")]
public class EsercizioController : ControllerBase
{
    private readonly PersonExtService personService;

    public EsercizioController(PersonExtService personService)
    {
        this.personService = personService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(SvcPersonExt[]), 200)]
    public async Task<IActionResult> GetPersons()
    {
        return new JsonResult(personService.PersonsExt.ToArray());
    }

    [HttpGet]
    [ProducesResponseType(typeof(SvcPersonExt[]), 200)]
    public async Task<IActionResult> GetPersonsEsameColesterolo()
    {
        return new JsonResult(personService.PersonsEsameColesterolo.ToArray());
    }

    [HttpGet]
    [ProducesResponseType(typeof(SvcPersonExt[]), 200)]
    public async Task<IActionResult> GetPersonsEsameProstata()
    {
        return new JsonResult(personService.PersonsEsameProstata.ToArray());
    }

    [HttpGet]
    [ModelValidate]
    [ProducesResponseType(typeof(SvcPersonExt[]), 200)]
    public async Task<IActionResult> GetPersonsNameBeginningWith([MaxLength(1), Required] string firstLetter)
    {
        return new JsonResult(personService.GetPersonsNameBeginningWith(firstLetter).ToArray());
    }

    [HttpPost]
    [ProducesResponseType(typeof(SvcPersonExt[]), 200)]
    public async Task<IActionResult> AddPerson(string name, int age, string streetAddress)
    {
        try
        {
            var newPerson = personService.AddPerson(name, age, streetAddress);
            return new JsonResult(newPerson);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore nel salvataggio del nuovo utente con nome {name}: {ex.Message}");
            return new JsonResult(ex);
        }
    }
}
