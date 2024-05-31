// ==++==
// 
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// 
// ==--==
namespace System {
    
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    using System.Runtime.Versioning;
    using System.Diagnostics.Contracts;

    // This class will not be marked serializable
    // Note: This type must have the same layout as the CLR's VARARGS type in CLRVarArgs.h.
    // It also contains an inline SigPointer data structure - must keep those fields in sync.
    [StructLayout(LayoutKind.Sequential)]
    public struct ArgIterator
    {
        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.None)]
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private extern ArgIterator(IntPtr arglist);

        // create an arg iterator that points at the first argument that
        // is not statically declared (that is the first ... arg)
        // 'arglist' is the value returned by the ARGLIST instruction
        [System.Security.SecuritySafeCritical]  // auto-generated
        public ArgIterator(RuntimeArgumentHandle arglist) : this(arglist.Value)
        {
        }

        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.None)]
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private unsafe extern ArgIterator(IntPtr arglist, void *ptr);
        
        // create an arg iterator that points just past 'firstArg'.  
        // 'arglist' is the value returned by the ARGLIST instruction
        // This is much like the C va_start macro

        [System.Security.SecurityCritical]  // auto-generated
        [CLSCompliant(false)]

        public unsafe ArgIterator(RuntimeArgumentHandle arglist, void* ptr) : this(arglist.Value, ptr)
        {
        }

        // Fetch an argument as a typed referece, advance the iterator.
        // Throws an exception if past end of argument list
        [System.Security.SecuritySafeCritical]  // auto-generated
        [CLSCompliant(false)]
        public TypedReference GetNextArg()
        {
            TypedReference result = new TypedReference ();
            // reference to TypedReference is banned, so have to pass result as pointer
            unsafe
            {
                FCallGetNextArg (&result);
            }
            return result;
        }

        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.None)]
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        // reference to TypedReference is banned, so have to pass result as void pointer
        private unsafe extern void FCallGetNextArg(void * result);

        // Alternate version of GetNextArg() intended primarily for IJW code
        // generated by VC's "va_arg()" construct. 
        [System.Security.SecuritySafeCritical]  // auto-generated
        [CLSCompliant(false)]
        public TypedReference GetNextArg(RuntimeTypeHandle rth)
        {
            if (sigPtr != IntPtr.Zero)
            {
                // This is an ordinary ArgIterator capable of determining
                // types from a signature. Just do a regular GetNextArg.
                return GetNextArg();
            }
            else
            {
                // Prevent abuse of this API with a default ArgIterator (it
                // doesn't require permission to create a zero-inited value
                // type). Check that ArgPtr isn't zero or this API will allow a
                // malicious caller to increment the pointer to an arbitrary
                // location in memory and read the contents.
                if (ArgPtr == IntPtr.Zero)
                    throw new ArgumentNullException();

                TypedReference result = new TypedReference ();
                // reference to TypedReference is banned, so have to pass result as pointer
                unsafe
                {
                    InternalGetNextArg(&result, rth.GetRuntimeType());
                }
                return result;
            }
        }


        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.None)]
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        // reference to TypedReference is banned, so have to pass result as void pointer
        private unsafe extern void InternalGetNextArg(void * result, RuntimeType rt);

        // This method should invalidate the iterator (va_end). It is not supported yet.
        public void End()
        {
        }
    
        // How many arguments are left in the list 
        [System.Security.SecuritySafeCritical]  // auto-generated
        [ResourceExposure(ResourceScope.None)]
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern int GetRemainingCount();
    
        // Gets the type of the current arg, does NOT advance the iterator
        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.None)]
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private extern unsafe void* _GetNextArgType();

        [System.Security.SecuritySafeCritical]  // auto-generated
        public unsafe RuntimeTypeHandle GetNextArgType() 
        {
            return new RuntimeTypeHandle(Type.GetTypeFromHandleUnsafe((IntPtr)_GetNextArgType()));
        }
    
        public override int GetHashCode()
        {
            return ValueType.GetHashCodeOfPtr(ArgCookie);
        }
    
        // Inherited from object
        public override bool Equals(Object o)
        {
            throw new NotSupportedException(Environment.GetResourceString("NotSupported_NYI"));
        }

        private IntPtr ArgCookie;               // Cookie from the EE.

        // The SigPointer structure consists of the following members.  (Note: this is an inline native SigPointer data type)
        private IntPtr sigPtr;                  // Pointer to remaining signature.
        private IntPtr sigPtrLen;               // Remaining length of the pointer

        // Note, sigPtrLen is actually a DWORD, but on 64bit systems this structure becomes
        // 8-byte aligned, which requires us to pad it.
            
        private IntPtr ArgPtr;                  // Pointer to remaining args.
        private int    RemainingArgs;           // # of remaining args.
    }
}
