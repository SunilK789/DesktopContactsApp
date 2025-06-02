using DesktopContactsApp.Classes;
using SQLite;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Save Contact
            Contact contact = new Contact()
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
            };
            string databasePath = App.GetDatabasePath();

            InsertRecord(contact, databasePath);

            this.Close();
        }

        

        private static void InsertRecord(Contact contact, string databasePath)
        {
            using SQLiteConnection connection = CrateDBConnection(databasePath);
            connection.CreateTable<Contact>();
            connection.Insert(contact);
        }

        private static SQLiteConnection CrateDBConnection(string databasePath)
        {
            return new SQLiteConnection(databasePath);
        }
    }
}
