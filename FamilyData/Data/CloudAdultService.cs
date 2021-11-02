using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FamilyData.Models;
using Models;

namespace FamilyData.Data {
    public class CloudAdultService : IAdultService {
        private string uri = "https://localhost:5003";
        private HttpClient client;
        public IList<Adult> Adults { get; }

        public CloudAdultService() {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => {
                return true;
            };
            
            client = new HttpClient(clientHandler);
        }

        public async Task<IList<Adult>> GetAdults() {
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5003/Adults");
            if (!responseMessage.IsSuccessStatusCode) {
                throw new Exception("Error getting adults");
            }

            string message = await responseMessage.Content.ReadAsStringAsync();
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task AddAdult(Adult adult) {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(
                adultAsJson,
                Encoding.UTF8,
                "application/json"
                );
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/adults", content);
            if (!responseMessage.IsSuccessStatusCode) {
                throw new Exception($"Error, {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public async Task RemoveAdult(int id) {
            HttpResponseMessage responseMessage = await client.DeleteAsync($"{uri}/adults/{id}");
            Console.WriteLine("removing adult with id" + id);
            if (!responseMessage.IsSuccessStatusCode) {
                throw new Exception($"Error, {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public Task EditAdult(Adult adult) {
            throw new System.NotImplementedException();
        }

        public async Task<Adult> Get(int id) {
            
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/adults/{id}");
            if (!responseMessage.IsSuccessStatusCode) {
                throw new Exception($"Error, {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
            string message = await responseMessage.Content.ReadAsStringAsync();
            Adult adult = JsonSerializer.Deserialize<Adult>(message);
            return adult;
        }
    }
}