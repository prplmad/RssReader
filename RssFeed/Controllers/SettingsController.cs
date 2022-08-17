using Microsoft.AspNetCore.Mvc;
using RssFeed.Models;
using System.Diagnostics;
using BL.Abstract;
using RssFeed.Mappers;


namespace RssFeed.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly Settings _settings;

        public SettingsController(Settings settings, ISettingsService settingsService)
        { 
            _settingsService = settingsService;
            _settings = settings;
        }

        public IActionResult Settings()
        {
            var settings = HttpContext.Session.Get<Settings>("settings");
            return View(settings);
        }
        
#nullable disable
        [HttpPost]
        public IActionResult Settings(Settings settings)
        {
            var BLsettings = _settingsService.SettingsValidation(settings.FromAPIToBusiness());

            _settings.DescriptionTags = BLsettings.DescriptionTags;
            _settings.UpdateTime = BLsettings.UpdateTime;
            _settings.Url = BLsettings.Url;

            HttpContext.Session.Set("settings", _settings);
            return RedirectToAction("Settings");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}