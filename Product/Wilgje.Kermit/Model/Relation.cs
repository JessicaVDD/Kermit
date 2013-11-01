using Caliburn.Micro;
using System;
namespace Willow.Kermit.Model
{
    public class Relation: PropertyChangedBase
    {
        string first_name;
        string last_name;
        string extra_info;
        string telephone;
        string mail;
        string relation_type;
        bool isMan;
        DateTime? birthDate;
        string profession;
        private bool isExpanded;
        
        public string FirstName
        {
            get { return first_name; }
            set
            {
                if (first_name == value) return;
                first_name = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                if (isExpanded == value) return;
                isExpanded = value;
                NotifyOfPropertyChange(() => IsExpanded);
            }
        }

        public string LastName
        {
            get { return last_name; }
            set
            {
                if (last_name == value) return;
                last_name = value; 
                NotifyOfPropertyChange(() => LastName);
            }
        }

        public string Telephone
        {
            get { return telephone; }
            set
            {
                if (telephone == value) return;
                telephone = value;
                NotifyOfPropertyChange(() => Telephone);
            }
        }

        public string Mail
        {
            get { return mail; }
            set
            {
                if (mail == value) return;
                mail = value;
                NotifyOfPropertyChange(() => Mail);
            }
        }

        public string ExtraInfo
        {
            get { return extra_info; }
            set
            {
                if (extra_info == value) return;
                extra_info = value;
                NotifyOfPropertyChange(() => ExtraInfo);
            }
        }

        public string RelationType 
        {
            get { return relation_type; }
            set
            {
                if (relation_type == null) return;
                relation_type = value;
                NotifyOfPropertyChange(() => RelationType);
            }
        }

        public string Profession
        {
            get { return profession; }
            set
            {
                if (profession == value) return;
                profession = value;
                NotifyOfPropertyChange(() => Profession);
            }
        }

        public IObservableCollection<string> RelationTypes
        {
            get { return new BindableCollection<string>(new[] { "Papa", "Mama", "Broer", "Zus", "Opa", "Oma" }); }
        }

        public Family Family { get; set; }

        public bool IsMan
        {
            get { return isMan; }
            set
            {
                if (isMan == value) return;
                isMan = value;
                NotifyOfPropertyChange(() => IsMan);
                NotifyOfPropertyChange(() => IsVrouw);
            }
        }
        public bool IsVrouw
        {
            get { return !IsMan; }
            set 
            {
                IsMan = !value;
            }
        }

        public DateTime? BirthDate
        {
            get { return birthDate; }
            set 
            {
                if (birthDate == value) return;
                birthDate = value;
                NotifyOfPropertyChange(() => BirthDate);
            }
        }
    }
}