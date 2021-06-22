namespace TodoAppWpf.WindowPool
{
    public interface IGenericDialogPresentation<TDIalogContent> : IDialogPresentation
    {
        TDIalogContent Content { get; set; }
    }
}
