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
        private bool Flag;

        public bool CloseTrigger { get; private set; }

        //Welcome welcome = new Welcome();
        public bool CheckLogin()
        {
            DoctorEntities db = new DoctorEntities();

            string email = textBoxEmail.Text;
            string password = passwordBox1.Password;


            var u = db.User.Where(i => i.Email == email && i.Password == password).SingleOrDefault();

            if (u != null)

            {

                if ((u.Email == email) && (u.Password == password))
                {
                    MessageBox.Show("Welcome " + u.Email + ", you have successfully logged in.");
                    Journal j = new Journal();
                    j.Show();
                    Close();
                    CloseTrigger = true;
                    Flag = true; //This doesn't work as it doesnt set the property Flag to true. Any ideas?

                    return true;
                }

                else
                    MessageBox.Show("enter email and password");
            }



            else
                MessageBox.Show("Unable to Login, you have entered incorrect credentials.");
                return false;

            }


        

      

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

           
        //else
        //{
        //    errormessage.Text = "Sorry! Please enter existing emailid/password.";
        //}


        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }
       

        private void textBoxEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Loginbutton_Click(object sender, RoutedEventArgs e)
        {
            CheckLogin();
            
        }

        //private void textBoxEmail_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //}
    }
}
