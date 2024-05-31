//------------------------------------------------------------------------------
// <copyright file="ListViewItemStates.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace System.Windows.Forms {

    /// <include file='doc\ListViewItemStates.uex' path='docs/doc[@for="ListViewItemStates"]/*' />
    /// <devdoc>
    ///    <para>
    ///
    ///	   Gives state information about a ListView item/sub-item. Used with owner draw. 
    ///
    ///    </para>
    /// </devdoc>

    [Flags]
    public enum ListViewItemStates {
        /// <include file='doc\ListViewItemStates.uex' path='docs/doc[@for="ListViewItemStates.Checked"]/*' />
        /// <devdoc>
        ///    <para>
        /// [To be supplied.] 
        ///    </para>
        /// </devdoc>
        Checked = NativeMethods.CDIS_CHECKED,

        /// <include file='doc\ListViewItemStates.uex' path='docs/doc[@for="ListViewItemStates.Default"]/*' />
        /// <devdoc>
        ///    <para>
        /// [To be supplied.] 
        ///    </para>
        /// </devdoc>
        Default = NativeMethods.CDIS_DEFAULT,

        /// <include file='doc\ListViewItemStates.uex' path='docs/doc[@for="ListViewItemStates.Focused"]/*' />
        /// <devdoc>
        ///    <para>
        /// [To be supplied.] 
        ///    </para>
        /// </devdoc>
        Focused = NativeMethods.CDIS_FOCUS,

	    /// <include file='doc\ListViewItemStates.uex' path='docs/doc[@for="ListViewItemStates.Grayed"]/*' />
        /// <devdoc>
        ///    <para>
        /// [To be supplied.] 
        ///    </para>
        /// </devdoc>
        Grayed = NativeMethods.CDIS_GRAYED,

	    /// <include file='doc\ListViewItemStates.uex' path='docs/doc[@for="ListViewItemStates.Hot"]/*' />
        /// <devdoc>
        ///    <para>
        /// [To be supplied.] 
        ///    </para>
        /// </devdoc>
        Hot = NativeMethods.CDIS_HOT,

	    /// <include file='doc\ListViewItemStates.uex' path='docs/doc[@for="ListViewItemStates.Indeterminate"]/*' />
        /// <devdoc>
        ///    <para>
        /// [To be supplied.] 
        ///    </para>
        /// </devdoc>
        Indeterminate = NativeMethods.CDIS_INDETERMINATE,

	    /// <include file='doc\ListViewItemStates.uex' path='docs/doc[@for="ListViewItemStates.Marked"]/*' />
        /// <devdoc>
        ///    <para>
        /// [To be supplied.] 
        ///    </para>
        /// </devdoc>
        Marked = NativeMethods.CDIS_MARKED,

	    /// <include file='doc\ListViewItemStates.uex' path='docs/doc[@for="ListViewItemStates.Selected"]/*' />
        /// <devdoc>
        ///    <para>
        /// [To be supplied.] 
        ///    </para>
        /// </devdoc>
        Selected = NativeMethods.CDIS_SELECTED,

	    /// <include file='doc\ListViewItemStates.uex' path='docs/doc[@for="ListViewItemStates.ShowKeyboardCues"]/*' />
        /// <devdoc>
        ///    <para>
        /// [To be supplied.] 
        ///    </para>
        /// </devdoc>
        ShowKeyboardCues = NativeMethods.CDIS_SHOWKEYBOARDCUES
    }
}
