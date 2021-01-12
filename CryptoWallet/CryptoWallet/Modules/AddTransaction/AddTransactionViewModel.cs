using System;
using CryptoWallet.Common.Base;
using Xamarin.Forms;

namespace CryptoWallet.Modules.AddTransaction
{
    [QueryProperty("Id", "id")]
    public class AddTransactionViewModel: BaseViewModel
    {
        private string _id;
        public string Id
        {
            set
            {
                _id = Uri.UnescapeDataString(value);
            }
        }
    }
}
