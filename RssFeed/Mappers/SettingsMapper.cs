namespace RssFeed.Mappers
{
    public class SettingsMapper
    {
        public static BL.Models.Settings FromAPIToBusiness(Models.Settings settings)
        {
            return new BL.Models.Settings
            {
                DescriptionTags = settings.DescriptionTags,
                UpdateTime = settings.UpdateTime,
                Url = settings.Url,
            };
        }

        public static Models.Settings FromBusinessToApi(BL.Models.Settings settings)
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
