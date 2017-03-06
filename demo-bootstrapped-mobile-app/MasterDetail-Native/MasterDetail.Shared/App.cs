using System.Collections.Generic;
#if __ANDROID__
using MasterDetail.Droid.Helpers;
#elif __IOS__
using MasterDetail.iOS.Helpers;
#elif WINDOWS_UWP
using MasterDetail.UWP.Helpers;
#endif
using MasterDetail.Helpers;
using MasterDetail.Interfaces;
using MasterDetail.Services;
using MasterDetail.Model;

using System;
namespace MasterDetail
{
    public partial class App 
    {
        public App()
        {
        }

        public static void Initialize()
        {
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
#if __IOS__
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			SQLitePCL.CurrentPlatform.Init();
#elif __ANDROID__
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
#endif
            ServiceLocator.Instance.Register<IMessageDialog, MessageDialog>();
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
        }
    }
}