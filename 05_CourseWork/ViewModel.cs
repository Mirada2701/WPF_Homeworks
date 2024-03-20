using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace _05_CourseWork
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        public DateTime Start { get; set; }
        public DateTime Current { get; set; }
        private ObservableCollection<Stats> timeToNum;   
        public int K { get; set; }
        public int FindNum { get; set; }
        public int[] Arr { get; set; }
        public ViewModel()
        {
            timeToNum = new ObservableCollection<Stats>();
            Arr = new int[48];          
            for (int i = 0; i < Arr.Length; i++)
            {
                Arr[i] = i + 1;
            }                      
        }
        public void AddStat(TimeSpan time, string num)
        {
            timeToNum.Add(new Stats() {Time = time, Num = num });
        }
        public IEnumerable<Stats> TimeToNum => timeToNum;
        public int[] Mix()
        {
            timeToNum.Clear();
            Random rnd = new Random();
            int[] arr1 = new int[48];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = Arr[i];
            }
            //for (int i = 0; i < 35; i++)
            //{
            //    int index = rnd.Next(0, Arr.Length);
            //    int index1 = rnd.Next(0, Arr.Length);
            //    int temp = arr1[index];
            //    arr1[index] = arr1[index1];
            //    arr1[index1] = temp;
            //}
            return arr1;
        }
        public int Check()
        {
            return Arr[K];
        }
    }
}
