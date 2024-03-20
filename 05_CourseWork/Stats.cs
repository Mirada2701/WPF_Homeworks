using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_CourseWork
{
    [AddINotifyPropertyChangedInterface]
    public class Stats
    {
        public TimeSpan Time { get; set; }
        public string Num { get; set; }
        public string FullInfo => "#" + Num + "\t " + Time.TotalSeconds + " sec";

    }
}
