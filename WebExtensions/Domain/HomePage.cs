using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExtensions.PropertyEditorTypes;

namespace WebExtensions.Domain
{
    public class HomePage:BaseContent
    {
        public IList<GameFeature> GamesPicker { get; set; }
        public IList<MovieFeature> MoviesPicker { get; set; }
        public IList<MovieFeature> ClipsPicker { get; set; }
        public IList<NewsFeature> NewsPicker { get; set; }
        public IList<HomePageImages> Images { get; set; }
        public IList<ImageFeature> MediaPicker { get; set; }

        public HomePage()
        {
            GamesPicker = new List<GameFeature>();
            MoviesPicker = new List<MovieFeature>();
            ClipsPicker = new List<MovieFeature>();
            NewsPicker = new List<NewsFeature>();
            Images = new List<HomePageImages>();
            MediaPicker = new List<ImageFeature>();
        }
    }
}
