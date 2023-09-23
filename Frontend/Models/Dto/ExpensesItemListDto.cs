namespace Frontend.Models.Dto
{
    public class ExpensesItemListDto
    {
        public int ExpensesId { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public string? UserId { get; set; }
        public DateOnly Date { get; set; }
        public int Count { get; set; }
        public string? Description { get; set; }
    }
}
