using System;

namespace ContactStoreLib.Model
{
    public class ContactBook
    {
        private long _contact;
        private Guid _contactId;
        private string _name;
        private string _permanentAddress;
        private string _tempAddress;
        public ContactBook(Guid contactId, long contact, string name,string permanentAddress, string tempAddress)
        {
            _contact = contact;
            _contactId = contactId;
            _name = name;
            _permanentAddress = permanentAddress;
            _tempAddress = tempAddress;
        }

        public long Contacts
        {
            get { return _contact; }

        }

        public Guid ContactId
        {
            get { return _contactId; }
        }

        public string PermanentAddress
        {
            get { return _permanentAddress; }
        }

        public string TempAddress
        {
            get { return _tempAddress; }
        }
    }
}
