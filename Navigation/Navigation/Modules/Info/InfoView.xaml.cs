using Navigation.Modules.AppInformation;
using Navigation.Modules.History;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation.Modules.Info
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoView : TabbedPage
    {
        public InfoView(InfoViewModel viewModel,
            HistoryView historyView,
            AppInformationView appInformationView)
        {
            InitializeComponent();
            BindingContext = viewModel;
            historyView.BindingContext = viewModel.HistoryViewModel;
            historyView.IconImageSource = "history.png";
            appInformationView.IconImageSource = "information.png";
            Children.Add(historyView);
            Children.Add(appInformationView);
        }
    }
}