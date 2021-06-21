using System.Windows;
using TodoAppWpf.Helper;

namespace TodoAppWpf.View
{
    /// <summary>
    /// Логика взаимодействия для TodoEditorView.xaml
    /// </summary>
    public partial class TodoEditorView : Window
    {
        CloseWindowHelper helper;

        public TodoEditorView()
        {
            InitializeComponent();
            helper = new CloseWindowHelper(this);
        }
    }
}
