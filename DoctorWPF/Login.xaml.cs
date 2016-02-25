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

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }

        private void Loginbutton_Click(object sender, RoutedEventArgs e)
            {

            Client c = new Client();
            if (c.CheckOnRegister(textBoxEmail.Text))
                {
                //MessageBox.Show("welcome");
                    Journal j = new Journal();
                    j.Show();
                this.Close();
            }
            else
            {
                errormessage.Text = "Email is not found.To Register please Click on Register Button.";

            }

                }

        private void textBoxEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
            }



//Welcome welcome = new Welcome();
//public bool CheckLogin()
//{

//    string email = textBoxEmail.Text;
//    string password = passwordBox1.Password;


//    var u = db.User.Where(i => i.Email == email && i.Password == password).FirstOrDefault();

//    if (u != null)

//    {

//        if ((u.Email == email) && (u.Password == password))
//        {
//            MessageBox.Show("Welcome " + u.Email + ", you have successfully logged in.");
//            Journal j = new Journal();
//            j.Show();
//            Close();

//            This doesn't work as it doesnt set the property Flag to true. Any ideas?

//            return true;
//        }

//        else
//            MessageBox.Show("enter email and password");
//    }



//    else
//        MessageBox.Show("Unable to Login, you have entered incorrect credentials.");
//    return false;

//}
