using CodeQuasar.Xamarin.Forms.Controls.Abstractions;
using Xamarin.Forms;

namespace CodeQuasar.Xamarin.Forms.Controls.Demo
{
    public class ImageModel : IListViewItem
    {
        public string Source { get; set; }

        public int? ViewId { get; set; }

        public Color Color
        {
            get
            {
                var colors = new Color[] { Color.Blue, Color.Red, Color.Green };
                return colors[((int)ViewId % 3)];
            }
        }
    }
}
