namespace pieShop.Models
{
    public class Pie
    {
        // Properties that we do not require a value for can be made nullable -
        // potentailly null inside the db
        public int PieId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? AllergyInformation { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailUrl { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryID { get; set; }
        // The ! is the null-forgiving operator, used to declare that this property
        // should NOT be null
        public Category Category { get; set; } = default!;

    }
}
