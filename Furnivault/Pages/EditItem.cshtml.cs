using Furnivault.Core.Entities;
using Furnivault.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        private Item item;
        private ItemCollection _itemCollection;

        [BindProperty]
        public EditItemViewModel ItemViewModel { get; set; }

        public EditItemModel(IItemRepository repo)
        {
            _itemCollection = new ItemCollection(repo);
        }

        public void OnGet(int id)
        {
            var item = _itemCollection.GetById(id);
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

            var existingItem = _itemCollection.GetById(ItemViewModel.ItemId);
            if (existingItem != null)
            {
                existingItem.Update(ItemViewModel.Name, ItemViewModel.Identifier, ItemViewModel.Description);
                _itemCollection.Update(existingItem);
                return RedirectToPage("Index");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult OnPostDelete(int id)
        {
            _itemCollection.Delete(id);
            return RedirectToPage("Index");
        }
    }
}