using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace CompanyNews
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public IList<NewsItem> NewsItems { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            NewsItems = new List<NewsItem>();

            NewsItems.Add(new NewsItem
            {
                Title = "Cafeteria is now open!",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi lorem lectus, eleifend id sagittis eu, finibus et diam. Mauris sed ultrices nisl, nec vulputate felis. Fusce lobortis scelerisque urna, et imperdiet orci iaculis non. Duis egestas risus a sodales porta. Nam vel mollis tellus. Suspendisse rutrum semper eros interdum pretium. Phasellus et justo ultrices nunc cursus vehicula. Maecenas lacus nibh, aliquet at faucibus id, aliquet quis magna. Aliquam erat volutpat. In posuere iaculis ligula quis laoreet. Vivamus urna metus, eleifend quis orci ac, pellentesque tristique odio. Nunc egestas enim id erat auctor laoreet. Donec dictum quis lacus faucibus ultrices. Nam eu fermentum sem. In nec velit turpis. Cras tincidunt porta euismod.",
                ImageUrl = "http://cafeteria15l.com/wp-content/uploads/2015/03/about-cafeteria02.jpg"
            });

            NewsItems.Add(new NewsItem
            {
                Title = "Public Holiday Next Week",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi lorem lectus, eleifend id sagittis eu, finibus et diam. Mauris sed ultrices nisl, nec vulputate felis. Fusce lobortis scelerisque urna, et imperdiet orci iaculis non. Duis egestas risus a sodales porta. Nam vel mollis tellus. Suspendisse rutrum semper eros interdum pretium. Phasellus et justo ultrices nunc cursus vehicula. Maecenas lacus nibh, aliquet at faucibus id, aliquet quis magna. Aliquam erat volutpat. In posuere iaculis ligula quis laoreet. Vivamus urna metus, eleifend quis orci ac, pellentesque tristique odio. Nunc egestas enim id erat auctor laoreet. Donec dictum quis lacus faucibus ultrices. Nam eu fermentum sem. In nec velit turpis. Cras tincidunt porta euismod.",
                ImageUrl = "https://media.cntraveler.com/photos/54e64996560f0bf2218e5772/master/pass/beach-boracay-philippines.jpg"
            });

            NewsItems.Add(new NewsItem
            {
                Title = "New Safety Training Available",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi lorem lectus, eleifend id sagittis eu, finibus et diam. Mauris sed ultrices nisl, nec vulputate felis. Fusce lobortis scelerisque urna, et imperdiet orci iaculis non. Duis egestas risus a sodales porta. Nam vel mollis tellus. Suspendisse rutrum semper eros interdum pretium. Phasellus et justo ultrices nunc cursus vehicula. Maecenas lacus nibh, aliquet at faucibus id, aliquet quis magna. Aliquam erat volutpat. In posuere iaculis ligula quis laoreet. Vivamus urna metus, eleifend quis orci ac, pellentesque tristique odio. Nunc egestas enim id erat auctor laoreet. Donec dictum quis lacus faucibus ultrices. Nam eu fermentum sem. In nec velit turpis. Cras tincidunt porta euismod.",
                ImageUrl = "http://www.riverhouseinc.org/wp-content/uploads/safety-first.jpg"
            });

            NewsItems.Add(new NewsItem
            {
                Title = "Hard Crash",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi lorem lectus, eleifend id sagittis eu, finibus et diam. Mauris sed ultrices nisl, nec vulputate felis. Fusce lobortis scelerisque urna, et imperdiet orci iaculis non. Duis egestas risus a sodales porta. Nam vel mollis tellus. Suspendisse rutrum semper eros interdum pretium. Phasellus et justo ultrices nunc cursus vehicula. Maecenas lacus nibh, aliquet at faucibus id, aliquet quis magna. Aliquam erat volutpat. In posuere iaculis ligula quis laoreet. Vivamus urna metus, eleifend quis orci ac, pellentesque tristique odio. Nunc egestas enim id erat auctor laoreet. Donec dictum quis lacus faucibus ultrices. Nam eu fermentum sem. In nec velit turpis. Cras tincidunt porta euismod.",
                ImageUrl = "https://cdn.pixabay.com/photo/2012/04/12/22/25/warning-sign-30915_960_720.png",
                ShouldHardCrash = true
            });

            NewsItems.Add(new NewsItem
            {
                Title = "Handled Error",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi lorem lectus, eleifend id sagittis eu, finibus et diam. Mauris sed ultrices nisl, nec vulputate felis. Fusce lobortis scelerisque urna, et imperdiet orci iaculis non. Duis egestas risus a sodales porta. Nam vel mollis tellus. Suspendisse rutrum semper eros interdum pretium. Phasellus et justo ultrices nunc cursus vehicula. Maecenas lacus nibh, aliquet at faucibus id, aliquet quis magna. Aliquam erat volutpat. In posuere iaculis ligula quis laoreet. Vivamus urna metus, eleifend quis orci ac, pellentesque tristique odio. Nunc egestas enim id erat auctor laoreet. Donec dictum quis lacus faucibus ultrices. Nam eu fermentum sem. In nec velit turpis. Cras tincidunt porta euismod.",
                ImageUrl = "https://www.latimes.com/resizer/zGtb-eVkwjGIqq_lwwX6sKZofgQ=/1400x0/www.trbimg.com/img-5b88987a/turbine/la-1535678581-pqr9uzwair-snap-image",
                ShouldHandledError = true
            });

            BindingContext = this;
        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            NewsItem selectedItem = e.SelectedItem as NewsItem;

            var properties = new Dictionary<string, string> {
                        { "Title", selectedItem.Title },
                        { "ContentBrief", selectedItem.ContentBrief }
                      };

            // APPCENTER
            Analytics.TrackEvent("News Item Selected", properties);
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            NewsItem tappedItem = e.Item as NewsItem;

            if (tappedItem.ShouldHardCrash)
            {
                throw new InvalidOperationException("Hard Crash");
            }

            if (tappedItem.ShouldHandledError)
            {
                try
                {
                    throw new InvalidOperationException("Handled Error");
                }
                catch (InvalidOperationException ex)
                {
                    var properties = new Dictionary<string, string> {
                        { "Title", tappedItem.Title },
                        { "ContentBrief", tappedItem.ContentBrief }
                      };

                    // APPCENTER
                    Crashes.TrackError(ex, properties);
                    return;
                }
            }

            if (tappedItem != null)
                Navigation.PushAsync(new NewsDetailsPage { BindingContext = tappedItem });
        }
    }
}
