using CommunityToolkit.Mvvm.ComponentModel;
using NFTAnalyser.Contracts;

namespace NFTAnalyser.ViewModels
{
    public class MainWindowVM : ObservableObject, INavigator
    {
        public MainWindowVM()
        {
            Globals.Store<INavigator>(this);
            CurrentContent = new PathSetupVM();
        }

        public object CurrentContent { get; private set; }

        public void Display(object content)
        {
            CurrentContent = content;
            OnPropertyChanged(nameof(CurrentContent));
        }
    }
}
