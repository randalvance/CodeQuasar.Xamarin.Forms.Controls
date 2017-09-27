using Android.Content.Res;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using CodeQuasar.Xamarin.Forms.Controls.Abstractions;
using System.Collections;
using Xamarin.Forms;
using View = Android.Views.View;

namespace CodeQuasar.Xamarin.Forms.Controls.Android
{
    internal class RecyclerViewAdapter : RecyclerView.Adapter, View.IOnClickListener
    {
        public const int ItemType = 1;
        public const int HeaderType = 2;

        private readonly SnappableListView _snappableListView;
        private readonly IList _dataSource;

        public RecyclerViewAdapter(SnappableListView snappableListView, IList dataSource)
        {
            _snappableListView = snappableListView;
            _dataSource = dataSource;
        }

        public void Swap(IEnumerable dataSource)
        {
            _dataSource.Clear();
            foreach (var item in dataSource)
            {
                _dataSource.Add(item);
            }
            NotifyDataSetChanged();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return CreateItemViewHolder(parent);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = (RecyclerViewHolder)holder;
            item.ItemView.SetOnClickListener(this);
            UpdateItemView(item, position);
        }

        public override int ItemCount => _dataSource.Count;

        public override long GetItemId(int position)
        {
            var item = _dataSource[position];
            var hasId = item as IHaveViewId;
            if (item != null && hasId?.ViewId != null)
            {
                return hasId.ViewId.Value;
            }

            return 0;
        }

        public void OnClick(View v)
        {
        }

        private RecyclerViewHolder CreateItemViewHolder(ViewGroup parent)
        {
            var density = Resources.System.DisplayMetrics.Density;

            var contentFrame = new FrameLayout(parent.Context);
            contentFrame.DescendantFocusability = DescendantFocusability.AfterDescendants;
            var viewHolder = new RecyclerViewHolder(contentFrame);
            return viewHolder;
        }

        private void UpdateItemView(RecyclerViewHolder viewHolder, int position)
        {
            var dataContext = _dataSource[position];
            if (dataContext != null)
            {
                var dataTemplate = _snappableListView.ItemTemplate;
                var viewCell = dataTemplate.CreateContent() as ViewCell;

                viewHolder.UpdateUi(viewCell, dataContext, _snappableListView);
            }
        }
    }
}