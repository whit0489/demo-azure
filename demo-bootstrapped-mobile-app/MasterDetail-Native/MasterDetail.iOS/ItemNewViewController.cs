using System;

using UIKit;
using MasterDetail.Model;
using MasterDetail.ViewModel;
using MasterDetail.Helpers;
using MasterDetail.Services;
using System.Threading.Tasks;

namespace MasterDetail.iOS
{
	public partial class ItemNewViewController : UIViewController
	{
		public Item Item { get; set; }
		public IDataStore<Item> DataStore => ServiceLocator.Instance.Get<IDataStore<Item>>();
		public ItemsViewModel viewModel { get; set; }

		public ItemNewViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.


			btnSaveItem.TouchUpInside += (sender, e) =>
			{
				var _item = new Item();
				_item.Text = txtTitle.Text;
				_item.Description = txtDesc.Text;
				MessagingCenter.Send(this, "AddItem", _item);
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

