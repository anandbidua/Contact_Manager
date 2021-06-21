using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactInformation.Utility
{
    public static class Converter
    {

        public static ContactsService.Model.Contacts Map(ContactInformation.Models.Contacts contacts)
        {
            ContactsService.Model.Contacts _contacts = new ContactsService.Model.Contacts();
            Random r = new Random();
            _contacts.Id = r.Next();
            _contacts.FirstName = contacts.FirstName;
            _contacts.LastName = contacts.LastName;
            _contacts.Phone = contacts.Phone;
            _contacts.Email = contacts.Email;
            return _contacts;
        }

        public static ContactInformation.Models.Contacts Map(ContactsService.Model.Contacts contacts)
        {
            ContactInformation.Models.Contacts _contacts = new ContactInformation.Models.Contacts();
            
            _contacts.Id = contacts.Id;
            _contacts.FirstName = contacts.FirstName;
            _contacts.LastName = contacts.LastName;
            _contacts.Phone = contacts.Phone;
            _contacts.Email = contacts.Email;
            return _contacts;
        }

        public static ContactsService.Model.Contacts Map(FormCollection formCollection) {
            ContactsService.Model.Contacts _contacts = new ContactsService.Model.Contacts();

            _contacts.Id = Convert.ToInt32(formCollection["Id"]);
            _contacts.FirstName = formCollection["FirstName"];
            _contacts.LastName = formCollection["LastName"];
            _contacts.Phone = formCollection["Phone"];
            _contacts.Email = formCollection["Email"];
            return _contacts;
        }
    }
}