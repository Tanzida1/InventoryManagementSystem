
namespace IMS.Entities.Inventory
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Item> Items { get; set; }
            = new List<Item>();
    }
}
