using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Furnivault.Core.Interfaces;
using Furnivault.Core.Entities;

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

        [BindProperty]
        public EditItemViewModel ItemViewModel { get; set; }

        public void OnGet(int id)
        {
            var item = _itemRepository.GetById(id);
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

            var existingItem = _itemRepository.GetById(ItemViewModel.ItemId);
            if (existingItem != null)
            {
                existingItem.Update(ItemViewModel.Name, ItemViewModel.Identifier, ItemViewModel.Description);
                _itemRepository.Update(existingItem);
                return RedirectToPage("Index");
            }
            else
            {
                return NotFound();
            }
        }


    }
}
