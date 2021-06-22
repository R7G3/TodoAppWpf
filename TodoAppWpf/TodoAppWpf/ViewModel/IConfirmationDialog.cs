namespace TodoAppWpf.ViewModel
{
    interface IConfirmationDialog
    {
        string Title { get; set; }

        string ActionDescription { get; set; }

        void Reset();
    }
}
