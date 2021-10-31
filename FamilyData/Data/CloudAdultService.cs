using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace FamilyData.Data {
    public class CloudAdultService : IAdultService {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;
        public IList<Adult> Adults { get; }

        public CloudAdultService() {
            client = new HttpClient();
        }

        public async Task<IList<Adult>> GetAdults() {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + "/adults");
            Console.WriteLine("getting adults");
            if (!responseMessage.IsSuccessStatusCode) {
                throw new Exception("Error getting adults");
            }

            string message = await responseMessage.Content.ReadAsStringAsync();
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task AddAdult(Adult adult) {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/adults", content);
            if (!responseMessage.IsSuccessStatusCode) {
                throw new Exception($"Error, {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            }
        }

        public async Task RemoveAdult(int id) {
            HttpResponseMessage responseMessage = await client.DeleteAsync($"{uri}/adults/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public Task EditAdult(Adult adult) {
            throw new System.NotImplementedException();
        }

        public Adult Get(int id) {
            throw new System.NotImplementedException();
        }
    }
}