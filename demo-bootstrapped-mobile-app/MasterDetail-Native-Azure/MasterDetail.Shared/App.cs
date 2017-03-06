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
using Microsoft.Identity.Client;
using MasterDetail.Model;

#if AZURE

#else
//using MasterDetail.Services.Standard;
#endif
using System;
namespace MasterDetail
{
    public partial class App 
    {
        public static bool AzureNeedsSetup => AzureMobileAppUrl == "https://CONFIGURE-THIS-URL.azurewebsites.net";
        public static string AzureMobileAppUrl = "https://myitemsapp.azurewebsites.net/";

        public App()
        {
        }

        public static void Initialize()
        {

            if (AzureNeedsSetup)
                ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
            else
                ServiceLocator.Instance.Register<IDataStore<Item>, AzureDataStore>();
#if __IOS__
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			SQLitePCL.CurrentPlatform.Init();
#elif __ANDROID__
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
#endif
            ServiceLocator.Instance.Register<IMessageDialog, MessageDialog>();
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();


        }

        public static IDictionary<string, string> LoginParameters => null;
    }
}