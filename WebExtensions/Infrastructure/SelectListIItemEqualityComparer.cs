using System.Web.Mvc;
using System.Collections.Generic;

namespace WebExtensions.Infrastructure
{
    public class SelectListIItemEqualityComparer : IEqualityComparer<SelectListItem>
    {
        
        public bool Equals(SelectListItem x, SelectListItem y)
        {
            return x.Value.Equals(y.Value);
        }

        public int GetHashCode(SelectListItem obj)
        {
            return obj.Value.GetHashCode();
        }
    }
}
