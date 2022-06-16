using CommunityToolkit.Mvvm.ComponentModel;
using NFTAnalyser.Models;
using System.Collections.Generic;
using System.Linq;

namespace NFTAnalyser.ViewModels
{
    public class TraitFiltersVM : ObservableObject
    {
        private readonly TraitFilters model;

        public TraitFiltersVM(TraitFilters filter)
        {
            model = filter;

            model.FilterChanged += () =>
            {
                OnPropertyChanged(nameof(FilterCount));
                OnPropertyChanged(nameof(ActiveFilters));
            };
        }

        public string FilterCount => $"{model.FilterLoadedCollection().Count()} items selected";

        public IEnumerable<TraitFilterVM> ActiveFilters =>
            model.Select(f => new TraitFilterVM(f)).ToList();
    }
}
