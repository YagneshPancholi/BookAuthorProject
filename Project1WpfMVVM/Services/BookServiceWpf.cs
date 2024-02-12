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
    public class BookServiceWpf
    {
        public readonly string BASEBOOKURL = "https://localhost:7034/api/Book/";
        public readonly string GETALLBOOKS = "GetAllBooks";
        public readonly string GETBOOKBYNAME = "GetBookByName/";
        public readonly string DELETEBOOKBYNAME = "DeleteBook/";
        public readonly string UPDATEBOOKBYNAME = "UpdateBook/";
        public readonly string ADDBOOK = "AddBook";

        public async Task<List<Book>> GetAllBooks()
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetFromJsonAsync<List<Book>>($"{BASEBOOKURL}{GETALLBOOKS}");

                //string jsonResponse = await response.Content.ReadAsStringAsync();

                //List<Book> books = JsonConvert.DeserializeObject<List<Book>>(jsonResponse);
                //return books;
            }
        }

        public async Task<Book> GetBook(string name)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{BASEBOOKURL}{GETBOOKBYNAME}{name}";
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Book book = JsonConvert.DeserializeObject<Book>(jsonResponse);
                        return book;
                    }
                    else
                    {
                        MessageBox.Show($"HTTP request failed with status code {response.StatusCode}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public async Task<bool> DeleteBook(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{BASEBOOKURL}{DELETEBOOKBYNAME}{name}");
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(jsonResponse);
            }
        }

        public async Task<bool> AddBook(Book book)
        {
            //string json = JsonConvert.SerializeObject(author, Formatting.Indented);
            //var httpContent = new StringContent(json);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync($"{BASEBOOKURL}{ADDBOOK}", book);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(jsonResponse);
            }
        }

        public async Task<bool> UpdateBook(string name, Book book)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"{BASEBOOKURL}{UPDATEBOOKBYNAME}{name}", book);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(jsonResponse);
            }
        }
    }
}