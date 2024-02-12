using Newtonsoft.Json;
using Project1WpfMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Project1WpfMVVM.Services
{
    public class PublisherServiceWpf
    {
        public readonly string BASEPUBLISHErURL = "https://localhost:7034/api/Publisher/";
        public readonly string GETALLPUBLISHErS = "GetAllPublishers";
        public readonly string DELETEPUBLISHErBYNAME = "DeletePublisher/";
        public readonly string ADDPUBLISHEr = "AddPublisher";

        public async Task AddPublisher(Publisher request)
        {
            using (HttpClient client = new HttpClient())
            {
                await client.PostAsJsonAsync<Publisher>($"{BASEPUBLISHErURL}{ADDPUBLISHEr}", request);
            }
        }

        public async Task<bool> DeletePublisher(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{BASEPUBLISHErURL}{DELETEPUBLISHErBYNAME}{name}");
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(jsonResponse);
            }
        }

        public async Task<List<Publisher>> GetAllPublishers()
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetFromJsonAsync<List<Publisher>>($"{BASEPUBLISHErURL}{GETALLPUBLISHErS}");
            }
        }
    }
}