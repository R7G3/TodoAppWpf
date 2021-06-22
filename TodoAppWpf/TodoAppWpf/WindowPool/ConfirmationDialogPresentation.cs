using System.Windows;
using TodoAppWpf.View;
using TodoAppWpf.ViewModel;

namespace TodoAppWpf.WindowPool
{
    class ConfirmationDialogPresentation : DialogPresentation, IGenericDialogPresentation<IConfirmationDialog>
    {
        IConfirmationDialog content;

        public IConfirmationDialog Content
        {
            get => content ?? (content = new ConfirmationViewModel());
            set => content = value;
        }


        protected override Window CreatePresentation()
        {
            return new ConfirmationView()
            {
                DataContext = Content,
                Owner = MainWindow
            };
        }
    }
}
