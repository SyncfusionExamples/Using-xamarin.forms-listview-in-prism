using Syncfusion.ListView.XForms;
using Syncfusion.SfPullToRefresh.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewPrism
{
   public class ContentPageBehavior : Behavior<ContentPage>
    {
        SfPullToRefresh PullToRefresh;SfListView ListView;
        MainPageViewModel BC;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            PullToRefresh = bindable.FindByName<SfPullToRefresh>("pullToRefresh");
            ListView = bindable.FindByName<SfListView>("listView");
            BC = new MainPageViewModel(ListView);
            ListView.BindingContext = BC;
            PullToRefresh.Refreshing += PullToRefresh_Refreshing;

            base.OnAttachedTo(bindable);
        }

        private async void PullToRefresh_Refreshing(object sender, EventArgs e)
        {
            PullToRefresh.IsRefreshing = true;
            await Task.Delay(1000);
            BC.GenerateItems(5);

            PullToRefresh.IsRefreshing = false;
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {

            base.OnDetachingFrom(bindable);
        }
    }
}
