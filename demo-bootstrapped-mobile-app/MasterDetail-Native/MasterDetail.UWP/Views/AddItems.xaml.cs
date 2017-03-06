using MasterDetail.Helpers;
using MasterDetail.Model;
using MasterDetail.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MasterDetail.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddItems : Page
    {
        public ItemsViewModel browseViewModel { get; set; }
        public AddItems()
        {
            this.InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;


        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame.CanGoBack)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            var _item = new Item();
            _item.Text = txtText.Text;
            _item.Description = txtDesc.Text;
            MessagingCenter.Send(this, "AddItem", _item);
            MessagingCenter.ClearSubscribers();
            this.Frame.Navigate(typeof(MainPivot), browseViewModel);
        }
    }


}
