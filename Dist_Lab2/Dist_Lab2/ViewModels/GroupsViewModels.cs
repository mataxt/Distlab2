using Dist_Lab2.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dist_Lab2.ViewModels
{
    public class GroupsViewModels
    {
        public string GroupsName { get; set; }
        public string GroupsMember { get; set; }

        public GroupsViewModels(string GroupsName, string GroupsMember)
        {
            this.GroupsName = GroupsName;
            this.GroupsMember = GroupsMember;
        }
    }
}