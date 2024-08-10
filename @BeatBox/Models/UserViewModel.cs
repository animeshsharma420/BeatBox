using Microsoft.AspNetCore.Mvc.Rendering;

namespace _BeatBox.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } = new List<string>();

        public List<SelectListItem> AvailableRoles { get; set; } = new List<SelectListItem>();
    }
}
