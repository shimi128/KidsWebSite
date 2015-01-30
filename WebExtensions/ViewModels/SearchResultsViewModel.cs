using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examine;

namespace WebExtensions.ViewModels
{
    public class SearchResultsViewModel:BaseViewModel
    {
        public string Message { get; set; }
        public ISearchResults Results { get; set; }
    }
}
