using Furnivault.Core.Entities;
using Furnivault.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public List<Item> Items { get; private set; }
    private readonly ItemCollection _itemService;

    public IndexModel(IRepository<Item> repo)
    {
        _itemService = new ItemCollection(repo);
    }

    public void OnGet()
    {
        Items = _itemService.GetAll().ToList();
    }
}