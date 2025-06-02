using DesktopContactsApp.Classes;
using SQLite;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        private void btnNewContact_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabase();
        }

        void ReadDatabase()
        {
            using SQLiteConnection connection = new SQLiteConnection(App.GetDatabasePath());
            connection.CreateTable<Contact>();
            var contacts = connection.Table<Contact>().ToList();

            if (contacts != null)
            {
                //foreach (var contact in contacts)
                //{
                //    contactListView.Items.Add(new ListViewItem()
                //    {
                //        Content = contact,
                //    });
                //}
                contactListView.ItemsSource = contacts;
            }
        }
    }
}