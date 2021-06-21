using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Windows;

namespace TodoAppWpf.Helpers
{
    public sealed class CloseWindowHelper
    {
        Window _window;

        public CloseWindowHelper(Window window)
        {
            _window = window ?? throw new ArgumentNullException();

            Messenger.Default.Register<NotificationMessage<bool>>(this, MessageHandler);
        }

        void MessageHandler(NotificationMessage<bool> message)
        {
            if (IsMessageForThisWindow(message) && IsClosingNotification(message))
            {
                DispatcherHelper.CheckBeginInvokeOnUI(
                    () => CloseWindowWithResult(message.Content)
                );
            }
        }

        bool IsMessageForThisWindow(NotificationMessage<bool> message)
        {
            return message.Sender == _window.DataContext;
        }

        bool IsClosingNotification(NotificationMessage<bool> message)
        {
            return message.Notification == Notifications.CloseDialog;
        }

        private void CloseWindowWithResult(bool result)
        {
            try
            {
                _window.DialogResult = result;
            }
            catch (InvalidOperationException)
            {
                _window.Close();
            }
        }
    }
}
