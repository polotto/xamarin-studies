using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Navigation.Modules.History;
using Navigation.Modules.Info;
using Xamarin.Forms;

namespace Navigation.Common.Navigation
{
    class NavigationService : INavigationService
    {
        private Func<INavigation> _navigation;
        private IComponentContext _container;
        private readonly Dictionary<Type, Type> _pageMap = new Dictionary<Type, Type>
        {
            { typeof(HistoryViewModel), typeof(HistoryView) },
            { typeof(InfoViewModel), typeof(InfoView) }
        };

        public NavigationService(Func<INavigation> navigation, IComponentContext container)
        {
            _navigation = navigation;
            _container = container;
        }

        public async Task PopAsync()
        {
            await _navigation().PopAsync();
        }

        public async Task PushAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel
        {
            var pageType = _pageMap[typeof(TViewModel)];
            Page page = _container.Resolve(pageType) as Page;
            await _navigation().PushAsync(page);
            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }
    }
}