using System.ComponentModel.DataAnnotations;

namespace Assistans.Service.IncomeAPI.Models
{
    public class Income
    {
        [Key]
        public int IncomeId { get; set; }
        public string? UserId { get; set; }
        public DateOnly Date { get; set; }
        public int Count { get; set; }
        public string? Description { get; set; }
    }
}
