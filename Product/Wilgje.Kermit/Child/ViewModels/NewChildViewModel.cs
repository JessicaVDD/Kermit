using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.Child.Interfaces;
using Willow.Kermit.General.Messages;
using Willow.Kermit.Model;
using Willow.Kermit.Util;

namespace Willow.Kermit.Child.ViewModels
{
    public class NewChildViewModel : Screen, INewChildViewModel
    {
        Client _child;

        string _caption;

        ChildVisualCardViewModel child_visual_card;
        RelationListViewModel relation_list;

        public NewChildViewModel() : this(ClientFactory.CreateNew())
        {
            Caption = "Nieuw";
        }
        public NewChildViewModel(Client client)
        {
            _child = client;
            _child.PropertyChanged += Child_PropertyChanged;

            Caption = client.FirstName;
            Image = ImageGetter.BabyIcon;

            ChildVisualCard = new ChildVisualCardViewModel(_child);
            RelationList = new RelationListViewModel(_child);
            ChildActionPanels = new List<IChildInfoPanel>
            {
                new ChildOverviewViewModel(_child),
                new EditChildViewModel(_child)
            };
        }

        public string Caption
        {
            get { return _caption; }
            set { _caption = value; NotifyOfPropertyChange(() => _caption); }
        }
        public BitmapImage Image { get; set; }
        public IEventAggregator Events { get; set; }

        public string Fullname
        {
            get
            {
                if (_child.FirstName == null && _child.LastName == null) return null;
                return string.Format("{0} {1}",_child.FirstName, _child.LastName);
            }
        }
        public Gender Gender
        {
            get { return _child.Gender; }
        }

        public List<IChildInfoPanel> ChildActionPanels { get; set; }
        public ChildVisualCardViewModel ChildVisualCard
        {
            get { return child_visual_card; }
            set { child_visual_card = value; NotifyOfPropertyChange(() => ChildVisualCard); }
        }
        public RelationListViewModel RelationList
        {
            get { return relation_list; }
            set { relation_list = value; NotifyOfPropertyChange(() => RelationList); }
        }

        public void Close()
        {
            if (Events != null)
                Events.Publish(new CloseTabMessage { Item = this });
        }

        void Child_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "FirstName":
                case "LastName":
                    NotifyOfPropertyChange(() => Fullname);
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