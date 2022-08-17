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
        private readonly IFeedService _feedService;
        public FeedController(IDownloadFeedService download, IConfiguration configuration, IFeedService feedService)
        {
            _download = download;
            _configuration = configuration;
            _feedService = feedService;
        }
#nullable disable
        public async Task<IActionResult> RSS()
        {   
            List<Item> items = new List<Item>();
            var settings = HttpContext.Session.Get<Settings>("settings");
            settings = _feedService.ChooseSourceForSettings(settings?.FromAPIToBusiness()).FromBusinessToApi();


            if (settings.DescriptionTags == false)
            {
                ViewBag.Tags = "false";
            }
            else
            {
                ViewBag.Tags = "true";
            }
            ViewBag.UpdateTime = settings.UpdateTime * 60;

            var download = await _download.DownloadAsync(settings.Url);
            foreach (var item in download)
            {
                items.Add(item.FromBusinessToAPI());
            }
            return View(items);
        }
    }
}
