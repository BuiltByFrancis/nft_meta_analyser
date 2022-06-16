using NFTAnalyser.Contracts;
using NFTAnalyser.Models;
using System.Collections.Generic;
using System.Linq;

namespace NFTAnalyser.ViewModels
{
    public class CategoryVM
    {
        public string Title { get; }
        public string Count { get; }
        public IEnumerable<CategoryItemVM> Items { get; }

        public CategoryVM(string title, TraitFilters filters)
        {
            Title = title;

            var items = new Dictionary<string, int>();
            foreach (var item in Globals.Get<ILoadedCollection>()
                .Select(l => l.Data.Traits)
                .Where(l => l.Any(t => t.Trait == title)))

            {
                var trait = item.First(data => data.Trait == title);
                if (items.ContainsKey(trait.Value))
                {
                    items[trait.Value]++;
                }
                else
                {
                    items.Add(trait.Value, 1);
                }
            }

            Items = items.Select(kvp => new CategoryItemVM(filters, new TraitFilter(filters, title, kvp.Key), kvp.Value));
            Count = $"({items.Count})";
        }
    }
}
