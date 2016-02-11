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
        Registration reegistration = new Registration();
        Welcome welcome = new Welcome();
        private void button1_click(object sender,RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length==0)
            {
                errormessage.Text = "Enter an Email.";
                textBoxEmail.Focus();
            }
            else if(!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
                con.Open();
                SqlCommand cmd=new SqlCommand("Select*from registration where Email='" + email + "'  and password='" + password + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                if (dataset.Tables[0].Rows.Count>0)
                {
                    string username = dataset.Tables[0].Rows[0]
                        ["FirstName"].ToString() + "" + dataset.Tables[0].Rows[0]
                        ["LastName"].ToString();

                }
            }
        }
       















private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
