
// Copyright 2017-+infinity Stefan Steiger
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


// Simulates System.Security.Principal.GenericIdentity 


// #define UNNEEDED_DOTNETCORE_LEGACY_COMPATIBILITY
#if UNNEEDED_DOTNETCORE_LEGACY_COMPATIBILITY

// Require System.Security.Claims
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


    } // End Class GenericIdentity 


} // End Namespace System.Security.Principal

#endif 
