/* ITSE 1430 
 * Dalia Hussin 
 * 11/5/2018 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    /// <summary>
    /// Manages list of contacts
    /// </summary>
    public class ContactsList
    {
        private List<IContact> contacts;

        /// <summary>
        /// Create a new contacts list
        /// </summary>
        public ContactsList()
        {
            contacts = new List<IContact>();
        }

        /// <summary>
        /// Add a new contact, validate that the name is unique
        /// </summary>
        public void AddContact(IContact contact)
        {            
            foreach(IContact existingContact in contacts)
                if(existingContact.Name.ToLower().Equals(contact.Name.ToLower()))
                    throw new Exception("Contact name is not unique.");

            contacts.Add(contact);
        }

        /// <summary>
        /// Remove a contact given a name
        /// </summary>
        public void RemoveContact(string name)
        {
            IContact contact = null;

            foreach(IContact existingContact in contacts)
            {
                if(existingContact.Name.ToLower().Equals(name.ToLower()))
                {
                    contact = existingContact;
                    break;
                }
            }

            if(contact == null)
                throw new Exception("Contact not found.");

            contacts.Remove(contact);
        }

        /// <summary>
        /// Update the details of an old contact
        /// </summary>
        public void UpdateContact(string oldName, IContact contact)
        {
            int index = -1;

            for(int i = 0; i < contacts.Count; i++)
            {
                if(contacts[i].Name.ToLower().Equals(oldName.ToLower()))
                {
                    index = i;
                    break;
                }
            }
            
            if (index == -1)
                throw new Exception("Contact does not exist.");

            contacts[index] = contact;
        }

        /// <summary>
        /// Find a contact and return it.
        /// </summary>
        public IContact FindContact(string name)
        {
            foreach (IContact existingContact in contacts)
                if (existingContact.Name.ToLower().Equals(name.ToLower()))
                    return (IContact) existingContact.Clone();

            return null;
        }

        /// <summary>
        /// Access to the contacts
        /// </summary>
        public IEnumerable<IContact> Contacts
        {
            get
            {
                return contacts.AsReadOnly();
            }
        }
    }
}
