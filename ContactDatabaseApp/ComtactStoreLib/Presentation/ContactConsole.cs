using ComtactStoreLib.Sevices;
using ContactStoreLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComtactStoreLib.Presentation
{
    public class ContactConsole
    {
        public ContactConsole()
        {

            ContactService service = new ContactService();

            var contacts = service.GetContact();
            foreach (var contact in contacts)
            {
                Console.WriteLine("{0}\t{1}\t{2}", contact.ContactId, contact.Contacts, contact.Name);
            }

            var address = service.GetAddress(new Guid("A1D0A0FD-E1DB-4D6A-818D-321564479EB2"));
            foreach (var add in address)
            {
                Console.WriteLine("{0}\t{1}", add.PermanentAddress, add.TemporaryAddress);
            }


            var contactWithAddress = service.GetContactWithAddresses();
            foreach (var contact in contactWithAddress)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", contact.ContactId, contact.Contacts, contact.PermanentAddress, contact.TempAddress);
            }

            Console.ReadLine();

        }
    }
}
