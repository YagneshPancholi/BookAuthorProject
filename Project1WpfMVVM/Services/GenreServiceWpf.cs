using Newtonsoft.Json;
using Project1WpfMVVM.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Project1WpfMVVM.Services
{
    public class GenreServiceWpf
    {
        public readonly string BASEGENREURL = "https://localhost:7034/api/Genre/";
        public readonly string GETALLGENRES = "GetAllGenres";
        public readonly string DELETEGENREBYNAME = "DeleteGenre/";
        public readonly string ADDGENRE = "AddGenre";

        public async Task AddGenre(Genre request)
        {
            string json = JsonConvert.SerializeObject(request, Formatting.Indented);
            var httpContent = new StringContent(json);
            using (HttpClient client = new HttpClient())
            {
                await client.PostAsync($"{BASEGENREURL}{ADDGENRE}", httpContent);
            }
        }

        public async Task<bool> DeleteGenre(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{BASEGENREURL}{DELETEGENREBYNAME}{name}");
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(jsonResponse);
            }
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetFromJsonAsync<List<Genre>>($"{BASEGENREURL}{GETALLGENRES}");
            }
        }
    }
}