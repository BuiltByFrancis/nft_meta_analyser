using CommunityToolkit.Mvvm.ComponentModel;
using NFTAnalyser.Contracts;
using NFTAnalyser.Models;

namespace NFTAnalyser.ViewModels
{
    public class CategoryItemVM : ObservableObject
    {
        private readonly TraitFilters filters;
        private readonly IFilter filter;

        public string Trait => filter.Title;
        public string Count { get; }

        public bool IsChecked
        {
            get => filters.Contains(filter);
            set
            {
                if (value)
                {
                    filters.Add(filter);
                }
                else
                {
                    filters.Remove(filter);
                }
            }
        }

        public CategoryItemVM(TraitFilters filters, TraitFilter filter, int count)
        {
            this.filters = filters;
            this.filter = filter;

            Count = $"({count})";

            filters.FilterChanged += () =>
            {
                // Changed by us or someone else.
                OnPropertyChanged(nameof(IsChecked));
            };
        }
    }
}
