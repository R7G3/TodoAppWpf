using System;
using System.Collections.Generic;
using TodoAppWpf.ViewModel;

namespace TodoAppWpf.WindowPool
{
    class DialogPool : IDialogPool
    {
        static IDialogPool _instance;

        private DialogPool() { }

        public static IDialogPool GetInstance()
        {
            return _instance ?? (_instance = new DialogPool());
        }

        public IGenericDialogPresentation<TDialogType> GetDialog<TDialogType>()
        {
            var result = dialogs[typeof(TDialogType)] ?? (dialogs[typeof(TDialogType)] = CreatePresentation(typeof(TDialogType)));

            return (IGenericDialogPresentation<TDialogType>)result;
        }

        readonly Dictionary<Type, IDialogPresentation> dialogs = new Dictionary<Type, IDialogPresentation>()
        {
            { typeof(ITodoEditor), null },
            { typeof(ICategoryEditor), null },
            { typeof(IConfirmationDialog), null },
            { typeof(IErrorMessage), null }
        };

        IDialogPresentation CreatePresentation(Type dialogType)
        {
            if (dialogType == typeof(ITodoEditor))
            {
                return new TodoEditorPresentation();
            }
            else if (dialogType == typeof(ICategoryEditor))
            {
                return new CategoryEditorPresentation();
            }
            else if (dialogType == typeof(IConfirmationDialog))
            {
                return new ConfirmationDialogPresentation();
            }
            else if (dialogType == typeof(IErrorMessage))
            {
                return new ErrorMessagePresentation();
            }
            else return null;
        }
    }
}
