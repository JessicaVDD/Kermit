﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willow.Kermit.Model
{
    public class Family : PropertyChangedBase
    {
        string name;
        Address address;
        readonly IObservableCollection<Relation> relations = new BindableCollection<Relation>();
        
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value) return;
                name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }


        public Address Address
        {
            get { return address; }
            set
            {
                if (ReferenceEquals(address, value)) return;
                address = value;
                NotifyOfPropertyChange(() => Address);
            }
        }

        public IObservableCollection<Relation> Relations
        {
            get { return relations; }
        }
        
    }
}
