using Newtonsoft.Json;
using Project1WpfMVVM.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Project1WpfMVVM.Services
{
    public class AuthorServiceWpf
    {
        public readonly string BASEAUTHORURL = "https://localhost:7034/api/Author/";
        public readonly string GETALLAUTHORS = "GetAllAuthors";
        public readonly string GETAUTHORBYNAME = "GetAuthorByName/";
        public readonly string DELETEAUTHORBYNAME = "DeleteAuthor/";
        public readonly string UPDATEAUTHORBYNAME = "UpdateAuthor/";
        public readonly string ADDAUTHOR = "AddAuthor";

        public async Task<List<Author>> GetAllAuthors()
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetFromJsonAsync<List<Author>>($"{BASEAUTHORURL}{GETALLAUTHORS}");
            }
        }

        public async Task<Author> GetAuthor(string name)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{BASEAUTHORURL}{GETAUTHORBYNAME}{name}";
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Author author = JsonConvert.DeserializeObject<Author>(jsonResponse);
                        return author;
                    }
                    else
                    {
                        // Handle non-successful response here, e.g., log or throw an exception.
                        throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public async Task<bool> DeleteAuthor(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{BASEAUTHORURL}{DELETEAUTHORBYNAME}{name}");
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(jsonResponse);
            }
        }

        public async Task<bool> AddAuthor(Author author)
        {
            //string json = JsonConvert.SerializeObject(author, Formatting.Indented);
            //var httpContent = new StringContent(json);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync($"{BASEAUTHORURL}{ADDAUTHOR}", author);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(jsonResponse);
            }
        }

        public async Task<bool> UpdateAuthor(string name, Author author)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"{BASEAUTHORURL}{UPDATEAUTHORBYNAME}{name}", author);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(jsonResponse);
            }
        }
    }
}