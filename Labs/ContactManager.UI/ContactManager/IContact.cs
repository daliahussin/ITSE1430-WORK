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
    /// Defines the methods and properties of a contact
    /// </summary>
    public interface IContact
        : ICloneable
    {
        /// <summary>
        /// Access to the name of the contact
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Send a message to the this contact using a messaging service
        /// </summary>
        void SendMessage(IMessagingService messagingService, string subject, string message);
    }
}
