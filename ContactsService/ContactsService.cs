using ContactsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsService
{
    public class ContactsService : IContactsService
    {
       public static List<Contacts> contactsList = new List<Contacts>();
        Random r = new Random();
        /// <summary>
        /// Create Contacts
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        public bool CreateContact(Contacts contacts)
        {
            if (contacts != null)
            {
                if (!contactsList.Any(x => x.Email == contacts.Email) || !contactsList.Any(x => x.Phone == contacts.Phone))
                {

                    contactsList.Add(contacts);
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteContact(int Id)
        {
            contactsList.RemoveAll(x => x.Id == Id);
        }
        /// <summary>
        /// Edit contact
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Contacts EditContact(int Id)
        {
            return contactsList.Single(x => x.Id == Id);
        }
        /// <summary>
        /// update contact
        /// </summary>
        /// <param name="contact"></param>
        public bool EditContact(Contacts contact)
        {
            var cont = contactsList.FirstOrDefault(x => x.Id == contact.Id);
            if (cont != null)
            {
                cont.FirstName = contact.FirstName;
                cont.LastName = contact.LastName;
                cont.Phone = contact.Phone;
                cont.Email = contact.Email;
                return true;
            }
            else
               return false;
        }
        /// <summary>
        /// get contacts
        /// </summary>
        /// <returns></returns>
        public List<Contacts> GetContacts()
        {
            
            return contactsList;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
