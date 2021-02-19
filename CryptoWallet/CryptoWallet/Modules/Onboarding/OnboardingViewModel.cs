using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoWallet.Common.Base;
using CryptoWallet.Common.Models;
using CryptoWallet.Common.Navigation;
using CryptoWallet.Modules.Login;
using Xamarin.Forms;

namespace CryptoWallet.Modules.Onboarding
{
    public class OnboardingViewModel: BaseViewModel
    {
        private INavigationService _navigatonService;

        public OnboardingViewModel(INavigationService navigatonService)
        {
            _navigatonService = navigatonService;
        }

        public ObservableCollection<OnboardingItem> OnboardingSteps { get; set; } = new ObservableCollection<OnboardingItem>
        {
            new OnboardingItem("welcome.png",
                "Welcome to Cryptollet",
                "Manage all your crypto assets! It's simple and easy!"),
            new OnboardingItem("nice.png",
                "Nice and Tidy Crypto Portfolio",
                "Keep BTC, ETH, XRP, and many other tokens."),
            new OnboardingItem("security.png",
                "Your safety is our top priority",
                "Our top-notch security features will keep you completely safe.")
        };

        public ICommand SkipCommand { get => new Command(async () => await Skip()); }
        private async Task Skip()
        {
            await _navigatonService.InsertAsRoot<LoginViewModel>();
        }
    }
}
