using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSessionsWebApp.Models
{
    /// <summary>
    /// Custom Exception for Event
    /// </summary>
    public class NotEnuffRightsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotEnuffRightsException" /> class.
        /// </summary>
        /// <param name="modelStateDictionary">Error message</param>
        public NotEnuffRightsException(string message) : base(message)
        {
        }
    }
}