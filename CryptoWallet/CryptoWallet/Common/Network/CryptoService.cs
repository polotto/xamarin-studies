using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoWallet.Common.Models;

namespace CryptoWallet.Common.Network
{
    public interface ICryptoService
    {
        Task<List<Coin>> GetLatestPrices();
    }

    public class CryptoService : ICryptoService
    {
        private INetworkService _networkService;
        private const string PRICES_ENDPOINT = "simple/price?ids=stellar%2Cethereum%2Cbitcoin%2Cdash%2Cbitcoin-cash%2Ceos%2Clitecoin%2Cripple%2Cmonero&vs_currencies=usd";

        public CryptoService(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public async Task<List<Coin>> GetLatestPrices()
        {
            var url = Constants.CRYPTO_API + PRICES_ENDPOINT;
            var result = await _networkService.GetAsync<Dictionary<string, Dictionary<string, decimal?>>>(url);
            var coins = Coin.GetAvailableAssets();
            foreach (var item in coins)
            {
                Dictionary<string, decimal?> coinPrices = result[item.Name.Replace(' ', '-').ToLower()];
                decimal? coinPrice = coinPrices["usd"];
                item.Price = coinPrice.HasValue ? coinPrice.Value : 0;
            }
            return coins;
        }
    }
}
