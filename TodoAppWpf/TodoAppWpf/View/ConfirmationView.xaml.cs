using System.Windows;
using TodoAppWpf.Helper;

namespace TodoAppWpf.View
{
    /// <summary>
    /// Логика взаимодействия для ConfirmationView.xaml
    /// </summary>
    public partial class ConfirmationView : Window
    {
        CloseWindowHelper helper;

        public ConfirmationView()
        {
            InitializeComponent();
            helper = new CloseWindowHelper(this);
        }
    }
}
