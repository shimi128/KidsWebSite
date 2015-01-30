using System.Collections.Generic;
using WebExtensions.PropertyEditorTypes;

namespace WebExtensions.ViewModels
{
    public class HomePageViewModel:BaseViewModel
    {
        public IList<GameFeature> GamesPicker { get; set; }
        public IList<MovieFeature> MoviesPicker { get; set; }
        public IList<MovieFeature> ClipsPicker { get; set; }
        public IList<NewsFeature> NewsPicker { get; set; }
        public IList<HomePageImages> Images { get; set; }
        public IList<ImageFeature> MediaPicker { get; set; }


        public HomePageViewModel()
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
