using NFTAnalyser.Models;

namespace NFTAnalyser.ViewModels
{
    internal class TraitFilterResultsVM : PageLayoutVM
    {
        public TraitFilterResultsVM(TraitFilters filter)
        {
            var controller = new PageController(filter.FilterLoadedCollection());

            Header = new TraitFiltersVM(filter);
            Content = new ImagesVM(filter, controller);
            Footer = new PageControllerVM(controller);
        }
    }
}
