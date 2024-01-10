using Furnivault.Core.Entities;
using Furnivault.Core.Interfaces;

public class GroupCollection
{
    private readonly IGroupRepository _groupRepository;

    public IEnumerable<Group> GetAll()
    {
        return _groupRepository.GetAll();
    }

    public GroupCollection(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public Group GetById(int id)
    {
        return _groupRepository.GetById(id);
    }

    public Group Add(string name)
    {
        var group = new Group(name);
        _groupRepository.Add(group);
        return group;
    }

    public void Update(Group group, string newName)
    {
        if (group == null)
        {
            throw new KeyNotFoundException("Group is null!");
        }

        group.Update(newName);
        _groupRepository.Update(group);
    }

    public void Delete(int id)
    {
        _groupRepository.Delete(id);
    }
}