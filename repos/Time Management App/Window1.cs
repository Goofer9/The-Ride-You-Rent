using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private object txt_password;


        public Window1()
        {
            InitializeComponent();

        }




        private void btn_login_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            if ((txt_username.Text == "19007213") && (txt_pwd.Password == "19007213"))
            {
                MessageBox.Show("Login Successful");
                m.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Wrong Credentials");

            }


        }

 
    }
}