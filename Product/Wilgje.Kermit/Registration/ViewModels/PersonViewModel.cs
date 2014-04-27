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
            TelephoneLabel = "Telefoon";
            MailAddressLabel = "Mail";
            AddressLabel = "Adres";
            Professions = new BindableCollection<Profession> { new Profession {HasClose=false} };
            Telephones = new BindableCollection<Telephone> { new Telephone {Usage="Algemeen", HasClose=false} };
            MailAddresses = new BindableCollection<MailAddress> { new MailAddress {Usage="Algemeen", HasClose=false} };
            Addresses = new BindableCollection<Address> { new Address { HasClose = false } };
            ContactUsages = new string[] { "Algemeen", "Werk", "Privé" };
        }
        public bool HasClose { get; set; }

        public string FirstnameLabel { get; set; }
        public string Firstname { get; set; }
        public string SurnameLabel { get; set; }
        public string Surname { get; set; }
        public string BirthDayLabel { get; set; }
        public DateTime? BirthDay { get; set; }
        public Genders Gender { get; set; }

        public string[] ContactUsages { get; private set; }
        public string MailAddressLabel { get; set; }
        public BindableCollection<MailAddress> MailAddresses { get; set; }
        public void AddMailAddress()
        {
            MailAddresses.Add(new MailAddress { Usage = "Algemeen" });
        }
        public void RemoveMailAddress(MailAddress t)
        {
            if (t != null)
                MailAddresses.Remove(t);
        }

        public string TelephoneLabel { get; set; }
        public BindableCollection<Telephone> Telephones { get; set; }
        public void AddTelephone()
        {
            Telephones.Add(new Telephone { Usage = "Algemeen" });
        }
        public void RemoveTelephone(Telephone t)
        {
            if (t != null)
                Telephones.Remove(t);
        }

        public string ProfessionLabel { get; set; }
        public BindableCollection<Profession> Professions { get; set; }
        public void AddProfession()
        {
            Professions.Add(new Profession());
        }
        public void RemoveProfession(Profession t)
        {
            if (t != null)
                Professions.Remove(t);
        }

        public string AddressLabel { get; set; }
        public BindableCollection<Address> Addresses { get; set; }
        public void AddAddress()
        {
            Addresses.Add(new Address());
        }
        public void RemoveAddress(Address t)
        {
            if (t != null)
                Addresses.Remove(t);
        }

        public bool HasAdd { get { return true; } }
    }

    public class Profession
    {
        public Profession() { HasClose = true; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public bool HasClose { get; set; }
    }

    public class Telephone
    {
        public Telephone() { HasClose = true; }
        public string Number { get; set; }
        public string Usage { get; set; }
        public string Remark { get; set; }
        public bool HasClose { get; set; }
    }

    public class MailAddress
    {
        public MailAddress() { HasClose = true; }
        public string Address { get; set; }
        public string Usage { get; set; }
        public bool HasClose { get; set; }
    }

    public class Address
    {
        public Address() { HasClose = true; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool HasClose { get; set; }
    }
}
