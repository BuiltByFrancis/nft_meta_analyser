using CommunityToolkit.Mvvm.Input;
using NFTAnalyser.Contracts;
using System.Windows.Input;

namespace NFTAnalyser.ViewModels
{
    public class TraitFilterVM
    {
        private readonly IFilter model;

        public TraitFilterVM(IFilter model)
        {
            this.model = model;
            Remove = new RelayCommand(model.Delete);
        }

        public string Title => model.Title;

        public ICommand Remove { get; }
    }
}
