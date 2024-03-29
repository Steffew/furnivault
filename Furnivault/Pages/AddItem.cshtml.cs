using Furnivault.Core.Entities;
using Furnivault.Core.Interfaces;
using Furnivault.Core.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Furnivault.Pages
{
    public class AddItemViewModel
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class AddItemModel : PageModel
    {
        private readonly ItemCollection _itemCollection;
        private readonly ItemValidator _itemValidator;
        public string ErrorMessage { get; set; }

        [BindProperty]
        public AddItemViewModel Item { get; set; }

        public AddItemModel(IItemRepository repo)
        {
            _itemValidator = new ItemValidator();
            _itemCollection = new ItemCollection(repo);
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _itemValidator.ValidateString("Item name", Item.Name, 2, 32);
                _itemValidator.ValidateString("Item identifier", Item.Identifier, 2, 32);
                _itemValidator.ValidateString("Item description", Item.Description, 4, 64);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"{ex.Message}";
                return Page();
            }

            var newItem = _itemCollection.Add(Item.Name, Item.Identifier, Item.Description);

            return RedirectToPage("./Index");
        }
    }
}