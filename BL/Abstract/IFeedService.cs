using BL.Models;

namespace BL.Abstract
{
    public interface IFeedService
    {
        public Settings ChooseSourceForSettings(Settings settings);
    }
}
