using Android.Content.Res;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using CodeQuasar.Xamarin.Forms.Controls.Abstractions;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;


namespace CodeQuasar.Xamarin.Forms.Controls.Android
{
    internal class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public RecyclerViewHolder(View itemView) : base(itemView)
        {
            ItemView = itemView;
        }

        public void UpdateUi(ViewCell viewCell, object dataContext, SnappableListView snappableListView)
        {
            var contentLayout = (FrameLayout)ItemView;

            viewCell.BindingContext = dataContext;
            viewCell.Parent = snappableListView;

            var density = Resources.System.DisplayMetrics.Density;
            
            var elementSizeRequest = viewCell.View.Measure(double.PositiveInfinity, double.PositiveInfinity, MeasureFlags.None);

            var width = (int)((snappableListView.ItemWidth + viewCell.View.Margin.Left + viewCell.View.Margin.Right) * density);
            var height = (int)((snappableListView.ItemHeight + viewCell.View.Margin.Top + viewCell.View.Margin.Bottom) * density);


            viewCell.View.Layout(new Rectangle(0, 0, snappableListView.ItemWidth, snappableListView.ItemHeight));
            
            var layoutParams = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
            {
                Height = height,
                Width = width
            };

            if (Platform.GetRenderer(viewCell.View) == null)
            {
                Platform.SetRenderer(viewCell.View, Platform.CreateRenderer(viewCell.View));
            }
            var renderer = Platform.GetRenderer(viewCell.View);

            var viewGroup = renderer.ViewGroup;
            viewGroup.LayoutParameters = layoutParams;
            viewGroup.Layout(0, 0, width, height);

            var viewId = (dataContext as IHaveViewId).ViewId;

            var colors = (new Color[] { Color.Red, Color.Green, Color.Blue }).Select(c => c.ToAndroid()).ToArray();

            contentLayout.SetBackgroundColor(colors[(int)viewId % 3]);

            contentLayout.SetPadding(
                (int)(snappableListView.ItemPadding.Left * density),
                (int)(snappableListView.ItemPadding.Top * density),
                (int)(snappableListView.ItemPadding.Right * density),
                (int)(snappableListView.ItemPadding.Bottom * density));

            contentLayout.RemoveAllViews();
            contentLayout.AddView(viewGroup);
        }
    }
}