namespace SimpleFastReport.API.DTOs
{
    public class OrderReponseDTO
    {
        public int OrderId { get; set; }
        public int ItemCount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Net { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public List<OrderDetailReponseDTO> OrderDetails { get; set; }
    }

    public class OrderDetailReponseDTO
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int ProcuctQuantity { get; set; }
        public ProductResponeDTO ProductDetail { get; set; }
    }

    public class ProductResponeDTO
    {
        public int ProductId { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public ProductGroupResponseDTO ProductGroup { get; set; }
    }

    public class ProductGroupResponseDTO
    {
        public int ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }
    }

}
