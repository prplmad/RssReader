using BL.Abstract;
using BL.Models;
using Microsoft.Extensions.Configuration;

namespace BL.Services
{
    public class FeedService : IFeedService
    {
        private readonly IConfiguration _configuration;

        public FeedService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Settings ChooseSourceForSettings(Settings settings)
        {
            if (settings == null)
            {
                settings = new Settings();
                settings.Url[0] = _configuration.GetSection("RSSUrl").Value;

                if (_configuration.GetSection("DescriptionTags").Value == "true")
                {
                    settings.DescriptionTags = true;
                }
                else
                {
                    settings.DescriptionTags = false;
                }
                int UpdateTime;
                bool success = int.TryParse(_configuration.GetSection("UpdateTime").Value, out UpdateTime);
                if (success)
                {
                    settings.UpdateTime = UpdateTime;
                }
                else
                {
                    throw new Exception("Некорректный параметр UpdateTime в файле конфигурации");
                }
                return settings;
            }
            else
            {
                return settings;
            }
        }
    }
}
