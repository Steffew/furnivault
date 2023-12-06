using Furnivault.Core.Interfaces;

namespace Furnivault.Tests
{
    internal class MockRepository : IRepository<Item>
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }

        public Item GetById(int itemId)
        {
            return new Item("Item", $"{itemId}", "Description", false);
        }

        public IEnumerable<Item> GetAll()
        {
            return new List<Item>();
        }

        public void Add(Item item)
        {
            new List<Item>().Add(item);
        }

        public void Update(Item item)
        {
            Name = item.Name;
            Identifier = item.Identifier;
            Description = item.Description;
        }

        public void Delete(int id)
        {
            List<Item> list = new List<Item>();
            list.RemoveAt(id);
        }
    }
}