//---------------------------------------------------------------------------
//
// <copyright file="SystemDrawingExtensionMethods.cs" company="Microsoft">
//    Copyright (C) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// Description: Helper methods for code that uses types from System.Drawing.
//
//---------------------------------------------------------------------------

using System;
using System.IO;
using System.Security;

namespace MS.Internal
{
    internal abstract class SystemDrawingExtensionMethods
    {
        // return true if the data is a bitmap
        internal abstract bool IsBitmap(object data);

        // return true if the data is an Image
        internal abstract bool IsImage(object data);

        // return true if the data is a graphics metafile
        internal abstract bool IsMetafile(object data);

        // return the handle from a metafile
        /// <SecurityNote>
        ///     Critical:  This code returns a handle to an unmanaged object
        /// </SecurityNote>
        [SecurityCritical]
        internal abstract IntPtr GetHandleFromMetafile(Object data);

        // Get the metafile from the handle of the enhanced metafile.
        internal abstract Object GetMetafileFromHemf(IntPtr hMetafile);

        // Get a bitmap from the given data (either BitmapSource or Bitmap)
        internal abstract object GetBitmap(object data);

        // Get a bitmap handle from the given data (either BitmapSource or Bitmap)
        // Also return its width and height.
        /// <SecurityNote>
        ///     Critical:  This code returns a handle to an unmanaged object
        /// </SecurityNote>
        [SecurityCritical]
        internal abstract IntPtr GetHBitmap(object data, out int width, out int height);

        // Get a bitmap handle from a Bitmap
        /// <SecurityNote>
        ///     Critical:  This code returns a handle to an unmanaged object
        /// </SecurityNote>
        [SecurityCritical]
        internal abstract IntPtr GetHBitmapFromBitmap(object data);

        // Convert a metafile to HBitmap
        /// <SecurityNote>
        ///     Critical:  This code returns a handle to an unmanaged object
        /// </SecurityNote>
        [SecurityCritical]
        internal abstract IntPtr ConvertMetafileToHBitmap(IntPtr handle);

        // return a stream for the ExifUserComment in the given Gif
        internal abstract Stream GetCommentFromGifStream(Stream stream);

        // return a new safe-printing permission
        internal abstract CodeAccessPermission NewSafePrintingPermission();

        // return a new default-printing permission
        internal abstract CodeAccessPermission NewDefaultPrintingPermission();

        // write a metafile stream to the output stream in PNG format
        internal abstract void SaveMetafileToImageStream(MemoryStream metafileStream, Stream imageStream);

        //returns bitmap snapshot of selected area
        //this code takes a BitmapImage and converts it to a Bitmap so it can be put on the clipboard
        /// <SecurityNote>
        ///    Critical: This calls into copy pixels which is link demand protected. It initially had a demand and this
        ///              code did not work in PT
        /// </SecurityNote>
        [SecurityCritical]
        internal abstract object GetBitmapFromBitmapSource(object source);
    }
}
