using System.ComponentModel.DataAnnotations;

namespace Assistant.Service.ExpensesAPI.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string Name { get; set; }
    }
}
