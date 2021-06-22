using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using System.Windows.Input;
using TodoAppWpf.Helper;
using TodoAppWpf.Properties;

namespace TodoAppWpf.ViewModel
{
    public class ErrorMessageViewModel : DialogViewModel, IErrorMessage
    {
        public ErrorMessageViewModel()
        {
#if DEBUG
            if (IsInDesignMode)
            {
                Title = VisualDesignerDataGenerator.LoremIpsum.Substring(0, 15);
                Header = VisualDesignerDataGenerator.LoremIpsum.Substring(0, 25);
                Message = VisualDesignerDataGenerator.LoremIpsum.Substring(0, 256);

                return;
            }
#endif
            Title = Resources.UI_AnErrorHasOccurred;
            CopyToClipboardCommand = new RelayCommand(() => Clipboard.SetText(Message));
        }

        public string Title
        {
            get;
            set;
        }

        public string Header
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public ICommand CopyToClipboardCommand { get; private set; }

        public void Reset()
        {
            Title = Resources.UI_AnErrorHasOccurred;
            Header = null;
            Message = null;
        }

        public override void Cleanup()
        {
            Title = null;
            Header = null;
            Message = null;
            CopyToClipboardCommand = null;

            base.Cleanup();
        }
    }
}
