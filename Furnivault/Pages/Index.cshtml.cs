using Microsoft.AspNetCore.Mvc.RazorPages;
using Furnivault.Core.Interfaces;
using Furnivault.Core.Entities;

public class IndexModel : PageModel
{
    private readonly IRepository<Item> _ItemRepository;
    private ItemCollection _ItemCollection;
    public List<Item> Items { get; private set; }

    public IndexModel(IRepository<Item> itemRepository)
    {
        _ItemRepository = itemRepository;
        _ItemCollection = new ItemCollection(_ItemRepository);
    }

    public void OnGet()
    {
        Items = _ItemCollection.GetAll();
    }
}