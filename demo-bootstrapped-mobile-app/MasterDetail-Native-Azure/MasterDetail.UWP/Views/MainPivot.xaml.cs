using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MasterDetail.Model;
using MasterDetail.ViewModel;
using System.Collections.Specialized;
using Windows.UI.Core;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MasterDetail.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
   
    public sealed partial class MainPivot : Page
    {
        private ItemsViewModel browseViewModel;

        public MainPivot()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            browseViewModel = (ItemsViewModel)this.DataContext;
            browseViewModel.LoadItemsCommand.Execute(null);
            gvItems.ItemsSource = browseViewModel.Items;
            gvItems.ItemClick += GvItems_ItemClick;
          
        }


        public void Show_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddItems));
        }

        private void GvItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Item;
            if (item == null)
            {
                return;
            }
            // this.Frame.Navigate(typeof(BrowseItemDetail((item)));
            var db = new ItemDetailViewModel(item);
            this.Frame.Navigate(typeof(BrowseItemDetail), item);
            gvItems.SelectedItem = null;
        }

    }
}
