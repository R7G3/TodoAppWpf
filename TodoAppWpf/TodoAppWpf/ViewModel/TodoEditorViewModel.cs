using System.Collections.ObjectModel;
using TodoAppWpf.Helper;
using TodoAppWpf.Model;

namespace TodoAppWpf.ViewModel
{
    public class TodoEditorViewModel : DialogViewModel
    {
        public TodoEditorViewModel()
        {
#if DEBUG
            if (IsInDesignMode)
            {
                Todo = VisualDesignerDataGenerator.GenerateTodo();
                return;
            }
#endif
            Todo = new Todo();
        }

        public Todo Todo
        {
            get;
            set;
        }

        public string Header
        {
            get => Todo?.Header;
            set
            {
                if (Todo.Header == value)
                    return;

                Todo.Header = value;
                RaisePropertyChanged();
            }
        }

        public string Content
        {
            get => Todo?.Content;
            set
            {
                if (Todo.Content == value)
                    return;

                Todo.Content = value;
                RaisePropertyChanged();
            }
        }

        public Category Category
        {
            get => Todo?.Category;
            set
            {
                if (Todo.Category == value)
                    return;

                Todo.Category = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Category> Categories
        {
            get;
            set;
        }

        public void Reset()
        {
            Todo = new Todo();
        }

        public override void Cleanup()
        {
            Todo = null;
            Categories = null;

            base.Cleanup();
        }

        protected override bool CanClose(bool result)
        {
            return result ?
                Todo != null
                && !string.IsNullOrWhiteSpace(Todo.Header)
                && !string.IsNullOrWhiteSpace(Todo.Content)
                : true;
        }
    }
}
