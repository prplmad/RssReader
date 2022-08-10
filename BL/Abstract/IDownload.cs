using BL.Models;

namespace BL.Abstract
{
    public interface IDownloadFeedService
    {
        Task<IEnumerable<Item>> DownloadAsync();

        Task<IEnumerable<Item>> DownloadAsync(Settings settings);
    }
}
