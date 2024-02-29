using System.Data;
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

namespace _01_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            topTextBox.IsReadOnly = true;
            underTopTextBox.IsReadOnly = true;
            zeroBtn.IsEnabled = false;
            underTopTextBox.TextChanged += UnderTopTextBox_TextChanged;
        }

        private void UnderTopTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(underTopTextBox.Text.Length > 0) { zeroBtn.IsEnabled = true; }            
        }

        private void CEBtn_Click(object sender, RoutedEventArgs e)
        {
            underTopTextBox.Clear();
        }
        private void CBtn_Click(object sender, RoutedEventArgs e)
        {
            topTextBox.Clear();
            underTopTextBox.Clear();
        }
        private void DellBtn_Click(object sender, RoutedEventArgs e)
        {
            underTopTextBox.Undo();
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {            
            underTopTextBox.Text += (sender as Button).Content;
        }
        private void EqualBtn_Click(object sender, RoutedEventArgs e)
        {
           topTextBox.Text = underTopTextBox.Text;
           underTopTextBox.Text= new DataTable().Compute(underTopTextBox.Text, null).ToString();           
        }
    }
    //public class Calculator
    //{
    //    public double Num { get; set; }       
    //    public Calculator()
    //    {
    //        Num = 0;
    //    }
    //    public Calculator(double first)
    //    {
    //        Num = first;          
    //    }
    //    //private double Calc(char operation)
    //    //{
    //    //    double res = 0;
    //    //    if (operation == '+')
    //    //        res = FirstNum + SecondNum;
    //    //    if(operation == '-')
    //    //        res = FirstNum - SecondNum;
    //    //    if(operation == '*')
    //    //        res = FirstNum * SecondNum;
    //    //    if(operation == '/' && SecondNum != 0)
    //    //        res = FirstNum / SecondNum;
    //    //    return res;
    //    //}
    //}
}