using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Navigation.Common;
using Navigation.Common.Navigation;
using Navigation.Modules.History;
using Navigation.Modules.Info;
using Xamarin.Forms;

namespace Navigation
{
    public enum CalculatorState
    {
        PopulatingFirstNumber,
        PopulatingSecondNumber
    }

    public enum Operation
    {
        None,
        Add,
        Subtract,
        Divide,
        Multiply,
        Equal
    }

    public class CalculatorViewModel: BaseViewModel
    {
        private INavigationService _navigationService;
        private string _displayText;
        private string _firstNumber = string.Empty;
        private string _secondNumber = string.Empty;
        private CalculatorState _state;
        private Operation _currentOperation;
        private List<string> _calculatorHistory = new List<string>();

        public CalculatorViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _state = CalculatorState.PopulatingFirstNumber;
            _currentOperation = Operation.None;
            SubscribeToMessage();
        }

        private void SubscribeToMessage()
        {
            MessagingCenter.Subscribe<HistoryViewModel, List<string>>(this, "Items", (vm, list) =>
            {
                _calculatorHistory = list;
            });
        }

        public string DisplayText
        {
            get => _displayText; 
            set
            {
                _displayText = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClearCommand => new Command(ClearText);

        public ICommand AddCharCommand => new Command<string>(AddChar);

        public ICommand OperationCommand => new Command<Operation>(PerformOperation);

        private void AddChar(string character)
        {
            if (_state == CalculatorState.PopulatingFirstNumber)
            {
                if (_firstNumber.Contains(",") && character == ",")
                {
                    return;
                }
                _firstNumber += character;
                DisplayText = _firstNumber;
                return;
            }

            if (_secondNumber.Contains(",") && character == ",")
            {
                return;
            }
            _secondNumber += character;
            DisplayText = _secondNumber;
        }

        private void ClearText()
        {
            if (_state == CalculatorState.PopulatingFirstNumber)
            {
                _firstNumber = string.Empty;
            }
            else
            {
                _secondNumber = string.Empty;
            }
            DisplayText = string.Empty;
        }

        private void PerformOperation(Operation operation)
        {
            if (operation == Operation.Equal && 
                !string.IsNullOrWhiteSpace(_firstNumber) &&
                !string.IsNullOrWhiteSpace(_secondNumber))
            {
                Calculate();
                return;
            }
            _currentOperation = operation;
            DisplayText = string.Empty;
            _state = CalculatorState.PopulatingSecondNumber;
        }

        private void Calculate()
        {
            var first = decimal.Parse(_firstNumber);
            var second = decimal.Parse(_secondNumber);
            decimal result = 0;
            switch (_currentOperation)
            {
                case Operation.Add:
                    result = first + second;
                    break;
                case Operation.Subtract:
                    result = first - second;
                    break;
                case Operation.Divide:
                    result = first / second;
                    break;
                case Operation.Multiply:
                    result = first * second;
                    break;
                default:
                    break;
            }
            DisplayText = result.ToString();
            _calculatorHistory.Add($"{_firstNumber} {GetOperationString()} {_secondNumber} = {result}");
            _currentOperation = Operation.None;
            _state = CalculatorState.PopulatingFirstNumber;
            _firstNumber = string.Empty;
            _secondNumber = string.Empty;
        }

        private string GetOperationString()
        {
            return _currentOperation switch
            {
                Operation.Add => "+",
                Operation.Subtract => "-",
                Operation.Divide => "/",
                Operation.Multiply => "*",
                _ => ""
            };
        }

        public ICommand ShowHistoryCommand
        {
            get => new Command(async () => await ShowHistory());
        }

        private async Task ShowHistory()
        {
            await _navigationService.PushAsync<InfoViewModel>(_calculatorHistory);
        }
    }
}
