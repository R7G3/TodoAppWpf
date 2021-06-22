using TodoAppWpf.Helper;
using TodoAppWpf.Properties;

namespace TodoAppWpf.ViewModel
{
    public class ConfirmationViewModel : DialogViewModel, IConfirmationDialog
    {
        public ConfirmationViewModel()
        {
#if DEBUG
            if (IsInDesignMode)
            {
                Title = VisualDesignerDataGenerator.LoremIpsum.Substring(0, 15);
                ActionDescription = VisualDesignerDataGenerator.LoremIpsum.Substring(0, 200);
            }
#endif
            Title = Resources.UI_ConfirmAction; 
            ActionDescription = Resources.UI_AreYouSureWantDeleteThis;
        }

        public string Title { get; set; }

        public string ActionDescription { get; set; }

        public void Reset()
        {
            Title = Resources.UI_ConfirmAction;
            ActionDescription = Resources.UI_AreYouSureWantDeleteThis;
        }

        public override void Cleanup()
        {
            Title = null;
            ActionDescription = null;

            base.Cleanup();
        }
    }
}
