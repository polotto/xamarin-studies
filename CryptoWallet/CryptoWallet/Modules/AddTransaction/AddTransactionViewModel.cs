using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoWallet.Common.Base;
using CryptoWallet.Common.Models;
using CryptoWallet.Common.Validations;
using Xamarin.Forms;

namespace CryptoWallet.Modules.AddTransaction
{
    [QueryProperty("Id", "id")]
    public class AddTransactionViewModel : BaseViewModel
    {
        public AddTransactionViewModel()
        {
            AvailableAssets = new ObservableCollection<Coin>(Coin.GetAvailableAssets());
            _amount = new ValidatableObject<decimal>();
            _amount.Validations.Add(new NonNegativeRule { ValidationMessage = "Please enter amount greater than zero." });
        }

        private bool _isDeposit;
        public bool IsDeposit
        {
            get => _isDeposit;
            set { SetProperty(ref _isDeposit, value); }
        }
        private string _id;
        public string Id
        {
            set
            {
                _id = Uri.UnescapeDataString(value);
            }
        }

        private ObservableCollection<Coin> _availableAssets;
        public ObservableCollection<Coin> AvailableAssets
        {
            get => _availableAssets;
            set { SetProperty(ref _availableAssets, value); }
        }

        private Coin _selectedCoin;
        public Coin SelectedCoin
        {
            get => _selectedCoin;
            set { SetProperty(ref _selectedCoin, value); }
        }

        private DateTime _transactionDate;
        public DateTime TransactionDate
        {
            get => _transactionDate;
            set { SetProperty(ref _transactionDate, value); }
        }

        private ValidatableObject<decimal> _amount;
        public ValidatableObject<decimal> Amount
        {
            get => _amount;
            set { SetProperty(ref _amount, value); }
        }

        public ICommand AddTransactionCommand
        {
            get => new Command(async () => await AddTransaction());
        }

        private async Task AddTransaction()
        {
            _amount.Validate();
            if (_amount.IsValid)
            {
                return;
            }
        }
    }
}
