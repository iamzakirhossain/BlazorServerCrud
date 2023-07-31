using BlazorServerCrud.Models;

namespace BlazorServerCrud.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetPersons();
        Task<Person> GetPerson(int id);
        Task<string> UpdatePerson(int id, Person person);
        Task<string> PostPerson(Person person);
        Task<string> DeletePerson(int id);
    }
}
