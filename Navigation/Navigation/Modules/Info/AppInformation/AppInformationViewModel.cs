using Navigation.Common;
using Xamarin.Essentials;

namespace Navigation.Modules.AppInformation
{
    public class AppInformationViewModel: BaseViewModel
    {
        public string AppName => $"App Name: {AppInfo.Name}";
        public string AppVersion => $"App Version: {AppInfo.VersionString}";
        public string Author => "Author: Angelo Polotto";
    }
}