using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoFinal.Services
{
    internal class ApiService
    {
        private readonly HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost/api/");
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var loginData = new { username, password };
            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _client.PostAsync("http://localhost/api/auth/login.php", content);

                if (response.IsSuccessStatusCode)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en LoginAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            var userData = new { username, email, password };
            var json = JsonConvert.SerializeObject(userData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _client.PostAsync("http://localhost/api/auth/register.php", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;

                    
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en RegisterAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ReadBusinessesAsync()
        {
            var userData = new { };
            var json = JsonConvert.SerializeObject(userData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _client.PostAsync("http://localhost/api/businesses/read.php", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;


                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en RegisterAsync: {ex.Message}");
                return false;
            }
        }

        // Clase para deserializar la respuesta del token
        private class TokenResponse
        {
            public string Token { get; set; }
        }


    }
}
