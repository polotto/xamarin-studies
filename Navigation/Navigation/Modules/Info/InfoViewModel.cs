using System.Threading.Tasks;
using Navigation.Common;
using Navigation.Modules.History;

namespace Navigation.Modules.Info
{
    public class InfoViewModel: BaseViewModel
    {
        public HistoryViewModel HistoryViewModel { get; set; }

        public InfoViewModel(HistoryViewModel historyViewModel)
        {
            HistoryViewModel = historyViewModel;
        }

        public override Task InitializeAsync(object parameter)
        {
            return HistoryViewModel.InitializeAsync(parameter);
        }
    }
}