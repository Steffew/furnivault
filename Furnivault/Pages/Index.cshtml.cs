using Furnivault.Core.Entities;
using Furnivault.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public List<Item> Items { get; private set; }
    private readonly ItemCollection _itemCollection;

    public IndexModel(IItemRepository repo)
    {
        _itemCollection = new ItemCollection(repo);
    }

    public void OnGet()
    {
        Items = _itemCollection.GetAll().ToList();
    }
}