using Microsoft.AspNetCore.Mvc;
using BL.Abstract;
using RssFeed.Models;
using RssFeed.Mappers;

namespace RssFeed.Controllers
{
    public class FeedController : Controller
    {
        private readonly IDownloadFeedService _download;
        private readonly IConfiguration _configuration;
        private readonly Settings _settings;
        public FeedController(IDownloadFeedService download, IConfiguration configuration, Settings settings)
        {
            _download = download;
            _configuration = configuration;
            _settings = settings;
        }
        public IActionResult RSS()
        {
            List<Item> items = new List<Item>();
            if (Array.TrueForAll(_settings.Url, value =>
            {
                return String.IsNullOrEmpty(value);
            }))
            {
                if (_configuration["DescriptionTags"] == "false")
                {
                    ViewBag.Tags = "false";
                }
                else
                {
                    ViewBag.Tags = "true";
                }

                foreach (var item in _download.DownloadAsync().Result)
                {
                    items.Add(item.FromBusinessToAPI());
                }

                return View(items);
            }
            else
            {
                if (_settings.DescriptionTags == false)
                {
                    ViewBag.Tags = "false";
                }
                else
                {
                    ViewBag.Tags = "true";
                }

                foreach (var item in _download.DownloadAsync(SettingsMapper.FromAPIToBusiness(_settings)).Result)
                {
                    items.Add(item.FromBusinessToAPI());
                }
                return View(items);
            }


        }
    }
}
