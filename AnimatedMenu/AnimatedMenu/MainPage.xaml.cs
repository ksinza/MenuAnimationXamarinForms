using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnimatedMenu
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Menu> MenuItems { get; set; }
        public MainPage()
        {
            InitializeComponent();
            MenuItems = GetMenus();
            this.BindingContext = this;
        }

        private ObservableCollection<Menu> GetMenus()
        {

            return new ObservableCollection<Menu>
            {
                new Menu { Title = "PROFILE", Icon = "profile.png" },
                new Menu { Title = "FEED", Icon = "feed.png" },
                new Menu { Title = "ACTIVITY", Icon = "activity.png" },
                new Menu { Title = "SETTINGS", Icon = "settings.png" },

            };
        }

        private async void Show()
        {
            _ = TitleTxt.FadeTo(0);
            _ = MenuItemsView.FadeTo(1);

            await MainMenuView.RotateTo(0, 300, Easing.BounceOut);
        }

        private async void Hide()
        {
            _ = TitleTxt.FadeTo(1);
            _ = MenuItemsView.FadeTo(0);

            await MainMenuView.RotateTo(-90, 300, Easing.BounceOut);
        }

        void ShowMenu(System.Object sender, System.EventArgs e)
        {
            Show();
        }

        void MenuTapped(System.Object sender, System.EventArgs e)
        {
            TitleTxt.Text = ((sender as StackLayout).BindingContext as Menu).Title;
            Hide();
        }
    }

    public class Menu
    {
        public string Title { get; set; }

        public string Icon { get; set; }
    }
}
