namespace SimpleFastReport.API.DTOs
{
	public class OrderDetailReponseDTO
	{
		public int OrderDetailId { get; set; }
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public string ProductSku { get; set; }
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public int ProductCategoryId { get; set; }
		public string ProductCategoryName { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal Discount { get; set; }
		public decimal LineTotal { get; set; }
		public string Notes { get; set; }
	}
}
