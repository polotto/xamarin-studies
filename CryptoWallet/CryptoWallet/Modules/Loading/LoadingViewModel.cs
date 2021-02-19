﻿using System;
using System.Threading.Tasks;
using CryptoWallet.Common.Base;
using CryptoWallet.Common.Navigation;
using CryptoWallet.Modules.Login;
using CryptoWallet.Modules.Onboarding;
using Xamarin.Essentials;

namespace CryptoWallet.Modules.Loading
{
    public class LoadingViewModel: BaseViewModel
    {
        private INavigationService _navigationService;

        public LoadingViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override Task InitializeAsync(object parameter)
        {
            if (!Preferences.ContainsKey(Constants.SHOWN_ONBOARDING))
            {
                Preferences.Set(Constants.SHOWN_ONBOARDING, true);
                _navigationService.GoToLoginFlow();
                return _navigationService.InsertAsRoot<OnboardingViewModel>();
            }

            if (Preferences.ContainsKey(Constants.IS_USER_LOGGED_IN)
                && Preferences.Get(Constants.IS_USER_LOGGED_IN, false) == true)
            {
                _navigationService.GoToMainFlow();
                return Task.CompletedTask;
            }

            _navigationService.GoToLoginFlow();
            return _navigationService.InsertAsRoot<LoginViewModel>();
        }

    }
}
