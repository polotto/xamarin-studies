using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace todo
{
    public partial class TodoView : ContentPage
    {
        public TodoView()
        {
            InitializeComponent();
            TodoViewModel todoViewModel = new TodoViewModel();
            BindingContext = todoViewModel;
            todoViewModel.UpdateProgressBar += TodoViewModel_UpdateProgressBar;
        }

        private async void TodoViewModel_UpdateProgressBar(object sender, double e)
        {
            await progressBar.ProgressTo(e, 300, Easing.Linear);
        }
    }
}
