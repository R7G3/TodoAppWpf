using System.Windows;
using TodoAppWpf.Helpers;

namespace TodoAppWpf.View
{
    /// <summary>
    /// Логика взаимодействия для CategoryEditorView.xaml
    /// </summary>
    public partial class CategoryEditorView : Window
    {
        CloseWindowHelper helper;

        public CategoryEditorView()
        {
            InitializeComponent();
            helper = new CloseWindowHelper(this);
        }
    }
}
