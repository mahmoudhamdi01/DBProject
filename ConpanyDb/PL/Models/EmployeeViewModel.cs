using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Range(22, 40)]
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public DateTime? HiringDate { get; set; }
        public DateTime? DateOfCreation { get; set; }
    }
}
