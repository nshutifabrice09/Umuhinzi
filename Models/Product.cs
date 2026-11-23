namespace Umuhinzi.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string UnitOfMeasurement { get; set; } = string.Empty;
    }
}
