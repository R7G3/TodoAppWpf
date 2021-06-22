using System.Windows;
using TodoAppWpf.View;
using TodoAppWpf.ViewModel;

namespace TodoAppWpf.WindowPool
{
    class ErrorMessagePresentation : DialogPresentation, IGenericDialogPresentation<IErrorMessage>
    {
        IErrorMessage content;

        public IErrorMessage Content
        {
            get
            {
                return content ?? (content = new ErrorMessageViewModel());
            }

            set => content = value;
        }


        protected override Window CreatePresentation()
        {
            return new ErrorMessageView()
            {
                DataContext = Content,
                Owner = MainWindow
            };
        }
    }
}
