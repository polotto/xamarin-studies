using System;
using Xunit;
using Moq;
using System.Threading.Tasks;

namespace Navigation.Tests
{
    public class MainViewModelTests
    {
        [Fact]
        public void DisplayAlertCommand_displays_alert()
        {
            var mockDialogMessage = new Mock<IDialogMessage>();
            mockDialogMessage.Setup(x => x.DisplayAlert("Hello", "Hello there", "Ok"))
                .Returns(Task.CompletedTask);

            var viewModel = new MainViewModel(mockDialogMessage.Object);

            viewModel.DisplayAlertCommand.Execute(null);

            mockDialogMessage.Verify(x => x.DisplayAlert("Hello", "Hello there", "Ok"), Times.Once);
        }
    }
}
