using System;
using System.Collections.Generic;
using System.Text;

namespace LumiSoft.Net.SIP.Message
{
    /// <summary>
    /// This base class for all SIP data types.
    /// </summary>
    public abstract class SIP_t_Value
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SIP_t_Value()
        {
        }


        
        /// <summary>
        /// Parses single value from specified reader.
        /// </summary>
        /// <param name="reader">Reader what contains </param>
        public abstract void Parse(StringReader reader);

        

        
        /// <summary>
        /// Convert this to string value.
        /// </summary>
        /// <returns>Returns this as string value.</returns>
        public abstract string ToStringValue();

        

    }
}
