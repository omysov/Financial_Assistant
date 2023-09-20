using System.ComponentModel.DataAnnotations;

namespace Assistans.Service.IncomeAPI.Models
{
    public class IncomeDto
    {
        public int IncomeId { get; set; }
        //public int CategoryId { get; set; } // Category 
        public string? UserId { get; set; }
        public TimeOnly TimeOnly { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
    }
}
