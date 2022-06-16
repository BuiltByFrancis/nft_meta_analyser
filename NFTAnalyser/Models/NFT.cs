using System.IO;

namespace NFTAnalyser.Models
{
    public class NFT
    {
        public string ImageURI { get; }
        public NFTData Data { get; }

        public NFT(string imageFolder, NFTData data)
        {
            ImageURI = Path.Combine(imageFolder, Path.GetFileName(data.Image));
            Data = data;
        }
    }
}
