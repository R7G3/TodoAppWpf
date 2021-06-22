using System.Collections.ObjectModel;
using TodoAppWpf.Model;

namespace TodoAppWpf.ViewModel
{
    interface ITodoEditor
    {
        Todo Todo { get; set; }

        Category Category { get; set; }

        ObservableCollection<Category> Categories { get; set; }

        void Reset();
    }
}
