using Acr.UserDialogs;
using AppEmploye.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppEmploye.Services
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }
        /// <summary>
        /// Display a confirm dialog to user
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="okText"></param>
        /// <param name="cancelText"></param>
        /// <returns></returns>
        public Task<bool> ConfirmAsync(string message, string title, string okText, string cancelText)
        {
            return UserDialogs.Instance.ConfirmAsync(message, title, okText, cancelText);
        }

        public IProgressDialog LoadingAlert(string title, bool show, MaskType masktype)
        {
            return UserDialogs.Instance.Loading(title, null, null, show, masktype);
        }
        public IDisposable ToastAlert(string title)
        {
            return UserDialogs.Instance.Toast(title);
        }
    }
}
