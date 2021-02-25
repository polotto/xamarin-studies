using System;
using System.Threading.Tasks;

namespace Navigation
{
    public interface IDialogMessage
    {
        Task DisplayAlert(string title, string message, string cancel);
    }
}

