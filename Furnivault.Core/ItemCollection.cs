using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furnivault.Core.Interfaces;
using Furnivault.Core.Entities;

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