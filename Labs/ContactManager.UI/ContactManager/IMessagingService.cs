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
    /// Defines the methods needed for messaging service
    /// </summary>
    public interface IMessagingService
    {
        /// <summary>
        /// Send a message
        /// </summary>
        void Send(string emailAddress, string subject, string message);
    }
}
