using System.ComponentModel.DataAnnotations;

namespace Assistans.Service.Frontend.Models.Dto
{
    public class IncomeDto
    {
        public int IncomeId { get; set; }
        public string? UserId { get; set; }
        public DateOnly Date { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
    }
}
