using System.Collections.Generic;

namespace WebExtensions.ViewModels
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
        public bool IsActive { get; set; }
        public IList<MenuItem> Children { get; set; }
        public string ImageIconUrl { get; set; }
        public string NodeTypeAlias { get; set; }

        public MenuItem()
        {
            Children = new List<MenuItem>();
        }
    }
}
