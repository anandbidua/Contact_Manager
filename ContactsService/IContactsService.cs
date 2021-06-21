using ContactsService.Model;
using System;
using System.Collections.Generic;

namespace ContactsService
{
    public interface IContactsService:IDisposable
    {
        List<Contacts> GetContacts();
        bool CreateContact(Contacts contacts);
        void DeleteContact(int Id);
        Contacts EditContact(int Id);
        bool EditContact( Contacts contact);

    }
}
