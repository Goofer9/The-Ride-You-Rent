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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTimeApp.Modules
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : window
    {
        public MainWindow()
        {
            InitializeComponent();
            
         
        }

        private void Submit_Click(object sender, RoutedEventArgs e)

        {
            if (string.IsNullOrEmpty(Code.Text) || string.IsNullOrEmpty(Module Name.Text) || string.IsNullOrEmpty(Number of Credits.Text) || string.IsNullOrEmpty(Hours.Text))
            {
                MessageBox.Show("filll in all the texboxes");
            }
            else
            {


                module.Add(new Modules() { code = Code.Text, name = Name.Text, credits = Convert.ToInt32(Credits.Text), classHours = Convert.ToDouble(Hours.Text), selfStudy = g.Calculation(Convert.ToInt32(Credits.Text), Page.h, Convert.ToDouble(Hours.Text)) });
                ModuleList.ItemsSource = modeule;
                ModuleList.Items.Refresh();
            }

            clearTextBox();
        }




        private void clearTextBox()
        {

            Code.Text = String.Empty;
            Name.Text = String.Empty;
            Credits.Text = String.Empty;
            Hours.Text = String.Empty;
        }

        public void calcate()
        {

            ModuleList.Items.Refresh();
            // clearTextBox();

        }

        private void Hours_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Name.Clear();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Modules.startDate = DateTime.Parse(DatePicked.Text);
            g.studyhours = Convert.ToInt32(Userhours.Text);


            double remaininghours = g.Calculation(Convert.ToInt32(Credits.Text), Page2.h, Convert.ToDouble(Hours.Text)) - Convert.ToInt32(Userhours.Text);

            var moduleEnum = from m in modeule
                             where m.name == ModuleName.Text
                             select m;

            foreach (var mod in moduleEnum)
            {


                if (mod.name == ModuleName.Text)
                {
                    MessageBox.Show("The module name: " + ModuleName.Text + " \n" + "Date studied: " + Modules.dateStudied.Date.ToString("yyyy-MM-dd") + "\n" + "Hours remaining: " + remaininghours.ToString());

                }
                else if (mod.name != ModuleName.Text)
                {
                    MessageBox.Show("Your module does not exist");
                }

            }





            //Module.Select(m.)


            //if (modeule.)
            //{
            //    MessageBox.Show("It works");
            //}
            //else
            //{

            //    MessageBox.Show(Module.ToString())
            //}

            //foreach (Modules t in modeule)
            //{

            //}


            //ModuleName =
            // DateTime f = Modules.dateStudied;
            //int weeks = Convert.ToInt32((Modules.dateStudied - g.semsterEnd).TotalDays / 7);

            //for (int i; i <; i++)
            //{


            //}



            //if (Modules.dateStudied < g.semster)
            //{
            //    MessageBox.Show("Type again");
            //}

            //Modules.dateStudied = DateTime.Parse(DatePicked.Text);



            //MessageBox.Show(Modules.dateStudied.ToString(), "Amount of tine of self study left");



        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private class module
        {
            internal static void Add(Modules modules)
            {
                throw new NotImplementedException();
            }
        }
    }



}
}
