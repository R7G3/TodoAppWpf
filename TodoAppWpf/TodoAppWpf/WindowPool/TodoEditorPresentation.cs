using System.Windows;
using TodoAppWpf.View;
using TodoAppWpf.ViewModel;

namespace TodoAppWpf.WindowPool
{
    class TodoEditorPresentation : DialogPresentation, IGenericDialogPresentation<ITodoEditor>
    {
        ITodoEditor content;

        public ITodoEditor Content
        {
            get => content ?? (content = new TodoEditorViewModel());
            set => content = value;
        }


        protected override Window CreatePresentation()
        {
            return new TodoEditorView()
            {
                DataContext = Content,
                Owner = MainWindow
            };
        }
    }
}
