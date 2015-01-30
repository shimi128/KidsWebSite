using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensions.ViewModels
{
    public class SideNav
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Level { get; set; }
        public int SortOrder { get; set; }
    }
}
