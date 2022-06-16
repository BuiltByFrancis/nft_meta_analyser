using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NFTAnalyser.Contracts;
using System.Windows.Input;

namespace NFTAnalyser.ViewModels
{
    public class PathSetupVM : ObservableObject
    {
        private readonly ISettings settings;
        private readonly INavigator navigator;

        public PathSetupVM()
        {
            settings = Globals.Get<ISettings>();
            navigator = Globals.Get<INavigator>();

            BrowseImageFolder = new RelayCommand(OnBrowseImageFolder);
            BrowseJsonFolder = new RelayCommand(OnBrowseJsonFolder);
            Done = new RelayCommand(OnDone, CanDone);
        }

        public string ImageFolder
        {
            get => settings.ImageFolder;
            set
            {
                settings.ImageFolder = value;
                OnPropertyChanged();
            }
        }

        public string JsonFolder
        {
            get => settings.JsonFolder;
            set
            {
                settings.JsonFolder = value;
                OnPropertyChanged();
            }
        }

        public ICommand BrowseImageFolder { get; }

        public ICommand BrowseJsonFolder { get; }

        public RelayCommand Done { get; }

        private void OnBrowseImageFolder()
        {
            ImageFolder = Browse();
            Done.NotifyCanExecuteChanged();
        }

        private void OnBrowseJsonFolder()
        {
            JsonFolder = Browse();
            Done.NotifyCanExecuteChanged();
        }

        private void OnDone()
        {
            navigator.Display(new TraitPageVM());
        }

        private bool CanDone()
        {
            return !string.IsNullOrEmpty(ImageFolder) && !string.IsNullOrEmpty(JsonFolder);
        }

        private static string Browse()
        {
            var test = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            test.ShowDialog();

            return test.SelectedPath;
        }
    }
}
