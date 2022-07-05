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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private UserRegistration uR1 = new;

        internal UserRegistration GetUR1()
        {
            return uR1;
        }

        internal void SetUR1(UserRegistration value)
        {
            uR1 = value;
        }
    }

    internal class UserRegistration
    {
    }
}
