using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furnivault.Core.Interfaces;
using Furnivault.Data.DTOs;

public class ItemCollection
{
    private IRepository<ItemDTO> _itemRepository;
    public List<ItemDTO> Items { get; private set; }

    public ItemCollection(IRepository<ItemDTO> repository)
    {
        _itemRepository = repository;
    }

    public List<ItemDTO> GetAll()
    {
        return Items = _itemRepository.GetAll().ToList();
    }
}