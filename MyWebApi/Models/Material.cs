namespace MyWebApi.Models
{
    public class Material
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? Category { get; set; }
        public string? SKU { get; set; }
        public string? ModelNumber { get; set; }

        public decimal UnitCost { get; set; }
        public int Quantity { get; set; }
        public bool IsConsumed { get; set; }
        public decimal TotalCost => UnitCost * Quantity;
        
        public string? Supplier { get; set; }
        public DateOnly? DatePurchased { get; set; }
        public string? RelatedDocuments { get; set; }
    }
}
