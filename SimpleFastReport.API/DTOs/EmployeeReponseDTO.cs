namespace SimpleFastReport.API.DTOs
{
    public class EmployeeReponseDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
        public string ImageUrl { get; set; }

	}

}
