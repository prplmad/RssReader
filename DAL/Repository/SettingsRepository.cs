using DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace DAL.Repository
{
    public class SettingsRepository
    {
        private readonly IConfiguration _configuration;

        public SettingsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
