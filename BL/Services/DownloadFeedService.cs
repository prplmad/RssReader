using BL.Abstract;
using BL.Models;
using System.Xml;
using System.ServiceModel.Syndication;

namespace BL.Services
{
    public class DownloadFeedService : IDownloadFeedService
    {
#nullable disable
        public async Task<IEnumerable<Item>?> DownloadAsync(string[] urlArray)
        {
            try
            {
                await Task.Delay(0);
                List<Item> allTheItems = new();
                foreach (var url in urlArray)
                {
                    if (url is null)
                    {
                        continue;
                    }
                    XmlReader FeedReader = XmlReader.Create(url);
                    SyndicationFeed Channel = await Task.Run(() => SyndicationFeed.Load(FeedReader));
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