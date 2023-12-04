using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Furnivault.Core.Interfaces;
using Furnivault.Core.Entities;
using Furnivault.Data.Repositories;

namespace Furnivault.Pages
{
    public class EditItemViewModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }
    }

    public class EditItemModel : PageModel
    {
        private readonly IRepository<Item> _itemRepository;
        private Item item;
        private ItemService _itemService;

        [BindProperty]
        public EditItemViewModel ItemViewModel { get; set; }

        public EditItemModel(IRepository<Item> repo)
        {
            _itemRepository = repo;
            _itemService = new ItemService(repo);
        }

        public void OnGet(int id)
        {
            var item = _itemService.GetById(id);
            if (item != null)
            {
                ItemViewModel = new EditItemViewModel
                {
                    ItemId = item.ItemId,
                    Name = item.Name,
                    Identifier = item.Identifier,
                    Description = item.Description
                };
            }
            else
            {
                //todo: Exception if item is null
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingItem = _itemService.GetById(ItemViewModel.ItemId);
            if (existingItem != null)
            {
                existingItem.Update(ItemViewModel.Name, ItemViewModel.Identifier, ItemViewModel.Description);
                _itemService.Update(existingItem);
                return RedirectToPage("Index");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult OnPostDelete(int id)
        {
            _itemService.Delete(id);
            return RedirectToPage("Index");
        }
    }
}