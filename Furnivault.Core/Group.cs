namespace Furnivault.Core.Entities
{
    public class Group
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Item> Items { get; private set; }

        public Group(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
    }
}