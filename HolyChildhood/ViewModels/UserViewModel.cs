using System.Collections.Generic;

namespace HolyChildhood.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}