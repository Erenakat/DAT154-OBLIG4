using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApp{

    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(NavigationViewItemBase item in NavView_MenuItems)
            {
                if(item is NavigationViewItemBase && item.Tag.ToString() == "home")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }
        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if(args.IsSettingInvoked)
            {
                ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
               var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
               NavView_Navigate(item as NavigationViewItem);
            }
        }

                private void NavView_Navigate(NavigationViewItem item)
                {
                    switch (item.Tag)
                    {
                        case "home":
                            ContentFrame.Navigate(typeof(MainPage));
                            break;
                        case "rooms":
                            ContentFrame.Navigate(typeof(RoomsPage));
                            break;
                        case "bookings":
                            ContentFrame.Navigate(typeof(BookingsPage));
                            break;
                        case "customers":
                            ContentFrame.Navigate(typeof(CustomersPage));
                            break;
                    }

                }
    }
}