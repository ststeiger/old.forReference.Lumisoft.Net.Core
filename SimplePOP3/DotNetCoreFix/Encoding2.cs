
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


// Substitute System.Text.Encoding.Default  
// TODO: Can we always use System.Text.Encoding.GetEncoding(0) ? 


#define DOTNETCORE_LEGACY_COMPATIBILITY 


namespace System.Text 
{


    internal class Encoding2
    {


        // public static System.Text.Encoding Default = System.Text.Encoding.GetEncoding(0);
        public static System.Text.Encoding Default
        {

            get
            {
#if DOTNETCORE_LEGACY_COMPATIBILITY
                return System.Text.Encoding.GetEncoding(0);
#else
                return System.Text.Encoding.Default;
#endif

            }

        } // End Property Default 


    } // End Class Encoding2


} // End Namespace System.Text
