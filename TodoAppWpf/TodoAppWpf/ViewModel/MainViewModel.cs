using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TodoAppWpf.Helper;
using TodoAppWpf.Model;
using TodoAppWpf.WindowPool;

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
        private IServiceLocator serviceLocator;
        private IDialogPool dialogPool;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Todos = new ObservableCollection<Todo>();
            Categories = new ObservableCollection<Category>();

            if (IsInDesignMode)
            {
                GenerateDataForVisualDesigner();
                return;
            }

            serviceLocator = SimpleIoc.Default;
            dialogPool = serviceLocator.GetInstance<IDialogPool>();

            AddTodoCommand = new RelayCommand(AddTodoExecute);
            EditTodoCommand = new RelayCommand(EditTodoExecute, CanEditTodo);
            DeleteTodoCommand = new RelayCommand(DeleteTodoExecute, CanDeleteTodo);
            AddCategoryCommand = new RelayCommand(AddCategoryExecute);
            DeleteCategoryCommand = new RelayCommand<Category>(
                category => DeleteCategoryExecute(category),
                category => CanDeleteCategory(category)
            );
        }

        void GenerateDataForVisualDesigner()
        {
            for (int i = 0; i < 6; i++)
            {
                Categories.Add(
                    VisualDesignerDataGenerator.GenerateCategory()
                );

                Todos.Add(
                    VisualDesignerDataGenerator.GenerateTodo(Categories[i])
                );
            }
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


        #region Add Todo command

        public ICommand AddTodoCommand
        {
            get;
            private set;
        }

        void AddTodoExecute()
        {
            var editorPresentation = dialogPool.GetDialog<ITodoEditor>();
            var editor = editorPresentation.Content;
            editor.Reset();
            editor.Categories = Categories;

            if (editorPresentation.Show())
            {
                //Do
            }
        }

        #endregion

        #region Edit Todo command

        public ICommand EditTodoCommand
        {
            get;
            private set;
        }

        void EditTodoExecute()
        {
            var editorPresentation = dialogPool.GetDialog<ITodoEditor>();
            var editor = editorPresentation.Content;
            editor.Todo = SelectedTodo;
            editor.Categories = Categories;

            if (editorPresentation.Show())
            {
                //Do
            }
        }

        bool CanEditTodo()
        {
            return SelectedTodo != null;
        }

        #endregion

        #region Delete Todo command

        public ICommand DeleteTodoCommand
        {
            get;
            private set;
        }

        void DeleteTodoExecute()
        {
            var confirmationPresentation = dialogPool.GetDialog<IConfirmationDialog>();
            confirmationPresentation.Content.Reset();

            if (confirmationPresentation.Show())
            {
                //Do
            }
        }

        bool CanDeleteTodo()
        {
            return SelectedTodo != null;
        }

        #endregion

        #region Add Category command

        public ICommand AddCategoryCommand
        {
            get;
            private set;
        }

        void AddCategoryExecute()
        {
            var editorPresentation = dialogPool.GetDialog<ICategoryEditor>();
            var editor = editorPresentation.Content;
            editor.Reset();
            editor.ExistentCategories = Categories;

            if (editorPresentation.Show())
            {
                //Do
            }
        }

        #endregion

        #region Delete Category command

        public ICommand DeleteCategoryCommand
        {
            get;
            private set;
        }

        void DeleteCategoryExecute(Category category)
        {
            var confirmationPresentation = dialogPool.GetDialog<IConfirmationDialog>();
            confirmationPresentation.Content.Reset();

            if (confirmationPresentation.Show())
            {
                //Do delete category
            }
        }

        bool CanDeleteCategory(Category category)
        {
            return !string.IsNullOrWhiteSpace(category?.Name);
        }

        #endregion

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