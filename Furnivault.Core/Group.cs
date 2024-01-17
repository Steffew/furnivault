using Furnivault.Core.Interfaces;

namespace Furnivault.Core.Entities
{
    public class Group
    {
        private readonly IGroupRepository _groupRepository;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Item> Items { get; private set; }

        public Group(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
            _groupRepository.Update(this);
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