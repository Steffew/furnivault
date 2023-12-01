using Microsoft.AspNetCore.Mvc.RazorPages;
using Furnivault.Core.Interfaces;
using Furnivault.Core.Entities;

public class IndexModel : PageModel
{
    private readonly IRepository<Item> _itemRepository;
    public List<Item> Items { get; private set; }

    public IndexModel(IRepository<Item> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public void OnGet()
    {
        Items = _itemRepository.GetAll().ToList();
    }
}