using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace LumiSoft.Net.IMAP.Client
{
    /// <summary>
    /// This class provides data for the <see cref="IMAP_Client_FetchHandler.Rfc822"/> event.
    /// </summary>
    [Obsolete("Use Fetch(bool uid,IMAP_t_SeqSet seqSet,IMAP_t_Fetch_i[] items,EventHandler<EventArgs<IMAP_r_u>> callback) intead.")]
    public class IMAP_Client_Fetch_Rfc822_EArgs : EventArgs
    {
        private Stream m_pStream = null;

        /// <summary>
        /// Default constructor.
        /// </summary>
        internal IMAP_Client_Fetch_Rfc822_EArgs()
        {
        }


        
        /// <summary>
        /// Gets or sets stream where RFC822 message is stored.
        /// </summary>
        public Stream Stream
        {
            get{ return m_pStream; }

            set{ m_pStream = value; }
        }

        

        
        /// <summary>
        /// This method is called when message storing has completed.
        /// </summary>
        public event EventHandler StoringCompleted = null;

        
        /// <summary>
        /// Raises <b>StoringCompleted</b> event.
        /// </summary>
        internal void OnStoringCompleted()
        {
            if(this.StoringCompleted != null){
                this.StoringCompleted(this,new EventArgs());
            }
        }

        

        
    }
}
