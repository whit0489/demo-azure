using MasterDetail.Helpers;
using MasterDetail.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasterDetail.Model;
using System.Threading.Tasks;


namespace MasterDetail.ViewModel
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
        	if(item != null)
        	{
	            Title = item.Text;
	            Item = item;
       		}
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}