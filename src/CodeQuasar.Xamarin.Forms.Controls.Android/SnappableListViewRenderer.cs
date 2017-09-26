using Android.Support.V7.Widget;
using CodeQuasar.Xamarin.Forms.Controls;
using CodeQuasar.Xamarin.Forms.Controls.Android;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SnappableListView), typeof(SnappableListViewRenderer))]
namespace CodeQuasar.Xamarin.Forms.Controls.Android
{
    public class SnappableListViewRenderer : ViewRenderer<SnappableListView, RecyclerView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SnappableListView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
            }

            if (e.OldElement != null)
            {
                var itemsSource = e.OldElement.ItemsSource as INotifyCollectionChanged;
                if (itemsSource != null)
                {
                    itemsSource.CollectionChanged -= ItemsSourceOnCollectionChanged;
                }
            }

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var recyclerView = new RecyclerView(Context);

                    SetNativeControl(recyclerView);
                    var linearLayout = new LinearLayoutManager(Context, OrientationHelper.Horizontal, false);
                    
                    recyclerView.SetClipToPadding(true);
                    recyclerView.SetLayoutManager(linearLayout);

                    var linearSnapHelper = new LinearSnapHelper();
                    
                    linearSnapHelper.AttachToRecyclerView(recyclerView);

                    UpdateAdapter();
                }

                var itemsSource = e.NewElement.ItemsSource as INotifyCollectionChanged;
                if (itemsSource != null)
                {
                    itemsSource.CollectionChanged += ItemsSourceOnCollectionChanged;
                }

                Control.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                Control.HasFixedSize = true;

                var density = Resources.DisplayMetrics.Density;

                Control.SetClipToPadding(false);
                Control.SetPadding(
                    (int)(Element.ItemPadding.Left * density),
                    (int)(Element.ItemPadding.Top * density),
                    (int)(Element.ItemPadding.Right * density),
                    (int)(Element.ItemPadding.Bottom * density));
            }
        }

        private void ItemsSourceOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var adapter = Control.GetAdapter();
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    RefreshAdapter();
                    adapter.NotifyItemRangeInserted(
                        positionStart: e.NewStartingIndex,
                        itemCount: e.NewItems.Count
                    );
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if ((Element.ItemsSource as IList).Count == 0)
                    {
                        RefreshAdapter();
                        adapter.NotifyDataSetChanged();
                        return;
                    }

                    RefreshAdapter();
                    adapter.NotifyItemRangeRemoved(
                        positionStart: e.OldStartingIndex,
                        itemCount: e.OldItems.Count
                    );
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RefreshAdapter();
                    adapter.NotifyItemRangeChanged(
                        positionStart: e.OldStartingIndex,
                        itemCount: e.OldItems.Count
                    );
                    break;
                case NotifyCollectionChangedAction.Move:
                    RefreshAdapter();
                    for (var i = 0; i < e.NewItems.Count; i++)
                        adapter.NotifyItemMoved(
                            fromPosition: e.OldStartingIndex + i,
                            toPosition: e.NewStartingIndex + i
                        );
                    break;
                case NotifyCollectionChangedAction.Reset:
                    RefreshAdapter();
                    adapter.NotifyDataSetChanged();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RefreshAdapter()
        {
            var sourceList = new List<object>();
            var dataSource = Element.ItemsSource.Cast<object>().ToList();
            sourceList.AddRange(dataSource);

            var newAdapter = new RecyclerViewAdapter(Element, sourceList);
            Control.SwapAdapter(newAdapter, false);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Element.ItemsSource))
            {
                UpdateAdapter();
            }
        }

        private void UpdateAdapter()
        {
            var dataSource = Element.ItemsSource.Cast<object>().ToList();
            var adapter = new RecyclerViewAdapter(Element, dataSource) { HasStableIds = true };

            Control.SetAdapter(adapter);
        }
    }
}