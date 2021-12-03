using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.WK
{
    public class NavigationMenu
    {
        public int Id { get; set; }
        public virtual int? Module_Father { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public List<NavigationMenu> Children { get; set; }
    }
}
