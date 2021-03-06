﻿using System.Threading.Tasks;
using System.Windows.Input;

using MasterDetail.Helpers;
using MasterDetail.Services;
using MasterDetail.Model;

namespace MasterDetail.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {

        }

        string message = string.Empty;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        public ICommand NotNowCommand { get; }
        public ICommand SignInCommand { get; }

        public async Task SignIn()
        {
            try
            {
                IsBusy = true;
                Message = "Signing In...";

                // Log the user in
                await TryLoginAsync();
            }
            finally
            {
                Message = string.Empty;
                IsBusy = false;

            }
        }

        public static async Task<bool> TryLoginAsync()
        {
            Settings.UserId = System.Guid.NewGuid().ToString();

            return true;
        }
    }
}