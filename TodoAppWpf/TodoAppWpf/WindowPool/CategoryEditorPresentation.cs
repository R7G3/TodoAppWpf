using System.Windows;
using TodoAppWpf.View;
using TodoAppWpf.ViewModel;

namespace TodoAppWpf.WindowPool
{
    class CategoryEditorPresentation : DialogPresentation, IGenericDialogPresentation<ICategoryEditor>
    {
        ICategoryEditor content;

        public ICategoryEditor Content
        {
            get => content ?? (content = new CategoryEditorViewModel());
            set => content = value;
        }


        protected override Window CreatePresentation()
        {
            return new CategoryEditorView()
            {
                DataContext = Content,
                Owner = MainWindow
            };
        }
    }
}
