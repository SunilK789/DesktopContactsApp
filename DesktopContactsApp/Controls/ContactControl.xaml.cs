using DesktopContactsApp.Classes;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        private Contact contact;


        public Contact ContactDependencyProperty
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContactDependencyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl contactControl = (ContactControl)d;
            var contact = e.NewValue as Contact;
            if (contactControl != null && contact != null)
            {
                contactControl.nameTextBlock.Text = contact.Name;
                contactControl.emailTextBlock.Text = contact.Email;
                contactControl.phoneTextBlock.Text = contact.Phone;
            }
        }

        public Contact Contact
        {
            get { return contact; }
            set
            {
                contact = value;
                nameTextBlock.Text = contact.Name;
                emailTextBlock.Text = contact.Email;
                phoneTextBlock.Text = contact.Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
