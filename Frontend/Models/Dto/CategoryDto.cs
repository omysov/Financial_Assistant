using System.ComponentModel.DataAnnotations;

namespace Assistans.Service.Frontend.Models.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string Name { get; set; }
    }
}
