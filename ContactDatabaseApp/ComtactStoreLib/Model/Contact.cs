using System;

namespace ContactStoreLib.Model
{
    public class Contact
    {
        private long _contact;
        private Guid _contactId;
        private string _name;

        public Contact(Guid contactId,long contact, string name)
        {
            _contact = contact;
            _contactId = contactId;
            _name = name;
        }


        public long Contacts
        {
            get { return _contact; }
          
        }

        public Guid ContactId
        {
            get { return _contactId; }
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
