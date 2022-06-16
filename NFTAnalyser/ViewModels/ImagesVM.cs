using CommunityToolkit.Mvvm.ComponentModel;
using NFTAnalyser.Models;
using System.Collections.Generic;
using System.Linq;

namespace NFTAnalyser.ViewModels
{
    public class ImagesVM : ObservableObject
    {
        private readonly PageController pageController;

        public IEnumerable<ImageVM> Images =>
            pageController.CreatePage().ToList();

        public ImagesVM(TraitFilters filter, PageController pageController)
        {
            this.pageController = pageController;
            pageController.PageChanged += () =>
            {
                OnPropertyChanged(nameof(Images));
            };

            filter.FilterChanged += () =>
            {
                pageController.PageCollection(filter.FilterLoadedCollection());
            };
        }
    }
}
