using BL.Models;

namespace BL.Abstract
{
    public interface IDownloadFeedService
    {
        Task<IEnumerable<Item>> DownloadAsync(string[] url);
    }
}
