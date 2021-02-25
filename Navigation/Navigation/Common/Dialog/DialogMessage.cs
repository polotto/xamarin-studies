using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation
{
    public class DialogMessage : IDialogMessage
    {
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}

