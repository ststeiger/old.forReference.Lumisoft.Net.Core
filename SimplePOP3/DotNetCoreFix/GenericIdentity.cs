
using System;
using System.Collections.Generic;
using System.Text;


namespace System.Security.Principal
{


    public class GenericIdentity
    {
        private string m_userName;
        private string m_type;


        public GenericIdentity()
        {

        }
        

        public GenericIdentity(string username, string type)
        {
            this.m_userName = username;
            this.m_type = type;
        }


    }


}
