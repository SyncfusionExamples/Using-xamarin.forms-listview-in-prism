using Syncfusion.ListView.XForms;
using Syncfusion.SfPullToRefresh.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static ListViewPrism.MainPageViewModel;

namespace ListViewPrism
{
    public class MessageDataTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        #region Properties
        public DataTemplate Template1 { get; set; }
        public DataTemplate Template2 { get; set; }

        #endregion

        #region Constructor
        public MessageDataTemplateSelector()
        {
            Template1 = new DataTemplate(typeof(ViewCell1));
            Template2 = new DataTemplate(typeof(ViewCell2));
        }
        #endregion

        #region OnSelectTemplate
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (((Contacts)item).TemplateType == TemplateType.TemplateOne)
                return Template1;
            else
                return Template2;
        }

        #endregion
    }
}
