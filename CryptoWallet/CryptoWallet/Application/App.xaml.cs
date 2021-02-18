using System.Reflection;
using Autofac;
using CryptoWallet.Common.Database;
using CryptoWallet.Common.Models;
using Xamarin.Forms;

namespace CryptoWallet
{
    public partial class App : Application
    {
        public static IContainer Container;

        public App()
        {
            InitializeComponent();
            //class used for registration
            var builder = new ContainerBuilder();
            //scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                   .AsImplementedInterfaces()
                   .AsSelf();
            builder.RegisterType<Repository<Transaction>>().As<IRepository<Transaction>>();

            //get container
            Container = builder.Build();
            //set first page
            MainPage = new AppShell();
        }
    }
}
