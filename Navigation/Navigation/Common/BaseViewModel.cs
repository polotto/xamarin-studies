using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation.Common
{
    public abstract class BaseViewModel: BindableObject
    {
        public virtual Task InitializeAsync(object parameter)
        {
            return Task.CompletedTask;
        }
    }
}