using ContactStoreLib.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ComtactStoreLib.Sevices
{
    public class ContactService : IContactService
    {
        private SqlConnection _sql;

        public ContactService()
        {
            _sql = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString);
        }
        public List<Contact> GetContact()
        {
            List<Contact> data = new List<Contact>();
            _sql.Open();
            var command = new SqlCommand("SELECT * FROM CONTACT", _sql);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.Add(new Contact(reader.GetGuid(0), reader.GetInt64(1), reader.GetString(2)));
                }
            }
            _sql.Close();
            return data;
        }

        public void AddContact(Contact contact)
        {
            _sql.Open();
            var command = new SqlCommand("INSERT INTO CONTACT VALUES(@contactId,@contact)", _sql);
            command.Parameters.Add(new SqlParameter("@contactId", contact.ContactId));
            command.Parameters.Add(new SqlParameter("@contact", contact.Contacts));
            command.Parameters.Add(new SqlParameter("@name", contact.Name));
            command.ExecuteNonQuery();
            _sql.Close();
        }

        public List<ContactBook> GetContactWithAddresses()
        {
            _sql.Open();
            List<ContactBook> data = new List<ContactBook>();
            var command = new SqlCommand("SELECT CONTACT.CONTACTID, CONTACT.CONTACT ,CONTACT.NAME,ADDRESSES.PERMANENTADDRESSES, ADDRESSES.TEMPORARYADDRESSES FROM CONTACT INNER JOIN ADDRESSES ON CONTACT.CONTACTID = ADDRESSES.CONTACTID", _sql);
            var dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    data.Add(new ContactBook(dr.GetGuid(0), dr.GetInt64(1), dr.GetString(2), dr[3].ToString(), dr[4].ToString()));

                }
            }
            _sql.Close();
            return data;
        }

        public List<Address> GetAddress(Guid contactId)
        {
            _sql.Open();
            var command = new SqlCommand("SELECT * FROM ADDRESSES WHERE CONTACTID = @contactId", _sql);
            command.Parameters.Add(new SqlParameter("@contactId", contactId));
            var dr = command.ExecuteReader();
            List<Address> list = new List<Address>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    list.Add(new Address(dr[1].ToString(), dr[2].ToString()));
                }
            }
            _sql.Close();
            return list;
        }
    }
}
