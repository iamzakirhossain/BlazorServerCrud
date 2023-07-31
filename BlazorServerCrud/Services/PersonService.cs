using BlazorServerCrud.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerCrud.Services
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _httpClient;
        public PersonService(HttpClient httpClient, 
            NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new Uri("https://localhost:7077/");
            _httpClient.BaseAddress = new Uri(navigationManager.BaseUri);
        }

        public async Task<IEnumerable<Person>> GetPersons()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Person>>("api/persons");

            return result!;
        }

        public async Task<Person> GetPerson(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Person>($"api/persons/{id}");

            return result!;
        }

        public async Task<string> UpdatePerson(int id, Person person)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/persons/{id}", person);

            return "Success";
        }

        public async Task<string> PostPerson(Person person)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/persons", person);

            return "Success";
        }

        public async Task<string> DeletePerson(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/persons/{id}");

            return "Success";
        }

    }
}
