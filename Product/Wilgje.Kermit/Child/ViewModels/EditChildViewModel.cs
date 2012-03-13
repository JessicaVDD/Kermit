using System;
using System.ComponentModel;
using Caliburn.Micro;
using Willow.Kermit.Model;

namespace Willow.Kermit.Child.ViewModels
{
    public class EditChildViewModel : Screen, IChildInfoPanel
    {
        Client child;
        GezinViewModel gezin;

        public EditChildViewModel(Client child)
        {
            this.child = child;
            this.child.PropertyChanged += Child_PropertyChanged;
            gezin = new GezinViewModel(child);
        }

        public string Caption
        {
            get { return "Bewerken"; }
        }

        public string Firstname
        {
            get { return child.FirstName; }
            set { child.FirstName = value; }
        }
        public string Lastname
        {
            get { return child.LastName; }
            set { child.LastName = value; }
        }

        public DateTime? DateOfBirth
        {
            get { return child.BirthDate; }
            set { child.BirthDate = value; }
        }
        public bool IsEstimatedBirthday
        {
            get { return child.IsEstimatedBirthday; }
        }
        public bool IsConfirmedBirthday
        {
            get { return !IsEstimatedBirthday; }
        }
        public string Birthplace
        {
            get { return child.BirthPlace; }
            set { child.BirthPlace = value; }
        }

        public Gender Gender
        {
            get { return child.Gender; }
            set { child.Gender = value; }
        }
        public GezinViewModel Gezin
        {
            get { return gezin; }
            set { gezin = value; NotifyOfPropertyChange(() => Gezin); }
        }

        void Child_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "FirstName":
                    NotifyOfPropertyChange(() => Firstname);
                    break;
                case "LastName":
                    NotifyOfPropertyChange(() => Lastname);
                    break;
                case "BirthDate":
                    NotifyOfPropertyChange(() => DateOfBirth);
                    break;
                case "IsEstimatedBirthday":
                    NotifyOfPropertyChange(() => IsEstimatedBirthday);
                    NotifyOfPropertyChange(() => IsConfirmedBirthday);
                    break;
                case "BirthPlace":
                    NotifyOfPropertyChange(() => Birthplace);
                    break;
                case "Gender":
                    NotifyOfPropertyChange(() => Gender);
                    break;
            }
            if (String.IsNullOrWhiteSpace(e.PropertyName))
            {
                NotifyOfPropertyChange(e.PropertyName);
            }
        }

    }
}