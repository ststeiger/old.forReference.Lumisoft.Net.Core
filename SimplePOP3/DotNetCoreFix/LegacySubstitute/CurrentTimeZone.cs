﻿
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


// Simulates System.TimeZone.CurrentTimeZone.GetUtcOffset 


#define DOTNETCORE_LEGACY_COMPATIBILITY 
#if DOTNETCORE_LEGACY_COMPATIBILITY


namespace System.TimeZone
{

    public class CurrentTimeZone
    {

        public static System.TimeSpan GetUtcOffset(System.DateTime datetime)
        {
            return System.TimeZoneInfo.Local.GetUtcOffset(datetime);
        } // End Function GetUtcOffset 

    } // End Class CurrentTimeZone


} // End Namespace System.TimeZone

#endif
