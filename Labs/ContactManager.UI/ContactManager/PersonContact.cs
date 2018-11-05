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
    /// Contact whom we can send an email message
    /// </summary>
    public class PersonContact
        : IContact
    {
        private string name;
        private string emailAddress;

        /// <summary>
        /// Create a person contact object
        /// </summary>
        public PersonContact(string name, string emailAddress)
        {
            this.name = name;
            this.emailAddress = emailAddress;
        }

        /// <summary>
        /// Send a message to the this contact using a messaging service
        /// </summary>
        public void SendMessage(IMessagingService messagingService, string subject, string message)
        {
            messagingService.Send(emailAddress, subject, message);
        }

        /// <summary>
        /// Clone this object. For read-only purposes in the list
        /// </summary>
        public object Clone()
        {
            return new PersonContact(name, emailAddress);
        }

        /// <summary>
        /// Validate that name is unique
        /// </summary>
        public virtual void ValidateAdd(ContactsList contactsList)
        {
            if (name == string.Empty)
                throw new Exception("Name is empty.");

            if (emailAddress == string.Empty)
                throw new Exception("Email address is empty.");

            if(contactsList.FindContact(name) != null)
                throw new Exception("Name is not unique.");

        }

        /// <summary>
        /// Validate that the contact exists and name is unique
        /// </summary>
        public virtual void ValidateUpdate(ContactsList contactsList)
        {
            if (name == string.Empty)
                throw new Exception("Name is empty.");

            if (emailAddress == string.Empty)
                throw new Exception("Email address is empty.");

            IContact contact = contactsList.FindContact(name);

            if (contact != null)
                throw new Exception("Name is not unique.");
        }

        /// <summary>
        /// Access to the email address property
        /// </summary>
        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
        }

        /// <summary>
        /// Access to the name property
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }
    }
}
