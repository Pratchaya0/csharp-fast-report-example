namespace SimpleFastReport.API.DTOs
{
	public class OrderReponseDTO
	{
		public int OrderId { get; set; }
		public string OrderNumber { get; set; }
		public DateTime OrderDate { get; set; }
		public int? CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string CustomerPhone { get; set; }
		public string CustomerEmail { get; set; }
		public int EmployeeId { get; set; }
		public string EmployeeName { get; set; }
		public string EmployeePhone { get; set; }
		public string EmployeeEmail { get; set; }
		public int LocationId { get; set; }
		public string LocationName { get; set; }
		public string LocationPhone { get; set; }
		public string LocationAddress { get; set; }
		public string LocationCity { get; set; }
		public string LocationPostalCode { get; set; }
		public decimal SubTotal { get; set; }
		public decimal TaxAmount { get; set; }
		public decimal DiscountAmount { get; set; }
		public decimal TotalAmount { get; set; }
		public int StatusId { get; set; }
		public string StatusName { get; set; }
		public string Notes { get; set; }
	}
}
