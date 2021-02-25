using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Navigation.Common;
using Xamarin.Forms;

namespace Navigation.Modules.History
{
    public class HistoryViewModel: BaseViewModel
    {
        public HistoryViewModel()
        {
            Items = new ObservableCollection<string>();
        }

        public override Task InitializeAsync(object parameter)
        {
            Items = new ObservableCollection<string>(parameter as List<string>);
            OnPropertyChanged("Items");
            return base.InitializeAsync(parameter);
        }

        public ObservableCollection<string> Items { get; set; }

        public ICommand DeleteCommand
        {
            get => new Command<string>(Delete);
        }

        private void Delete(string item)
        {
            Items.Remove(item);
            MessagingCenter.Send(this, "Items", new List<string>(Items));
        }
    }
}
