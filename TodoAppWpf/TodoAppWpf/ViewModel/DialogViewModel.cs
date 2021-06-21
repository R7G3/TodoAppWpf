using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace TodoAppWpf.ViewModel
{
    public class DialogViewModel : ViewModelBase
    {
        public DialogViewModel()
        {
            OkCommand = new RelayCommand(
                () => Close(true),
                () => CanClose(true)
            );

            CancelCommand = new RelayCommand(
                () => Close(false),
                () => CanClose(false)
            );
        }

        public ICommand OkCommand
        {
            get;
            private set;
        }

        public ICommand CancelCommand
        {
            get;
            private set;
        }

        public override void Cleanup()
        {
            OkCommand = null;
            CancelCommand = null;

            base.Cleanup();
        }

        protected virtual void Close(bool result)
        {
            MessengerInstance.Send(new NotificationMessage<bool>(this, result, Notifications.CloseDialog));
        }

        protected virtual bool CanClose(bool result)
        {
            return true;
        }
    }
}
