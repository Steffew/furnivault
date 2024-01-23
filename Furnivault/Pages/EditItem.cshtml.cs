using Furnivault.Core.Entities;
using Furnivault.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Furnivault.Pages
{
    public class EditItemViewModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }
        public int SelectedGroupId { get; set; }
        public List<Group>? GroupList { get; set; }
    }

    public class EditItemModel : PageModel
    {
        private Item item;
        private ItemCollection _itemCollection;
        private GroupCollection _groupCollection;

        [BindProperty]
        public EditItemViewModel ItemViewModel { get; set; }
        public List<Group> GroupList { get; set; }

        public EditItemModel(IItemRepository repo, IGroupRepository groupRepo)
        {
            _itemCollection = new ItemCollection(repo);
            _groupCollection = new GroupCollection(groupRepo);
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
                // TODO: Exception if item is null
            }

            GroupList = LoadGroupList();
        }

        public IActionResult OnPost()
        {
            GroupList = LoadGroupList();
            
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return Page();
            }

            var existingItem = _itemCollection.GetById(ItemViewModel.ItemId);
            if (existingItem != null)
            {
                existingItem.Update(ItemViewModel.Name, ItemViewModel.Identifier, ItemViewModel.Description);
                existingItem.SetGroupId(ItemViewModel.SelectedGroupId); // TODO: Implement SetGroupId method
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

        private List<Group> LoadGroupList()
        {
            var groups = _groupCollection.GetAll();
            return groups.ToList();
        }
    }
}
