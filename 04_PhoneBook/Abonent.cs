using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace _04_PhoneBook
{
    class Abonent : INotifyPropertyChanged
    {
		private string name;

		public string Name
		{
			get { return name; }
			set 
			{ 
				name = value;
				CheckPropChange();
				CheckPropChange(nameof(FullInfo));
            }
		}
		private string surname;

		public string Surname
		{
			get { return surname; }
			set 
			{ 
				surname = value; 
				CheckPropChange();
                CheckPropChange(nameof(FullInfo));
            }
		}

        public event PropertyChangedEventHandler? PropertyChanged;

		public void CheckPropChange([CallerMemberName]string propName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
		}        

        private string phone;
        public string Phone
		{
			get { return phone; }
			set 
			{ 
				phone = value; 
				CheckPropChange();
                CheckPropChange(nameof(FullInfo));
            }
		}
		public string FullInfo => Name + " " + Surname + " : " + Phone;

		private string country;

		public string Country
		{
			get { return country; }
			set 
			{ 
				country = value;
                CheckPropChange();
                CheckPropChange(nameof(FullInfo));
            }
		}

		public override string ToString()
        {
            return Name + " " + Surname + " : " + Phone;
        }

    }
}
