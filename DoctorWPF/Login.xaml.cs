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
            else
            {
                DoctorEntities db = new DoctorEntities();
                
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;

                db.User.Find("Zanas");
                User u = new User();
                u.Email = email;
                u.Password = password;
                db.User.Add(u);
                db.SaveChanges();

                //SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
                //con.Open();
                //SqlCommand cmd = new SqlCommand("Select * from Registration where Email='" + email + "'  and password='" + password + "'", con);
                //cmd.CommandType = CommandType.Text;
                //SqlDataAdapter adapter = new SqlDataAdapter();
                //adapter.SelectCommand = cmd;
                //DataSet dataSet = new DataSet();
                //adapter.Fill(dataSet);
                //if (dataSet.Tables[0].Rows.Count > 0)
                //{
                //    string username = dataSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet.Tables[0].Rows[0]["LastName"].ToString();
                //welcome.TextBlockName.Text = username;//Sending value from one form to another form.
                //welcome.Show();
                //Close();
                
            }
        }       
            //else
            //{
            //    errormessage.Text = "Sorry! Please enter existing emailid/password.";
            //}
        

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }
        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            Journal j = new Journal();
            j.Show();
            Close();
        }

        //private void textBoxEmail_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //}
    }
}
