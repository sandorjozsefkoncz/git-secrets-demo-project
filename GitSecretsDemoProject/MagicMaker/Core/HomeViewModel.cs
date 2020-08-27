using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace MagicMaker.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _salt;
        public string Salt
        {
            get { return _salt; }
            set { SetProperty(ref _salt, value); }
        }

        private string _plainText;
        public string PlainText
        {
            get { return _plainText; }
            set { SetProperty(ref _plainText, value); }
        }

        private string _encryptedText;
        public string EncryptedText
        {
            get { return _encryptedText; }
            set { SetProperty(ref _encryptedText, value); }
        }

        public IMvxCommand EncryptCommand => new MvxCommand(Encrypt);
        public IMvxCommand DecryptCommand => new MvxCommand(Decrypt);

        private void Encrypt()
        {
            EncryptedText = Security.Encrypt(PlainText, Password, Salt);
        }

        private void Decrypt()
        {
            PlainText = Security.Decrypt(EncryptedText, Password, Salt);
        }
    }
}
