using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.CodeDom;
using System.Windows;
using System.Windows.Input;

namespace TemporalMagicApp
{
    public class MainWindowViewModel: ViewModelBase
    {
        public string Password { get; set; }
        public string Salt { get; set; }

        public string ClearSecret { get; set; }
        public string EncryptedSecret { get; set; }

        public ICommand EncryptCommand { get; private set; }

        public MainWindowViewModel()
        {
            EncryptCommand = new RelayCommand(EncryptButtonPressed);
        }


        public void EncryptButtonPressed()
        {
            MessageBox.Show(Password);
        }
    }
}
