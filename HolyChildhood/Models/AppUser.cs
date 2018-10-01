using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HolyChildhood.Models
{
    public class AppUser : IdentityUser { }

    public class Parishioner
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public AppUser User { get; set; }
        public List<Member> GroupMemberships { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Member> Members { get; set; }
    }

    public class Member
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public Parishioner Parishioner { get; set; }
        public Group Group { get; set; }
    }
}