using System.ServiceModel.Syndication;
using System.Xml;
using BL.Abstract;

namespace BL.Services
{
    public class FeedUrlValidationService : IFeedUrlValidationService
    {
        public bool IsValidFeedUrl(string url)
        {
            bool isValid = true;
            try
            {
                XmlReader reader = XmlReader.Create(url);
                Rss20FeedFormatter formatter = new Rss20FeedFormatter();
                formatter.ReadFrom(reader);
                reader.Close();
            }
            catch
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
