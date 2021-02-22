using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Cryptollet.Common.Security;
using CryptoWallet.Common.Base;
using CryptoWallet.Common.Database;
using CryptoWallet.Common.Dialog;
using CryptoWallet.Common.Models;
using CryptoWallet.Common.Navigation;
using CryptoWallet.Common.Validations;
using CryptoWallet.Modules.Register;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CryptoWallet.Modules.Login
{
    public class LoginViewModel: BaseViewModel
    {
        private INavigationService _navigationService;
        private IRepository<User> _userRepository;
        private IDialogMessage _dialogMessage;

        public LoginViewModel(INavigationService navigationService,
                              IRepository<User> userRepository,
                              IDialogMessage dialogMessage)
        {
            _navigationService = navigationService;
            _userRepository = userRepository;
            _dialogMessage = dialogMessage;
            AddValidations();
        }

        private ValidatableObject<string> _email;
        public ValidatableObject<string> Email
        {
            get => _email;
            set { SetProperty(ref _email, value); }
        }

        private ValidatableObject<string> _password;
        public ValidatableObject<string> Password
        {
            get => _password;
            set { SetProperty(ref _password, value); }
        }

        public ICommand RegisterCommand { get => new Command(async () => await Register()); }
        private async Task Register()
        {
            await _navigationService.InsertAsRoot<RegisterViewModel>();
        }

        public ICommand LoginCommand { get => new Command(async () => await Login(), () => IsNotBusy); }
        private async Task Login()
        {
            if (!EntriesCorrectlyPopulated())
            {
                return;
            }
            IsBusy = true;
            var user = (await _userRepository.GetAllAsync())
                .FirstOrDefault(x => x.Email == Email.Value);
            if (user == null)
            {
                await DisplayCredentialsError();
                IsBusy = false;
                return;
            }
            if (!SecurePasswordHasher.Verify(Password.Value, user.HashedPassword))
            {
                await DisplayCredentialsError();
                IsBusy = false;
                return;
            }

            Preferences.Set(Constants.IS_USER_LOGGED_IN, true);
            Preferences.Set(Constants.USER_ID, Email.Value);

            _navigationService.GoToMainFlow();
            IsBusy = false;
        }

        private async Task DisplayCredentialsError()
        {
            await _dialogMessage.DisplayAlert(Resources., "Credentials are wrong.", "Ok");
            Password.Value = "";
        }

        private void AddValidations()
        {
            _email = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();

            _email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is empty." });
            _email.Validations.Add(new EmailRule<string> { ValidationMessage = "Email is not in a correct format" });

            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is empty." });
        }

        private bool EntriesCorrectlyPopulated()
        {
            _email.Validate();
            _password.Validate();

            return _email.IsValid && _password.IsValid;
        }
    }
}
