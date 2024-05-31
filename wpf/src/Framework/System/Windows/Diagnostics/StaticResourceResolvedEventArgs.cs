//-----------------------------------------------------------------------------
//
// <copyright file="StaticResourceResolvedEventArgs.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved.
// </copyright>
//
// Description:
//      Contains EventArg types raised to communicate resolution of a StaticResource reference.
//-----------------------------------------------------------------------------

namespace System.Windows.Diagnostics
{
    /// <summary>
    /// Provides data for <see cref="ResourceDictionaryDiagnostics.StaticResourceResolved"/>
    /// event.
    /// </summary>
    public class StaticResourceResolvedEventArgs : EventArgs
    {
        internal StaticResourceResolvedEventArgs(
                    Object targetObject,
                    Object targetProperty,
                    ResourceDictionary rd,
                    Object key)
        {
            TargetObject = targetObject;
            TargetProperty = targetProperty;
            ResourceDictionary = rd;
            ResourceKey = key;
        }

        public Object TargetObject { get; private set; }
        public Object TargetProperty { get; private set; }
        public ResourceDictionary ResourceDictionary { get; private set; }
        public object ResourceKey { get; private set; }
    }
}
