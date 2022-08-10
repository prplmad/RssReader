using BL.Models;

namespace BL.Abstract
{
    public interface ISettingsService
    {
        public Settings SettingsValidation(Settings settings);
    }
}
