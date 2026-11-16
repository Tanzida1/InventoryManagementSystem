
namespace IMS.Entities.Inventory
{
    public class Unit
    {
        public int UnitId { get; set; }

        public string UnitName { get; set; } = string.Empty;

        public string Symbol { get; set; } = string.Empty;

        public ICollection<Item> Items { get; set; }
            = new List<Item>();
    }
}
