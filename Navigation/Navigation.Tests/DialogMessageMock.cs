using System;
using System.Threading.Tasks;
using Navigation;

namespace Navigation.Tests
{
    public class DialogMessageMock : IDialogMessage
    {
        public int DisplayAlertCallCount { get; set; }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            DisplayAlertCallCount++;
            return Task.CompletedTask;
        }
    }
}
