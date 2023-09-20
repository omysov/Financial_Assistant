using System.ComponentModel.DataAnnotations;

namespace Assistans.Service.ExpensesAPI.Models
{
    public class Expenses
    {
        [Key]
        public int ExpensesId { get; set; }
        public string? UserId { get; set; }
        public int CategoryId { get; set; }
        public DateOnly Date { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
    }
}
