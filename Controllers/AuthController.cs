using ProyectoFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoFinal.Controllers
{
    internal class AuthController
    {

        private readonly ApiService _apiService;

        public AuthController()
        {
            _apiService = new ApiService();
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            return await _apiService.LoginAsync(username, password);
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            return await _apiService.RegisterAsync(username, email, password);
        }

    }
}
