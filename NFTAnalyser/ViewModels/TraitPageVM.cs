using Newtonsoft.Json;
using NFTAnalyser.Contracts;
using NFTAnalyser.Models;
using System.IO;

namespace NFTAnalyser.ViewModels
{
    public class TraitPageVM : PageLayoutVM
    {
        public TraitPageVM()
        {
            var settings = Globals.Get<ISettings>();

            var loaded = new LoadedCollection();
            foreach (var file in Directory.GetFiles(settings.JsonFolder))
            {
                loaded.Add(new NFT(settings.ImageFolder,
                    JsonConvert.DeserializeObject<NFTData>(File.ReadAllText(file)) ??
                    throw new InvalidDataException("File does not contain NFTData")));
            }

            Globals.Store<ILoadedCollection>(loaded);

            var filter = new TraitFilters();
            Right = new TraitCategoriesVM(filter);
            Content = new TraitFilterResultsVM(filter);
        }
    }
}
