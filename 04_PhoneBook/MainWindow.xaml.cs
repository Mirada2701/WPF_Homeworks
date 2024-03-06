using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace _04_PhoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Abonent> abonents;
        public MainWindow()
        {
            InitializeComponent();
            comboBox.Items.Add("Ukraine");
            comboBox.Items.Add("Poland");
            comboBox.Items.Add("UK");
            comboBox.Items.Add("Usa");
            comboBox.Items.Add("Germany");
            comboBox.Items.Add("France");
            list.Items.Clear();
            abonents = new ObservableCollection<Abonent>();
            list.ItemsSource = abonents;
            list.DisplayMemberPath = nameof(Abonent.FullInfo);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Abonent ab = new Abonent();
            ab.Name = nameTb.Text;
            ab.Surname = surnameTb.Text;
            ab.Phone = phoneTb.Text;           
            abonents.Add(ab);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (list.SelectedIndex != -1)
                abonents.RemoveAt(list.SelectedIndex);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                Abonent ab = (list.SelectedItem as Abonent)!;
                ab.Name = nameTb.Text;
                ab.Surname = surnameTb.Text;
                ab.Phone = phoneTb.Text;
            }
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                Abonent ab = (list.SelectedItem as Abonent)!;
                nameTb.Text = ab.Name;
                surnameTb.Text = ab.Surname;
                phoneTb.Text = ab.Phone;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string filename = "Abonents.json";
            string jsonString = JsonSerializer.Serialize(abonents);
            File.WriteAllText(filename, jsonString);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string filename = "Abonents.json";
            string jsonString = File.ReadAllText(filename);
            abonents.Clear();
            abonents = JsonSerializer.Deserialize<ObservableCollection<Abonent>>(jsonString);
            list.ItemsSource = abonents;
        }
    }
}