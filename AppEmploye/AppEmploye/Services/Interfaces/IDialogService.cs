using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppEmploye.Services.Interfaces
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);

        Task<bool> ConfirmAsync(string message, string title, string okText, string cancelText);

        IProgressDialog LoadingAlert(string title, bool show, MaskType masktype);

        IDisposable ToastAlert(string title);
    }
}
