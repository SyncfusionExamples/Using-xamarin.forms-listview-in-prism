using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using Syncfusion.SfPullToRefresh.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewPrism
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Fields

        public enum TemplateType
        {
            TemplateOne,
            TemplateTwo,
        }
        #endregion

        #region Properties

        public ObservableCollection<Contacts> ContactsInfo { get; set; }
        public Command<object> LoadMoreItemsCommand { get; set; }
        public Command<object> SwipeEndedCommand
        {
            get { return swipeCommand; }
            protected set { swipeCommand = value; }
        }
        public Command<object> SwipeRightCommand { get; set; }
        public object NavigationParameter { get; private set; }
        public SfListView ListView { get; set; }

        #endregion

        #region Constructor

        public MainPageViewModel(SfListView List)
        {
            ListView = List;
            ContactsInfo = new ObservableCollection<Contacts>();
            LoadMoreItemsCommand = new Command<object>(LoadMoreItems, CanLoadMoreItems);
            SwipeEndedCommand = new Command<object>(OnSwipeEnded);
            SwipeRightCommand = new Command<object>(OnSwipeRight);
            GenerateItems(5);

        }

        private bool CanLoadMoreItems(object arg)
        {
            if (ContactsInfo.Count >= totalItems)
                return false;
            return true;
        }

        private async void LoadMoreItems(object obj)
        {
            var listView = obj as Syncfusion.ListView.XForms.SfListView;
            listView.IsBusy = true;
            await Task.Delay(2500);
            var index = ContactsInfo.Count;
            var count = index + 3 >= totalItems ? totalItems - index : 3;
            AddProducts(index, count);
            listView.IsBusy = false;
        }

        private void AddProducts(int index, int count)
        {
            Random r = new Random();
            Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;
            for (int i = index; i < index + count; i++)
            {
                if(i%2==0)
                {
                    var contact = new Contacts(CustomerNames[r.Next(1,120)], r.Next(720, 799).ToString() + " - " + r.Next(3010, 3999).ToString());
                    contact.ContactImage = ImageSource.FromResource("ListViewPrism.Images.Image" + r.Next(0, 28) + ".png", assembly);
                    contact.ContactColor = Color.FromRgb(r.Next(40, 255), r.Next(40, 255), r.Next(40, 255));
                    contact.TemplateType = TemplateType.TemplateOne;
                    ContactsInfo.Add(contact);
                }
                 else
                {
                    var contact = new Contacts(CustomerNames[r.Next(1, 120)], r.Next(720, 799).ToString() + " - " + r.Next(3010, 3999).ToString());
                    contact.ContactImage = ImageSource.FromResource("ListViewPrism.Images.Image" + r.Next(0, 28) + ".png", assembly);
                    contact.ContactColor = Color.FromRgb(r.Next(40, 255), r.Next(40, 255), r.Next(40, 255));
                    contact.TemplateType = TemplateType.TemplateTwo;
                    ContactsInfo.Add(contact);
                }
            }
        }

        public void GenerateItems(int n)
        {

            Random r = new Random();
            Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;

            for (int i=0;i<n;i++)
            {
                if (i % 2 == 0)
                {
                    var contact = new Contacts(CustomerNames[r.Next(1, 120)], r.Next(720, 799).ToString() + " - " + r.Next(3010, 3999).ToString());
                    contact.ContactImage = ImageSource.FromResource("ListViewPrism.Images.Image" + r.Next(0, 28) + ".png", assembly);
                    contact.ContactColor = Color.FromRgb(r.Next(40, 255), r.Next(40, 255), r.Next(40, 255));
                    contact.TemplateType = TemplateType.TemplateOne;
                    ContactsInfo.Add(contact);
                }
                else
                {
                    var contact = new Contacts(CustomerNames[r.Next(1, 120)], r.Next(720, 799).ToString() + " - " + r.Next(3010, 3999).ToString());
                    contact.ContactImage = ImageSource.FromResource("ListViewPrism.Images.Image" + r.Next(0, 28) + ".png", assembly);
                    contact.ContactColor = Color.FromRgb(r.Next(40, 255), r.Next(40, 255), r.Next(40, 255));
                    contact.TemplateType = TemplateType.TemplateTwo;
                    ContactsInfo.Add(contact);
                }
            }
        }
        private void OnSwipeEnded(object obj)
        {
            var swipeArgs = obj as SwipeEndedEventArgs;
            var contact=swipeArgs.ItemData as Contacts;
            App.Current.MainPage.DisplayAlert("Message", "Swiped item :" + contact.ContactName, "Ok");
        }

        private void OnSwipeRight(object obj)
        {
            var swipedItem = obj as Contacts;
            this.ContactsInfo.Remove(swipedItem);
            App.Current.MainPage.DisplayAlert("Message","Item deleted in right swipe : " +swipedItem.ContactName ,"Ok");
        }

        #endregion

        #region Fields

        string[] CustomerNames = new string[] {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Jennifer",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Zeke",
            "Aiden",
            "Jackson"    ,
            "Mason  "    ,
            "Liam   "    ,
            "Jacob  "    ,
            "Jayden "    ,
            "Ethan  "    ,
            "Noah   "    ,
            "Lucas  "    ,
            "Logan  "    ,
            "Caleb  "    ,
            "Caden  "    ,
            "Jack   "    ,
            "Ryan   "    ,
            "Connor "    ,
            "Michael"    ,
            "Elijah "    ,
            "Brayden"    ,
            "Benjamin"   ,
            "Nicholas"   ,
            "Alexander"  ,
            "William"    ,
            "Matthew"    ,
            "James  "    ,
            "Landon "    ,
            "Nathan "    ,
            "Dylan  "    ,
            "Evan   "    ,
            "Luke   "    ,
            "Andrew "    ,
            "Gabriel"    ,
            "Gavin  "    ,
            "Joshua "    ,
            "Owen   "    ,
            "Daniel "    ,
            "Carter "    ,
            "Tyler  "    ,
            "Cameron"    ,
            "Christian"  ,
            "Wyatt  "    ,
            "Henry  "    ,
            "Eli    "    ,
            "Joseph "    ,
            "Max    "    ,
            "Isaac  "    ,
            "Samuel "    ,
            "Anthony"    ,
            "Grayson"    ,
            "Zachary"    ,
            "David  "    ,
            "Christopher",
            "John   "    ,
            "Isaiah "    ,
            "Levi   "    ,
            "Jonathan"   ,
            "Oliver "    ,
            "Chase  "    ,
            "Cooper "    ,
            "Tristan"    ,
            "Colton "    ,
            "Austin "    ,
            "Colin  "    ,
            "Charlie"    ,
            "Dominic"    ,
            "Parker "    ,
            "Hunter "    ,
            "Thomas "    ,
            "Alex   "    ,
            "Ian    "    ,
            "Jordan "    ,
            "Cole   "    ,
            "Julian "    ,
            "Aaron  "    ,
            "Carson "    ,
            "Miles  "    ,
            "Blake  "    ,
            "Brody  "    ,
            "Adam   "    ,
            "Sebastian"  ,
            "Adrian "    ,
            "Nolan  "    ,
            "Sean   "    ,
            "Riley  "    ,
            "Bentley"    ,
            "Xavier "    ,
            "Hayden "    ,
            "Jeremiah"   ,
            "Jason  "    ,
            "Jake   "    ,
            "Asher  "    ,
            "Micah  "    ,
            "Jace   "    ,
            "Brandon"    ,
            "Josiah "    ,
            "Hudson "    ,
            "Nathaniel"  ,
            "Bryson "    ,
            "Ryder  "    ,
            "Justin "    ,
            "Bryce  "    ,
        };
        private Command<object> swipeCommand;
        private int totalItems=100;

        #endregion

        #region Prism Methods

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            
        }

        #endregion
    }
}
