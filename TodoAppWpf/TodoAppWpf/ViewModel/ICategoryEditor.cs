using System.Collections.Generic;
using TodoAppWpf.Model;

namespace TodoAppWpf.ViewModel
{
    interface ICategoryEditor
    {
        Category Category { get; set; }

        ICollection<Category> ExistentCategories { get; set; }

        void Reset();
    }
}
