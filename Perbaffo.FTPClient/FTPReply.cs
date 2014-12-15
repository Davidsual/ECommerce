using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Perbaffo.FTPClient
{
    /// <summary>  
    /// Encapsulates the FTP server reply
    /// </summary>
    public class FTPReply
    {
        /// <summary>  Getter for reply code
        ///  
        /// </summary>
        /// <returns> server's reply code
        /// 
        /// </returns>
        public string ReplyCode
        {
            get
            {
                return replyCode;
            }
        }

        /// <summary>  Getter for reply text
        /// 
        /// </summary>
        /// <returns> server's reply text
        /// 
        /// </returns>
        public string ReplyText
        {
            get
            {
                return replyText;
            }
        }

        /// <summary>  Reply code
        /// </summary>
        private string replyCode;

        /// <summary>  Reply text
        /// </summary>
        private string replyText;


        /// <summary>  
        /// Constructor. Only to be constructed
        /// by this package, hence internal access
        /// </summary>
        /// <param name="replyCode"> the server's reply code
        /// </param>
        /// <param name="replyText"> the server's reply text
        /// 
        /// </param>
        internal FTPReply(string replyCode, string replyText)
        {
            this.replyCode = replyCode;
            this.replyText = replyText;
        }


    }
}
