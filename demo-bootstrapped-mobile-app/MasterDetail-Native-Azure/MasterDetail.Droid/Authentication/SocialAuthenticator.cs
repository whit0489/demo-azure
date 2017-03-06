using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using MasterDetail.Services;
using Plugin.CurrentActivity;

namespace MasterDetail.Droid.Authentication
{
    public class SocialAuthentication : BaseSocialAuthenticator
    {
        public override async Task<MobileServiceUser> LoginAsync(IMobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {
                
                return await client.LoginAsync(CrossCurrentActivity.Current.Activity, provider, parameters);
 
            }
            catch (Exception e)
            {
                e.Data["method"] = "LoginAsync";
            }

            return null;
        }

        public override void ClearCookies()
        {
            try
            {
                if ((int)global::Android.OS.Build.VERSION.SdkInt >= 21)
                    global::Android.Webkit.CookieManager.Instance.RemoveAllCookies(null);
            }
            catch (Exception ex)
            {
            }
        }
    }
}