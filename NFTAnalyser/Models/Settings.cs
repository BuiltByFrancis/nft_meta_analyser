using NFTAnalyser.Contracts;

namespace NFTAnalyser.Models
{
    public class Settings : ISettings
    {
        public string ImageFolder { get; set; }
        public string JsonFolder { get; set; }

        public Settings()
        {
            ImageFolder = string.Empty;
            JsonFolder = string.Empty;
        }
    }
}
