using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Navigation
{
    public class MainViewModel: BindableObject
    {
        private IDialogMessage _dialogMessage;

        public MainViewModel(IDialogMessage dialogMessage)
        {
            _dialogMessage = dialogMessage;
        }

        public ICommand DisplayAlertCommand { get => new Command(async () => await DisplayAlert()); }
        private async Task DisplayAlert()
        {
            await _dialogMessage.DisplayAlert("Hello", "Hello there!", "Ok");
        }
    }
}
