using ContactStoreLib.Model;
using System;
using System.Collections.Generic;

namespace ComtactStoreLib.Sevices
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        List<Address> GetAddress(Guid contactId);
        List<Contact> GetContact();
        List<ContactBook> GetContactWithAddresses();
    }
}