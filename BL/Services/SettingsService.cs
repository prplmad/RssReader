using BL.Models;
using BL.Abstract;

namespace BL.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IFeedUrlValidationService _feedUrlValidation;
        public SettingsService(IFeedUrlValidationService feedUrlValidation)
        { 
            _feedUrlValidation = feedUrlValidation;
        }
#nullable disable
        public Settings SettingsValidation(Settings settings)
        {
            Settings _settings = new Settings()
            {
                DescriptionTags = false,
                UpdateTime = 0,
                Url = new string[5]

            };
            if (Array.TrueForAll(settings.Url, value =>
            {
                return String.IsNullOrEmpty(value);
            }))
            {
                for (int i = 0; i < _settings.Url.Length; i++)
                {
                    _settings.Url[i] = null;
                }
                _settings.UpdateTime = settings.UpdateTime;
                _settings.DescriptionTags = settings.DescriptionTags;
                return _settings;
            }
            else
            {
                for (int i = 0; i < _settings.Url.Length; i++)
                {
                    if (settings.Url[i] is null)
                    {
                        _settings.Url[i] = null;
                        continue;
                    }
                    if (_feedUrlValidation.IsValidFeedUrl(settings.Url[i]))
                    {
                        _settings.Url[i] = settings.Url[i];
                    }
                }
                _settings.UpdateTime = settings.UpdateTime;
                _settings.DescriptionTags = settings.DescriptionTags;
                return _settings;
            }
        }
    }
}
