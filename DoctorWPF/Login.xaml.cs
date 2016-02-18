using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace DoctorWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        Registration registration = new Registration();
        //Welcome welcome = new Welcome();

        private void Loginbutton_Click(object sender, RoutedEventArgs e)
        {
            string regex = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";

            if (textBoxEmail.Text.Length == 0)

            {
                emailerrormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, regex))
            {
                emailerrormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            if (passwordBox1.Password.Length == 0)
            {
                passworderrormessage.Text = "Enter an Password.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, regex))
            {
                passworderrormessage.Text = "Enter a valid Password.";
                textBoxEmail.Select(0, passwordBox1.Password.Length);
                textBoxEmail.Focus();
            }
            else if(Regex.IsMatch(textBoxEmail.Text, regex) && Regex.IsMatch(textBoxEmail.Text, regex))
            {
                DoctorEntities1 db = new DoctorEntities1();
                
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;

                //var user = db.User.Any(u => u.Email == textBoxEmail.Text);
                if (db.Users.Any(u => u.Email == textBoxEmail.Text))
                {
                    Journal j = new Journal();
                    j.Show();
                }
                else   
                {
                    errormessage.Text = "Sorry! Please enter existing emailid/password.";
                    Registration registration = new Registration();
                    registration.Show();
                    this.Close();
                    //jnjm
                }
            }
        }       

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }
    }
}
