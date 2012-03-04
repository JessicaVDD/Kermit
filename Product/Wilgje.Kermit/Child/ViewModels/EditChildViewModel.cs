using System;
using Caliburn.Micro;
using Willow.Kermit.Model;

namespace Willow.Kermit.Child.ViewModels
{
    public class EditChildViewModel : Screen, IChildInfoPanel
    {
        Client child;

        public EditChildViewModel(Client child)
        {
            this.child = child;
        }

        public string Caption { get { return "Bewerken"; } }

        public string FirstName
        {
            get { return child.FirstName; }
            set { child.FirstName = value; NotifyOfPropertyChange(() => FirstName); }
        }
        public string LastName
        {
            get { return child.LastName; }
            set { child.LastName = value; NotifyOfPropertyChange(() => LastName); }
        }

        public DateTime? DateOfBirth
        {
            get { return child.BirthDate; }
            set
            {
                child.BirthDate = value; 
                NotifyOfPropertyChange(() => DateOfBirth);
                NotifyOfPropertyChange(() => IsEstimatedBirthday);
                NotifyOfPropertyChange(() => IsConfirmedBirthday);
            }
        }
        public bool IsEstimatedBirthday
        {
            get { return child.IsEstimatedBirthday; }
            set 
            { 
                child.IsEstimatedBirthday = value; 
                NotifyOfPropertyChange(() => IsEstimatedBirthday);
                NotifyOfPropertyChange(() => IsConfirmedBirthday);
            }
        }
        public bool IsConfirmedBirthday
        {
            get { return !IsEstimatedBirthday; }
        }
        public string Birthplace
        {
            get { return child.BirthPlace; }
            set { child.BirthPlace = value; NotifyOfPropertyChange(() => Birthplace); }
        }

        public Gender Gender
        {
            get { return child.Gender; }
            set { child.Gender = value; NotifyOfPropertyChange(() => Gender);}
        }
    }
}