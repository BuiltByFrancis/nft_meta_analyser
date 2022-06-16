using CommunityToolkit.Mvvm.ComponentModel;

namespace NFTAnalyser.ViewModels
{
    public class PageLayoutVM : ObservableObject
    {
        private object _header;
        private object _left;
        private object _content;
        private object _right;
        private object _footer;

        public object Header
        {
            get => _header;
            set
            {
                _header = value;
                OnPropertyChanged();
            }
        }

        public object Left
        {
            get => _left;
            set
            {
                _left = value;
                OnPropertyChanged();
            }
        }

        public object Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        public object Right
        {
            get => _right;
            set
            {
                _right = value;
                OnPropertyChanged();
            }
        }

        public object Footer
        {
            get => _footer;
            set
            {
                _footer = value;
                OnPropertyChanged();
            }
        }
    }
}
