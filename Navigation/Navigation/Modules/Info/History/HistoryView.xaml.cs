using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation.Modules.History
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryView : ContentPage
    {
        public HistoryView(HistoryViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}