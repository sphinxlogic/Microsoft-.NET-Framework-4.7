//------------------------------------------------------------------------------
// <copyright file="DoubleConverter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

/*
 */
namespace System.ComponentModel {
    using Microsoft.Win32;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Runtime.Remoting;
    using System.Runtime.Serialization.Formatters;
    using System.Security.Permissions;

    /// <devdoc>
    ///    <para>Provides a type
    ///       converter to convert double-precision, floating point number objects to and from various
    ///       other representations.</para>
    /// </devdoc>

    [HostProtection(SharedState = true)]
    public class DoubleConverter : BaseNumberConverter
    {
    
          
        /// <devdoc>
        /// Determines whether this editor will attempt to convert hex (0x or #) strings
        /// </devdoc>
        internal override bool AllowHex {
                get {
                     return false;
                }
        }
        
         /// <devdoc>
        /// The Type this converter is targeting (e.g. Int16, UInt32, etc.)
        /// </devdoc>
        internal override Type TargetType {
                get {
                    return typeof(Double);
                }
        }

        /// <devdoc>
        /// Convert the given value to a string using the given radix
        /// </devdoc>
        internal override object FromString(string value, int radix) {
                return Convert.ToDouble(value, CultureInfo.CurrentCulture);
        }
        
        /// <devdoc>
        /// Convert the given value to a string using the given formatInfo
        /// </devdoc>
        internal override object FromString(string value, NumberFormatInfo formatInfo) {
                return Double.Parse(value, NumberStyles.Float, formatInfo);
        }
        
        
        /// <devdoc>
        /// Convert the given value to a string using the given CultureInfo
        /// </devdoc>
        internal override object FromString(string value, CultureInfo culture){
                 return Double.Parse(value, culture);
        }
        
        /// <devdoc>
        /// Convert the given value from a string using the given formatInfo
        /// </devdoc>
        internal override string ToString(object value, NumberFormatInfo formatInfo) {
                return ((Double)value).ToString("R", formatInfo);
        }

    }
}

