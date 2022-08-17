namespace RssFeed.Mappers
{
    public static class SettingsMapper
    {
        public static BL.Models.Settings FromAPIToBusiness(this RssFeed.Models.Settings settings)
        {
            return new BL.Models.Settings
            {
                DescriptionTags = settings.DescriptionTags,
                UpdateTime = settings.UpdateTime,
                Url = settings.Url,
            };
        }

        public static RssFeed.Models.Settings FromBusinessToApi(this BL.Models.Settings settings)
        {
            return new Models.Settings
            {
                DescriptionTags = settings.DescriptionTags,
                UpdateTime = settings.UpdateTime,
                Url = settings.Url,
            };
        }
    }
}
