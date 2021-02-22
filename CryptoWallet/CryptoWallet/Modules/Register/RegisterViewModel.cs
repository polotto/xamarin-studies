using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cryptollet.Common.Security;
using CryptoWallet.Common.Base;
using CryptoWallet.Common.Database;
using CryptoWallet.Common.Models;
using CryptoWallet.Common.Navigation;
using CryptoWallet.Common.Validations;
using CryptoWallet.Modules.Login;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CryptoWallet.Modules.Register
{
    public class RegisterViewModel: BaseViewModel
    {
        private INavigationService _navigationService;
        private IRepository<User> _userRepository;

        public RegisterViewModel(INavigationService navigationService, IRepository<User> userRepository)
        {
            _navigationService = navigationService;
            _userRepository = userRepository;
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

        private ValidatableObject<string> _name;
        public ValidatableObject<string> Name
        {
            get => _name;
            set { SetProperty(ref _name, value); }
        }

        public ICommand LoginCommand { get => new Command(async () => await Login()); }
        private async Task Login()
        {
            await _navigationService.InsertAsRoot<LoginViewModel>();
        }

        public ICommand RegisterUserCommand { get => new Command(async () => await RegisterUser(), () => IsNotBusy); }
        private async Task RegisterUser()
        {
            // validate entered values
            if (!EntriesAreCorrectedPopulated())
            {
                return;
            }

            IsBusy = true;
            var newUser = new User
            {
                Email = Email.Value,
                FirstName = Name.Value,
                HashedPassword = SecurePasswordHasher.Hash(Password.Value)
            };
            await _userRepository.SaveAsync(newUser);

            Preferences.Set(Constants.IS_USER_LOGGED_IN, true);
            Preferences.Set(Constants.USER_ID, Email.Value);

            _navigationService.GoToMainFlow();
            IsBusy = false;
        }

        private void AddValidations()
        {
            _email = new ValidatableObject<string>();
            _name = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();

            _email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is empty." });
            _email.Validations.Add(new EmailRule<string> { ValidationMessage = "Email is not in a correct format" });

            _name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name is empty." });

            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is empty." });
        }

        private bool EntriesAreCorrectedPopulated()
        {
            _email.Validate();
            _name.Validate();
            _password.Validate();

            return _email.IsValid && _name.IsValid && _password.IsValid;
        }
    }
}
