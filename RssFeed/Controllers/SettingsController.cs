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
            return View(_settings);
        }

#nullable disable
        [HttpPost]
        public IActionResult Settings(Settings settings)
        {
            var BLsettings = _settingsService.SettingsValidation(SettingsMapper.FromAPIToBusiness(settings));
            _settings.DescriptionTags = BLsettings.DescriptionTags;
            _settings.UpdateTime = BLsettings.UpdateTime;
            _settings.Url = BLsettings.Url;
            ViewBag.SettingsSaved = true;
            return View(_settings);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}