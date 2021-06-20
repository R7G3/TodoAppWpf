using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TodoAppWpf.Model;

namespace TodoAppWpf.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        public ObservableCollection<Todo> Todos
        {
            get;
            set;
        }

        public ObservableCollection<Category> Categories
        {
            get;
            set;
        }


        private Todo selectedTodo;

        public Todo SelectedTodo
        {
            get => selectedTodo;
            set
            {
                selectedTodo = value;
                RaisePropertyChanged();
            }
        }


        private Category selectedCategory;

        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                RaisePropertyChanged();
            }
        }


        public ICommand AddTodoCommand
        {
            get;
            private set;
        }

        public ICommand EditTodoCommand
        {
            get;
            private set;
        }

        public ICommand DeleteTodoCommand
        {
            get;
            private set;
        }

        public ICommand AddCategoryCommand
        {
            get;
            private set;
        }

        public ICommand DeleteCategoryCommand
        {
            get;
            private set;
        }

        public override void Cleanup()
        {
            Todos = null;
            SelectedTodo = null;

            Categories = null;
            SelectedCategory = null;

            AddTodoCommand = null;
            EditTodoCommand = null;
            DeleteTodoCommand = null;

            AddCategoryCommand = null;
            DeleteCategoryCommand = null;

            base.Cleanup();
        }
    }
}