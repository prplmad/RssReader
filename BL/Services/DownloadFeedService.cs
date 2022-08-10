using BL.Abstract;
using BL.Models;
using System.Xml;
using System.ServiceModel.Syndication;
using Microsoft.Extensions.Configuration;

namespace BL.Services
{
    public class DownloadFeedService : IDownloadFeedService
    {
        private readonly IConfiguration _configuration;
        public DownloadFeedService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
#nullable disable
        public async Task<IEnumerable<Item>?> DownloadAsync()
        {
            try
            {
                await Task.Delay(0);
                string url = _configuration.GetSection("RSSUrl").Get<string>();
                XmlReader FeedReader = XmlReader.Create(url);

                SyndicationFeed Channel = SyndicationFeed.Load(FeedReader);

                var items = Channel.Items
                    .Select(item => new Item(item.Title.Text, item.PublishDate.DateTime,
                        item.Summary.Text, item.Id))
                    .OrderByDescending(s => s.Date);

                return items;
            }
            catch
            {
                throw;
            }
        }


        public async Task<IEnumerable<Item>?> DownloadAsync(Settings settings)
        {
            try
            {
                await Task.Delay(0);
                List<Item> allTheItems = new();
                foreach (var url in settings.Url)
                {
                    if (url is null)
                    {
                        continue;
                    }
                    XmlReader FeedReader = XmlReader.Create(url);
                    SyndicationFeed Channel = SyndicationFeed.Load(FeedReader);
                    var items = Channel.Items
                    .Select(item => new Item(item.Title.Text, item.PublishDate.DateTime,
                        item.Summary.Text, item.Id));

                    foreach (var item in items)
                    {
                        allTheItems.Add(item);
                    }
                }
                return allTheItems.OrderByDescending(s => s.Date);
            }
            catch
            {
                throw;
            }
        }
    }
}