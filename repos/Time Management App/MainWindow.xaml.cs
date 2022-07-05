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

namespace Time_Management_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        static List<Modules> module = new List<Modules>();
        Modules g = new Modules();

        public object Module_Name { get; private set; }
        public object Mods { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                if (string.IsNullOrEmpty(Module_Name.Text)  string.IsNullOrEmpty(Module_Code.Text)  string.IsNullOrEmpty(NumofCredits.Text) || string.IsNullOrEmpty(Class_hours.Text))
                {
                    MessageBox.Show("filll in all the texboxes");
                  else
                    {

                        //  g.Modcode = Module_Code.Text;
                        //   g.name = Module_Name.Text;

                        // g.credits = Convert.ToInt32(NumofCredits.Text);

                        //  g.studyHours = Convert.ToInt32(Class_hours.Text);

                        //g.selfStudy= g.Calculation(Convert.ToInt32(NumofCredits.Text), Convert.ToInt32(Semester_Length.Text), Convert.ToInt32(Class_hours.Text));

                        module.Add(new Modules()
                        {
                            Modcode = g.Modcode,
                            name = g.name,
                            //  credits=g.credits,
                            //  studyHours=g.studyHours,
                            //   selfStudy = g.selfStudy });
                        });
                        Mods.ItemsSource = module;
                        Mods.Items.Refresh();
                   }
                    
                }
            }

        }

    }

    internal class Class_hours
    {
        public static string Text { get; internal set; }
    }

    internal class NumofCredits
    {
        public static string Text { get; internal set; }
    }

    internal class Module_Code
    {
        public static string Text { get; internal set; }
    }

        internal class Modules
        {
            internal object name;

            public object Modcode { get; internal set; }
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {

    }

    //private void Button_Click(object sender, RoutedEventArgs e)
    //{
    //    if (string.IsNullOrEmpty(startDate.Text) || string.IsNullOrEmpty(weeksSemester.Text))
    //    {
    //        MessageBox.Show("Please fill the textbox");

    //    }
    //    else
    //    {


    //        h = Convert.ToInt32(weeksSemester.Text);

    //        g.semster = Convert.ToDateTime(startDate.Text);


    //        this.NavigationService.Navigate(new Uri("Page1.xaml", UriKind.Relative));
    //    }

    //}


}