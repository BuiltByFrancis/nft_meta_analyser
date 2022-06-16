using NFTAnalyser.Contracts;
using NFTAnalyser.Models;
using System.Windows;

namespace NFTAnalyser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Globals.Store<ISettings>(new Settings());
        }
    }
}
