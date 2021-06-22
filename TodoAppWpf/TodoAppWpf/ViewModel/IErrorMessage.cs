namespace TodoAppWpf.ViewModel
{
    interface IErrorMessage
    {
        string Title { get; set; }

        string Header { get; set; }

        string Message { get; set; }

        void Reset();
    }
}
