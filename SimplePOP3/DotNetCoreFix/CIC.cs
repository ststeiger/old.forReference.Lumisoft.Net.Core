
namespace System
{
    namespace Text
    {
        public class Encoding2
        {
            public static System.Text.Encoding Default = System.Text.Encoding.GetEncoding(0);

            public static System.Text.Encoding Def
            {
                get
                {
                    return System.Text.Encoding.GetEncoding(0);
                }
            }



            // to get the default encoding.
        }
    }

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


    //
    // Summary:
    //     Specifies the culture, case, and sort rules to be used by certain overloads of
    //     the System.String.Compare(System.String,System.String) and System.String.Equals(System.Object)
    //     methods.
    public enum StringComparison2
    {
        //
        // Summary:
        //     Compare strings using culture-sensitive sort rules and the current culture.
        CurrentCulture = 0,
        //
        // Summary:
        //     Compare strings using culture-sensitive sort rules, the current culture, and
        //     ignoring the case of the strings being compared.
        CurrentCultureIgnoreCase = 1,
        //
        // Summary:
        //     Compare strings using culture-sensitive sort rules and the invariant culture.
        InvariantCulture = 2,
        //
        // Summary:
        //     Compare strings using culture-sensitive sort rules, the invariant culture, and
        //     ignoring the case of the strings being compared.
        InvariantCultureIgnoreCase = 3,
        //
        // Summary:
        //     Compare strings using ordinal sort rules.
        Ordinal = 4,
        //
        // Summary:
        //     Compare strings using ordinal sort rules and ignoring the case of the strings
        //     being compared.
        OrdinalIgnoreCase = 5
    }


    public class String2
    {


        public static bool StartsWith(string some, string value, StringComparison2 comparisonType)
        {
            if (some == null && value == null)
                return true;

            if (some == null || value == null)
                return false;

            if (value.Length > some.Length)
                return false;

            string start = some.Substring(0, value.Length);
            return String2.Equals(start, value, comparisonType);
        }


        public static bool EndsWith(string some, string value, StringComparison2 comparisonType)
        {
            if (some == null && value == null)
                return true;

            if (some == null || value == null)
                return false;

            if (value.Length > some.Length)
                return false;

            string end = some.Substring(some.Length - value.Length, value.Length);
            return String2.Equals(end, value, comparisonType);
        }




        //
        // Summary:
        //     Determines whether two specified System.String objects have the same value. A
        //     parameter specifies the culture, case, and sort rules used in the comparison.
        //
        // Parameters:
        //   a:
        //     The first string to compare, or null.
        //
        //   b:
        //     The second string to compare, or null.
        //
        //   comparisonType:
        //     One of the enumeration values that specifies the rules for the comparison.
        //
        // Returns:
        //     true if the value of the a parameter is equal to the value of the b parameter;
        //     otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     comparisonType is not a System.StringComparison value.
        public static bool Equals(string a, string b, StringComparison2 comparisonType)
        {
            if (comparisonType == StringComparison2.InvariantCultureIgnoreCase)
                return System.Globalization.CultureInfo.InvariantCulture
                    .CompareInfo.Compare(a, b, System.Globalization.CompareOptions.IgnoreCase) == 0;

            if (comparisonType == StringComparison2.InvariantCulture)
                return System.Globalization.CultureInfo.InvariantCulture
                    .CompareInfo.Compare(a, b, System.Globalization.CompareOptions.None) == 0;

            return string.Equals(a, b, (StringComparison)comparisonType);
        }


        public static int Compare(string a, string b, StringComparison2 comparisonType)
        {
            if (comparisonType == StringComparison2.InvariantCultureIgnoreCase)
                return System.Globalization.CultureInfo.InvariantCulture
                    .CompareInfo.Compare(a, b, System.Globalization.CompareOptions.IgnoreCase);

            if (comparisonType == StringComparison2.InvariantCulture)
                return System.Globalization.CultureInfo.InvariantCulture
                    .CompareInfo.Compare(a, b, System.Globalization.CompareOptions.None);

            return string.Compare(a, b, (StringComparison)comparisonType);
        }


    }


    public class InvariantCultureIgnoreCaseImpl
        : System.Collections.Generic.IComparer<string>
        , System.Collections.Generic.IEqualityComparer<string>
        , System.Collections.IComparer
        , System.Collections.IEqualityComparer
    {


        int System.Collections.Generic.IComparer<string>.Compare(string x, string y)
        {
            return System.Globalization.CultureInfo.InvariantCulture
                .CompareInfo.Compare(x, y, System.Globalization.CompareOptions.IgnoreCase);
        } // End Function IComparer<string>.Compare 


        int System.Collections.IComparer.Compare(object x, object y)
        {
            return System.Globalization.CultureInfo.InvariantCulture.CompareInfo
                .Compare(x.ToString(), y.ToString(), System.Globalization.CompareOptions.IgnoreCase);
        } // End Function IComparer.Compare 


        bool System.Collections.Generic.IEqualityComparer<string>.Equals(string x, string y)
        {
            return System.Globalization.CultureInfo.InvariantCulture.CompareInfo
                .Compare(x, y, System.Globalization.CompareOptions.IgnoreCase) == 0;
        } // End Function IEqualityComparer<string>.Equals 


        bool System.Collections.IEqualityComparer.Equals(object x, object y)
        {
            return System.Globalization.CultureInfo.InvariantCulture.CompareInfo.Compare(
                x.ToString(),
                y.ToString(),
                System.Globalization.CompareOptions.IgnoreCase) == 0;
        } // End Function IEqualityComparer.Equals 


        int System.Collections.Generic.IEqualityComparer<string>.GetHashCode(string obj)
        {
            if (obj == null)
            {
                throw new System.ArgumentNullException("obj");
            }

            return obj.GetHashCode();
        } // End Function IEqualityComparer<string>.GetHashCode 


        int System.Collections.IEqualityComparer.GetHashCode(object obj)
        {
            if (obj == null)
            {
                throw new System.ArgumentNullException("obj");
            }

            string s = obj as string;
            if (s != null)
            {
                return s.GetHashCode();
            }

            return obj.GetHashCode();
        } // End IEqualityComparer.GetHashCode 


    } // End Class InvariantCultureIgnoreCase


} // End Namespace SimplePOP3 
