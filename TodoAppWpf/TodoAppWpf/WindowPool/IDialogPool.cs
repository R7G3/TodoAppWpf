namespace TodoAppWpf.WindowPool
{
    public interface IDialogPool
    {
        IGenericDialogPresentation<TDialogType> GetDialog<TDialogType>();
    }
}
