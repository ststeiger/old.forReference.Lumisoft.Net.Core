
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


// Extend string with ToUpper with CultureInfo


#define DOTNETCORE_LEGACY_COMPATIBILITY
#if DOTNETCORE_LEGACY_COMPATIBILITY


namespace System
{


    public static class StringExtensions
    {

        //
        // Summary:
        //     Returns a copy of this string converted to uppercase, using the casing rules
        //     of the specified culture.
        //
        // Parameters:
        //   culture:
        //     An object that supplies culture-specific casing rules.
        //
        // Returns:
        //     The uppercase equivalent of the current string.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     culture is null.
        public static string ToUpper(this string s, System.Globalization.CultureInfo ci)
        {
            return ci.TextInfo.ToUpper(s);
        }

    }


}

#endif 
