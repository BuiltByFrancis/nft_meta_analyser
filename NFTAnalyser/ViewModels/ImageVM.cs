using NFTAnalyser.Models;

namespace NFTAnalyser.ViewModels
{
    public class ImageVM
    {
        private readonly NFT model;

        public ImageVM(NFT model)
        {
            this.model = model;
        }

        public string Uri => model.ImageURI;

        public string Name => model.Data.Name;

        public string Id => $"#{model.Data.Id}";
    }
}
