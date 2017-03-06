using System;
using UIKit;

using MasterDetail.Helpers;
using MasterDetail.ViewModel;

namespace MasterDetail.iOS
{
    public partial class LoginViewController : UIViewController
    {
		public LoginViewModel ViewModel;

		public LoginViewController(IntPtr handle) : base(handle) 
		{
			ViewModel = new LoginViewModel();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = ViewModel.Title;

		}

		partial void NotNowButton_TouchUpInside(UIButton sender) => NavigateToTabbed();

		async partial void LoginButton_TouchUpInside(UIButton sender)
		{
            await ViewModel.SignIn();
            if (Settings.IsLoggedIn)
                NavigateToTabbed();
        }

        void NavigateToTabbed()
		{
			InvokeOnMainThread(() =>
				{
					var app = (AppDelegate)UIApplication.SharedApplication.Delegate;
					app.Window.RootViewController = UIStoryboard.FromName("Main", null)
													 .InstantiateViewController("tabViewController")
													 as UITabBarController;
				});
		}
	}
}