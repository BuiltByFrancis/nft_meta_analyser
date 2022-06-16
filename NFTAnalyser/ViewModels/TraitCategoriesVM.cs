using NFTAnalyser.Contracts;
using NFTAnalyser.Models;
using System.Collections.Generic;
using System.Linq;

namespace NFTAnalyser.ViewModels
{
    public class TraitCategoriesVM
    {
        private readonly TraitFilters _filter;

        public IEnumerable<CategoryVM> Categories { get; }

        public TraitCategoriesVM(TraitFilters filter)
        {
            _filter = filter;

            var traits = new List<string>();
            foreach (var loaded in Globals.Get<ILoadedCollection>())
            {
                foreach (var trait in loaded.Data.Traits)
                {
                    if (!traits.Contains(trait.Trait))
                    {
                        traits.Add(trait.Trait);
                    }
                }
            }
            Categories = traits.Select(t => new CategoryVM(t, _filter)).ToArray();
        }
    }
}
