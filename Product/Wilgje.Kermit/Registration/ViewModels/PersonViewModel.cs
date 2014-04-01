using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.Registration.Interfaces;

namespace Willow.Kermit.Registration.ViewModels
{
    public class PersonViewModel : Screen, Person
    {
        public PersonViewModel()
        {
            DisplayName = "Person";
            HasClose = true;
            FirstnameLabel = "Voornaam";
            SurnameLabel = "Achternaam";
            BirthDayLabel = "Geboortedatum";
            Professions = new BindableCollection<TestClass> { new TestClass { Profession = "Arbeider", Time = 5 }, new TestClass { Profession = "Zoeker", Time = 3 } };
        }
        public bool HasClose { get; set; }

        public string FirstnameLabel { get; set; }
        public string Firstname { get; set; }
        public string SurnameLabel { get; set; }
        public string Surname { get; set; }
        public string BirthDayLabel { get; set; }
        public DateTime? BirthDay { get; set; }
        public Genders Gender { get; set; }

        public BindableCollection<TestClass> Professions { get; set; }

        public void AddProfession()
        {
            Professions.Add(new TestClass { Profession = "Failure", Time = 99 });
        }

        public void RemoveProfession(object d)
        {
            var re = d as RoutedEventArgs;
            if (re == null) return;

            var tc = re.OriginalSource as TestClass;
            if (tc == null) return;

            Professions.Remove(tc);
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
