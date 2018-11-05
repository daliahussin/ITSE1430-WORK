/* ITSE 1430 
 * Dalia Hussin
 * 11/5/2018 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UI
{
    /// <summary>
    /// Simulates a messaging service since this is not an actual
    /// messaging service
    /// </summary>
    public class DummyMessagingService
        : IMessagingService
    {
        private ListView messagesListView;

        /// <summary>
        /// Initialize the list view where to forward messages
        /// </summary>
        public DummyMessagingService(ListView messagesListView)
        {
            this.messagesListView = messagesListView;
        }

        /// <summary>
        /// Send a message, put it in the list view
        /// </summary>
        public void Send(string emailAddress, string subject, string message)
        {
            messagesListView.Items.Add(new ListViewItem(new string[]{ emailAddress, subject, message }));
        }
    }
}
