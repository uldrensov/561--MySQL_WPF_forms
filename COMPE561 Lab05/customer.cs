using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPE561_Lab05
{
    //class definition for the customer object
    class customer
    {
        //fields
        public string first { get; set; }
        public string last { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string id { get; set; }


        //default constructor
        public customer()
        {
            first = "FIRSTN";
            last = "LASTN";
            address = "ADDR";
            city = "CITY";
            state = "XX";
            zip = "00000";
            phone = "000-000-0000";
            email = "sample@default.com";
            id = "ABCDEF";
        }


        //explicit val constructor
        public customer(string First, string Last, string Address, string City, string State, string Zip, string Phone, string Email, string Id)
        {
            first = First;
            last = Last;
            address = Address;
            city = City;
            state = State;
            zip = Zip;
            phone = Phone;
            email = Email;
            id = Id;
        }


        //ToString override
        public override string ToString()
        {
            return (first + " " + last);
        }
    }
}
