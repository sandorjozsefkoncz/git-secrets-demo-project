using MagicMaker.Core;
using MagicMaker.Core.ViewModels;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;

namespace MagicMaker.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    [MvxViewFor(typeof(HomeViewModel))]
    public partial class HomeView : MvxWpfView
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}
