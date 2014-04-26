using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.Registration.Interfaces;

namespace Willow.Kermit.Registration.ViewModels
{
    [Export(typeof(Person))][PartCreationPolicy(CreationPolicy.NonShared)]
    public class PersonViewModel : Screen, Person
    {
        public PersonViewModel()
        {
            DisplayName = "Person";
            HasClose = true;
            FirstnameLabel = "Voornaam";
            SurnameLabel = "Achternaam";
            BirthDayLabel = "Geboortedatum";
            ProfessionLabel = "Beroep";
            Professions = new BindableCollection<TestClass> { new TestClass() };
            Telephones = new BindableCollection<string> { "" };
            MailAddresses = new BindableCollection<string> { "" };
        }
        public bool HasClose { get; set; }

        public string FirstnameLabel { get; set; }
        public string Firstname { get; set; }
        public string SurnameLabel { get; set; }
        public string Surname { get; set; }
        public string BirthDayLabel { get; set; }
        public DateTime? BirthDay { get; set; }
        public Genders Gender { get; set; }

        public string MailAddressLabel { get; set; }
        public BindableCollection<string> MailAddresses { get; set; }
        public void AddMailAddress()
        {
            MailAddresses.Add("");
        }
        public void RemoveMailAddress(string t)
        {
            if (t != null)
                MailAddresses.Remove(t);
        }

        public string TelephoneLabel { get; set; }
        public BindableCollection<string> Telephones { get; set; }
        public void AddTelephone()
        {
            Telephones.Add("");
        }
        public void RemoveTelephone(string t)
        {
            if (t != null)
                Telephones.Remove(t);
        }

        public string ProfessionLabel { get; set; }
        public BindableCollection<TestClass> Professions { get; set; }
        public void AddProfession()
        {
            Professions.Add(new TestClass());
        }
        public void RemoveProfession(TestClass t)
        {
            if (t != null)
                Professions.Remove(t);
        }

        public bool HasAdd { get { return true; } }
    }

    public class TestClass
    {
        public string Profession { get; set; }
        public int Time { get; set; }
        public bool HasClose { get { return true; } }
    }

}
