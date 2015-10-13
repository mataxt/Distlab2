using Dist_Lab2.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dist_Lab2.ViewModels
{
    public class GroupsViewModels
    {
        public String GroupsName { get; set; }
        public String GroupsMember { get; set; }
        
        public GroupsViewModels(String GroupsName, String GroupsMember)
        {
            this.GroupsName = GroupsName;
            this.GroupsMember = GroupsMember;
        }
    }
}