namespace Assistant.Service.ExpensesAPI.Models.Dto
{
    public class CategoryCountDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
