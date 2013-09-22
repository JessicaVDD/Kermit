using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Willow.Kermit.Model
{
    public class Address: PropertyChangedBase
    {
        string street;
        string number_bus;
        string postal_code;
        string city;
        private string country;

        public string Street
        {
            get { return street; }
            set
            {
                if (street == value) return;
                street = value;
                NotifyOfPropertyChange(() => Street);
            }
        }

        public string NumberBus
        {
            get { return number_bus; }
            set
            {
                if (number_bus == value) return;
                number_bus = value;
                NotifyOfPropertyChange(() => NumberBus);
            }
        }

        public string PostalCode
        {
            get { return postal_code; }
            set
            {
                if (postal_code == value) return;
                postal_code = value;
                NotifyOfPropertyChange(() => PostalCode);
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                if (city == value) return;
                city = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                if (country == value) return;
                country = value;
                NotifyOfPropertyChange(() => Country);
            }
        }
    }
}
