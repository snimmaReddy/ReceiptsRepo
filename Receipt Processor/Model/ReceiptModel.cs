using System;
namespace Receipt_Processor.Model
{
	public class ReceiptModel
	{
		public string Retailer { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchaseTime { get; set; }
        public decimal Total { get; set; }
		public List<ItemsModel> Items { get; set; }
	}
}

;