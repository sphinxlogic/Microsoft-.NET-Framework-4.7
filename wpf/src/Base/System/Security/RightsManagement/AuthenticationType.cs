//-----------------------------------------------------------------------------
//
// <copyright file="AuthenticationType.cs" company="Microsoft">
//    Copyright (C) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// Description:  Authentication Type enumeration is used to differentiate users.    
//
// History:
//  06/01/2005: IgorBel :   Initial Implementation 
//
//-----------------------------------------------------------------------------

using System;

namespace System.Security.RightsManagement 
{

    /// <summary>
    /// Enumeration that describes various Authentication types, currently only Passport and Windows are supported.
    /// </summary>
    public enum AuthenticationType : int
    {
            /// <summary>
            /// Windows authentication used in corporate Domain environments. 
            /// </summary>
            Windows,

            /// <summary>
            /// Passport authentication, can be used outside of the Windows Domain environments. 
            /// </summary>
            Passport,

            /// <summary>
            /// WindowsPassport authentication, can be used in scenarios when the authentication type of the consumer 
            /// isn't known or important . Regardless of whether it is Passport or Windows, author wants to enable consumer to 
            /// decrypt the document.       
            /// </summary>
            WindowsPassport, 

            /// <summary>
            /// Internal authentication type can be used to identify users implicitly without using their IDs.
            /// Currently this option only supports "Anyone" persona. So that End Use License will be granted 
            /// to anyone who requests one, but it will be attached to the requesting user.  
            /// </summary>
            Internal
    }
}
 
