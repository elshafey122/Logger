using System.Net.Http.Json;
namespace LoggerUi.Service
{
    public class DataService
    {
        public async Task<List<string>> GetEmployees()
        {
            List<string>? data;
            HttpClient client = new HttpClient();
            data = await client.GetFromJsonAsync<List<string>>($"https://localhost:7041/api/Logger/GetFromFile");
            return data;
        }
    }
}
