using System.Windows;
using TodoAppWpf.Helper;

namespace TodoAppWpf.View
{
    /// <summary>
    /// Логика взаимодействия для ErrorMessageView.xaml
    /// </summary>
    public partial class ErrorMessageView : Window
    {
        CloseWindowHelper helper;

        public ErrorMessageView()
        {
            InitializeComponent();
            helper = new CloseWindowHelper(this);
        }
    }
}
