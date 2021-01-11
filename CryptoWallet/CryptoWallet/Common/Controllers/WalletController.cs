﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoWallet.Common.Models;

namespace CryptoWallet.Common.Controllers
{
    public interface IWalletController
    {
        Task<List<Coin>> GetCoins(bool forceReload = false);
    }

    public class WalletController: IWalletController
    {
        private List<Coin> _defaultAssets = new List<Coin>
        {
            new Coin
            {
                Name = "Bitcoin",
                Amount = 1,
                Symbol = "BTC",
                DollarValue = 9500
            },
            new Coin
            {
                Name = "Ethereum",
                Amount = 2,
                Symbol = "ETH",
                DollarValue = 300
            },
            new Coin
            {
                Name = "Litecoin",
                Amount = 3,
                Symbol = "LTC",
                DollarValue = 150
            }
        };

        public Task<List<Coin>> GetCoins(bool forceReload = false)
        {
            return Task.FromResult(_defaultAssets);
        }
    }
}
