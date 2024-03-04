using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _03_ShulteTable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        int[] arr = new int[16];
        int k = 0;
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Tick += Timer_Tick;            
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (progressBar.Value == progressBar.Maximum)
            {
                timer.Stop();
                MessageBox.Show("Time is out!!!! You lose");
            }
            else
            {
                progressBar.Value++;
                label.Content = "Time : " + progressBar.Value.ToString() + " sec";
            }
                
        }

        private int[] Mix()
        {
            Random rnd = new Random();
            int[] arr1 = new int[16];
            for(int i = 0;i < arr1.Length;i++)
            {
                arr1[i] = arr[i];
            }
            for (int i = 0; i < 10; i++)
            {
                int index = rnd.Next(0,arr.Length);
                int index1 = rnd.Next(0,arr.Length);
                int temp = arr1[index];
                arr1[index] = arr1[index1];
                arr1[index1]= temp;                
            }
            return arr1;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            progressBar.Value = progressBar.Minimum;
            foreach (Button btn in grid.Children.OfType<Button>())
            {
                btn.Background = new SolidColorBrush(Colors.White);
            }
            progressBar.Maximum = slider.Value;
            int[] arr1 = Mix();
            int i = 0;
            foreach(Button btn in grid.Children.OfType<Button>())
            {
                btn.Content = arr1[i];
                i++;
            }
            timer.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {           
            if((sender as Button).Content.ToString() != arr[k].ToString())
            {
                k = 0;
                timer.Stop();
                (sender as Button).Background = new SolidColorBrush(Colors.Red);               
                MessageBox.Show("You lose!!!! Wrong number");
            }
            else if((sender as Button).Content.ToString() == "16")
            {
                k = 0;
                timer.Stop();
                (sender as Button).Background = new SolidColorBrush(Colors.Green);
                MessageBox.Show($"   You won!\n{label.Content}","Finish!",MessageBoxButton.OK);
            }
            else
            {
                (sender as Button).Background = new SolidColorBrush(Colors.Green);
                k++;
            }

        }
    }
}