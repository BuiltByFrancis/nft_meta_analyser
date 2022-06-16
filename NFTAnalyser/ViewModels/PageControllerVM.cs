using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NFTAnalyser.Models;

namespace NFTAnalyser.ViewModels
{
    public class PageControllerVM : ObservableObject
    {
        private readonly PageController model;

        public PageControllerVM(PageController model)
        {
            this.model = model;

            Next = new RelayCommand(model.Next, model.CanNext);
            Previous = new RelayCommand(model.Previous, model.CanPrevious);

            model.PageChanged += () =>
            {
                OnPropertyChanged(nameof(Info));
                Next.NotifyCanExecuteChanged();
                Previous.NotifyCanExecuteChanged();
            };
        }

        public string Info => $"Page: ({model.PageNumber} / {model.PageCount})";

        public RelayCommand Next { get; }

        public RelayCommand Previous { get; }
    }
}
