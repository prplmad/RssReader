namespace RssFeed.Mappers
{
    public static class ItemMapper
    {
        public static Models.Item FromBusinessToAPI(this BL.Models.Item item)
        {
            return new Models.Item
            {
                Title = item.Title,
                Description = item.Description,
                Url = item.Url,
                Date = item.Date,
            };
        }
    }
}
