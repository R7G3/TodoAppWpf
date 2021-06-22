using GalaSoft.MvvmLight.Ioc;
using System.Windows;

namespace TodoAppWpf.WindowPool
{
    abstract class DialogPresentation : IDialogPresentation
    {
        protected Window MainWindow = SimpleIoc.Default.GetInstance<MainWindow>();

        protected abstract Window CreatePresentation();

        public bool Show()
        {
            var window = CreatePresentation();
            var dialogResult = window.ShowDialog();
            return dialogResult ?? false;
        }
    }
}
