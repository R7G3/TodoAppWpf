using System.Collections.Generic;
using System.Linq;
using TodoAppWpf.Helper;
using TodoAppWpf.Model;

namespace TodoAppWpf.ViewModel
{
    public class CategoryEditorViewModel : DialogViewModel
    {
        public CategoryEditorViewModel()
        {
            ExistentCategories = new List<Category>();
#if DEBUG
            if (IsInDesignMode)
            {
                Category = VisualDesignerDataGenerator.GenerateCategory();
                return;
            }
#endif

            Category = new Category();
        }

        public Category Category
        {
            get;
            set;
        }

        public ICollection<Category> ExistentCategories
        {
            get;
            set;
        }

        public string Name
        {
            get => Category?.Name;
            set
            {
                if (Category.Name == value)
                    return;

                Category.Name = value;
                RaisePropertyChanged();
            }
        }

        public void Reset()
        {
            Category = new Category();
            ExistentCategories?.Clear();
        }

        public override void Cleanup()
        {
            Category = null;
            ExistentCategories = null;

            base.Cleanup();
        }

        protected override bool CanClose(bool result)
        {
            return result ? IsFilledAndUnique(Category) : true;
        }

        bool IsFilledAndUnique(Category category)
        {
            return
                category != null
                && !string.IsNullOrWhiteSpace(category.Name)
                && !ExistentCategories.Any(x => x.Name == category.Name);
        }
    }
}
