using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactStoreLib.Model
{
    public class Address
    {
        private string _permanentAddress;
        private string _tempAddress;

        public Address(string address,string tempAddress)
        {
            _permanentAddress = address;
            _tempAddress = tempAddress;
        }
        public string PermanentAddress
        {
            get { return _permanentAddress; }
            set
            {
                _permanentAddress = value;
            }
        }

        public string TemporaryAddress
        {
            get { return _tempAddress; }
            set
            {
                _tempAddress = value;
            }
        }
    }
}
