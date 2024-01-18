using Furnivault.Core.Entities;
using Furnivault.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Furnivault.Pages
{
    public class GroupsModel : PageModel
    {
        private GroupCollection _groupCollection;

        [BindProperty]
        public string NewGroupName { get; set; }

        [BindProperty]
        public int GroupId { get; set; }

        [BindProperty]
        public string GroupName { get; set; }

        public IEnumerable<Group> Groups => _groupCollection.GetAll();

        public GroupsModel(IGroupRepository repo)
        {
            _groupCollection = new GroupCollection(repo);
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostAddGroup()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _groupCollection.Add(NewGroupName);
            return RedirectToPage();
        }

        public IActionResult OnPostUpdateGroup()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var group = _groupCollection.GetById(GroupId);
            if (group != null)
            {
                group.Update(GroupName);
                return RedirectToPage();
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult OnPostDeleteGroup(int groupId)
        {
            _groupCollection.Delete(groupId);
            return RedirectToPage();
        }
    }
}
