using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examine;

namespace WebExtensions.Services
{
    public interface IExternalSearchService
    {
        ISearchResults Search(string text, int homeNodeId); 
    }
}
