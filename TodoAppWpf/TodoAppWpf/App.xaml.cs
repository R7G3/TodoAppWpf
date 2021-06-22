using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TodoAppWpf.ViewModel;
using TodoAppWpf.WindowPool;

namespace TodoAppWpf
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ISimpleIoc container;
        private IDialogPool dialogPool;

        private void ApplicationStartup(object sender, StartupEventArgs args)
        {
            container = SimpleIoc.Default;
            ServiceLocator.SetLocatorProvider(() => container);
            DispatcherHelper.Initialize();

            dialogPool = DialogPool.GetInstance();
            container.Register<IDialogPool>(() => dialogPool);

            DispatcherUnhandledException += UnhandledExceptionHandler;

            container.Register<MainViewModel>();

            var window = new MainWindow()
            {
                DataContext = container.GetInstance<MainViewModel>()
            };
            container.Register<MainWindow>(() => window);

            window.Show();
        }

        void UnhandledExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            //TODO need implement
            //try save data and show error window?
        }
    }
}
