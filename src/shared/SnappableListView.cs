using CodeQuasar.Xamarin.Forms.Controls.Abstractions;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CodeQuasar.Xamarin.Forms.Controls
{
    public class SnappableListView : View
    {
        public event EventHandler<ScrollToEventArgs> ScrolledTo;

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<IListViewItem>), typeof(SnappableListView), null);

        public IEnumerable<IListViewItem> ItemsSource
        {
            get { return (IEnumerable<IListViewItem>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(SnappableListView), null);

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly BindableProperty ItemHeightProperty = BindableProperty.Create(nameof(ItemHeight), typeof(double), typeof(SnappableListView), default(double));

        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set {  SetValue(ItemHeightProperty, value); }
        }

        public static readonly BindableProperty ItemWidthProperty = BindableProperty.Create(nameof(ItemWidth), typeof(double), typeof(SnappableListView), default(double));

        public double ItemWidth
        {
            get { return (double)GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }

        public static readonly BindableProperty ItemPaddingProperty = BindableProperty.Create(nameof(ItemPadding), typeof(Thickness), typeof(SnappableListView), default(Thickness));

        public Thickness ItemPadding
        {
            get { return (Thickness)GetValue(ItemPaddingProperty); }
            set { SetValue(ItemPaddingProperty, value); }
        }

        public static readonly BindableProperty SnapModeProperty = BindableProperty.Create(nameof(SnapMode), typeof(SnapMode), typeof(SnappableListView), SnapMode.None);

        public SnapMode SnapMode
        {
            get { return (SnapMode)GetValue(SnapModeProperty); }
            set { SetValue(SnapModeProperty, value); }
        }

        public void ScrollTo(int x, int y)
        {
            ScrolledTo?.Invoke(new ScrollToEventArgs() { X = x, Y = y });
        }
    }
}
