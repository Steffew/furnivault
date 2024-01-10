using Furnivault.Core.Interfaces;

namespace Furnivault.Tests
{
    internal class MockGroupRepository : IGroupRepository
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }

        public Group GetById(int Id)
        {
            return new Group(Id, "Group");
        }

        public IEnumerable<Group> GetAll()
        {
            return new List<Group>();
        }

        public void Add(Group group)
        {
            new List<Group>().Add(group);
        }

        public void Update(Group group)
        {
            Name = group.Name;
        }

        public void Delete(int id)
        {
            List<Group> list = new List<Group>();
            list.RemoveAt(id);
        }
    }
}