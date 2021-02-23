using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace todo
{
    public class TodoViewModel: BindableObject
    {
        private TodoItem _selectedItem;
        private string _completedHeader;
        private double _completedProgress;

        public event EventHandler<double> UpdateProgressBar;

        public TodoViewModel()
        {
            Items = new ObservableCollection<TodoItem>(TodoItem.GoTodoItems());
            CalculateCompletedHeader();
        }

        public string CompletedHeader
        {
            get => _completedHeader;
            set
            {
                _completedHeader = value;
                OnPropertyChanged();
            }
        }

        public double CompletedProgress
        {
            get => _completedProgress;
            set
            {
                _completedProgress = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TodoItem> Items { get; set; }

        public string PageTitle { get; set; }

        public TodoItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                PageTitle = value?.Name;
                OnPropertyChanged("PageTitle");
            }
        }

        public ICommand AddItemCommand { get => new Command(AddItem); }
        private void AddItem()
        {
            Items.Add(new TodoItem($"Todo Item {Items.Count + 1}"));
            CalculateCompletedHeader();
        }

        public ICommand MarkAsCompletedCommand { get => new Command<TodoItem>(MarkAsCompleted); }

        private void MarkAsCompleted(TodoItem obj)
        {
            obj.Completed = true;
            Items.Remove(obj);
            Items.Add(obj);
            CalculateCompletedHeader();
        }

        private void CalculateCompletedHeader()
        {
            CompletedHeader = $"Completed {Items.Count(x => x.Completed)}/{Items.Count}";
            CompletedProgress = (double)Items.Count(x => x.Completed) / (double)Items.Count;
            UpdateProgressBar?.Invoke(this, CompletedProgress);
        }
    }
}
