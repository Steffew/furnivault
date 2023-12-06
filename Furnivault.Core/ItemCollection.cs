using Furnivault.Core.Entities;
using Furnivault.Core.Interfaces;

public class ItemCollection
{
    //todo: refactor or delete this
    private IRepository<Item> _itemRepository;

    public List<Item> Items { get; private set; }

    public ItemCollection(IRepository<Item> repository)
    {
        _itemRepository = repository;
    }

    public List<Item> GetAll()
    {
        return Items = _itemRepository.GetAll().ToList();
    }
}