using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoMuaiClinet.Models;

namespace ToDoMuaiClinet.DataServices
{
    public class RestDataService : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddres;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestDataService()
        {
            _httpClient = new HttpClient();
            _baseAddres = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "https://localhost:5001";
            _url = $"{_baseAddres}/api";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }


        public async Task AddTaskAsync(ToDo toDo)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("--> No internet");
                return;
            }

            try
            {
                string jsonToDo = JsonSerializer.Serialize(toDo, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonToDo, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/todo", content);

                if (response.IsSuccessStatusCode) Debug.Write("Created"); 

            } catch(Exception ex) 
            {
               Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        public Task DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ToDo>> GetAllToDoAsync()
        {
            List<ToDo> toDos = new List<ToDo>();

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("--> No internet");
                return toDos;
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/todo");

            try
            {
                if (!response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    toDos = JsonSerializer.Deserialize<List<ToDo>>(content, _jsonSerializerOptions);

                }
                else
                {
                    Debug.WriteLine($"Response code: {response.StatusCode}");
                }
            }
            catch(Exception ex) 
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }


            return toDos;
        }

        public Task UpdateTaskAsync(ToDo toDo)
        {
            throw new NotImplementedException();
        }
    }
}
