using System;
using System.Collections.ObjectModel;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _05_CourseWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel model = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = model;           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan time;
            DateTime newTime = model.Current;

            if ((sender as Button).Content.ToString() == model.Check().ToString())
            {
                //(sender as Button).Background = new SolidColorBrush(Colors.DarkViolet);                        
                model.Current = DateTime.Now;
                if (model.Check().ToString() == "1")
                {
                    time = model.Current - model.Start;
                    model.AddStat(time, model.Check().ToString());
                }
                else
                {
                    time = model.Current - newTime;
                    model.AddStat(time, model.Check().ToString());
                    if ((sender as Button).Content.ToString() == "48")
                    {
                        time = DateTime.Now - model.Start;
                        model.AddStat(time, "All time : ");
                        MessageBox.Show($"Gratz!!!\nYour Time = {time}\nPress Start Test to begin testing again","Winner!!!",MessageBoxButton.OK);
                    }
                }
                model.K++;
                if (model.FindNum != 48)
                    model.FindNum++;
            }    
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            model.K = 0;
            model.FindNum = 1;
            int[] arr1 = model.Mix();
            int i = 0;
            foreach (Button btn in grid.Children.OfType<Button>())
            {
                if (btn.IsEnabled == true)
                {
                    btn.Content = arr1[i];
                    i++;
                }
            }
            model.Start = DateTime.Now;
        }
    }
}