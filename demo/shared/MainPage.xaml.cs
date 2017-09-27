using Xamarin.Forms;

namespace CodeQuasar.Xamarin.Forms.Controls.Demo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            snappableListView.ItemsSource = new ImageModel[] 
            {
                new ImageModel() { ViewId = 1, Source = "arc_de_triomphe.jpg" },
                new ImageModel() { ViewId = 2, Source = "before_mobile_phones.jpg" },
                new ImageModel() { ViewId = 3, Source = "big_ben_1.jpg" },
                new ImageModel() { ViewId = 4, Source = "big_ben_2.jpg" },
                new ImageModel() { ViewId = 5, Source = "champ_elysees.jpg" },
                new ImageModel() { ViewId = 6, Source = "downtown_edinburgh.jpg" },
                new ImageModel() { ViewId = 7, Source = "edinburgh_castle_1.jpg" },
                new ImageModel() { ViewId = 8, Source = "edinburgh_castle_2.jpg" },
                new ImageModel() { ViewId = 9, Source = "edinburgh_from_on_high.jpg" },
                new ImageModel() { ViewId = 10, Source = "edinburgh_station.jpg" },
                new ImageModel() { ViewId = 11, Source = "eurostar.jpg" },
                new ImageModel() { ViewId = 12, Source = "heres_lookin_at_ya.jpg" },
                new ImageModel() { ViewId = 13, Source = "inside_notre_dame.jpg" },
                new ImageModel() { ViewId = 14, Source = "la_tour_eiffel.jpg" },
                new ImageModel() { ViewId = 15, Source = "london_eye.jpg" },
                new ImageModel() { ViewId = 16, Source = "louvre_1.jpg" },
                new ImageModel() { ViewId = 17, Source = "louvre_2.jpg" },
                new ImageModel() { ViewId = 18, Source = "medieval_siege_gun.jpg" },
                new ImageModel() { ViewId = 19, Source = "modest_accomodations.jpg" },
                new ImageModel() { ViewId = 20, Source = "museum_and_castle.jpg" },
                new ImageModel() { ViewId = 21, Source = "notre_dame.jpg" },
                new ImageModel() { ViewId = 22, Source = "old_meets_new.jpg" },
                new ImageModel() { ViewId = 23, Source = "one_o_clock_gun.jpg" },
                new ImageModel() { ViewId = 24, Source = "pompidou_centre.jpg" },
                new ImageModel() { ViewId = 25, Source = "portcullis_gate.jpg" },
                new ImageModel() { ViewId = 26, Source = "royal_mile.jpg" },
                new ImageModel() { ViewId = 27, Source = "rue_cler.jpg" },
                new ImageModel() { ViewId = 28, Source = "scott_monument.jpg" },
                new ImageModel() { ViewId = 29, Source = "seine_barge.jpg" },
                new ImageModel() { ViewId = 30, Source = "seine_river.jpg" },
                new ImageModel() { ViewId = 31, Source = "to_notre_dame.jpg" },
                new ImageModel() { ViewId = 32, Source = "tower_of_london.jpg" },
                new ImageModel() { ViewId = 33, Source = "tower_visitors.jpg" },
                new ImageModel() { ViewId = 34, Source = "versailles_fountains.jpg" },
                new ImageModel() { ViewId = 35, Source = "versailles_gates.jpg" },
                new ImageModel() { ViewId = 36, Source = "victoria_albert.jpg" },
                new ImageModel() { ViewId = 37, Source = "view_from_holyrood_park.jpg" }
            };
        }
    }
}
