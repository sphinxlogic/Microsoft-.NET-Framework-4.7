using System;
using System.Security;
using System.Security.Permissions;
using MS.Internal;
using MS.Win32;
using System.Windows;

namespace System.Windows.Input
{
    /// <summary>
    ///     The RawAppCommandInputReport class encapsulates the raw input provided from WM_APPCOMMAND message.
    ///     This WM_APPCOMMAND message gets generated when the DefWindowProc processes the WM_XBUTTONUP or 
    ///     WM_NCXBUTTONUP message, or when the user types an application command key.
    ///     
    /// </summary>
    /// <remarks>
    ///     It is important to note that the InputReport class only contains
    ///     blittable types.  This is required so that the report can be marshalled across application domains.
    /// 
    ///     To get the coordinates of the cursor if the message was generated 
    ///     by a button click on the mouse, the application can call GetMessagePos. 
    ///     An application can test whether the message was generated by the mouse by checking whether Device contains FAPPCOMMAND_MOUSE.
    ///     Unlike other windows messages, an application should return TRUE from this message if it processes it. 
    /// </remarks>
    internal class RawAppCommandInputReport : InputReport
    {
        /// <summary>
        ///     Constructs ad instance of the RawAppCommandInputReport class.
        /// </summary>
        /// <param name="inputSource">
        ///     The input source that provided this input.
        /// </param>
        /// <param name="mode">
        ///     The mode in which the input is being provided.
        /// </param>
        /// <param name="timestamp">
        ///     The time when the input occured.
        /// </param>
        /// <param name="appCommand">
        ///     The Application Command associated.
        /// </param>
        /// <param name="device">
        ///     The device that generated the app command.
        /// </param>
        /// <param name="inputType">the input device that generated the input event</param>
        internal RawAppCommandInputReport(
            PresentationSource  inputSource,
            InputMode           mode,
            int                 timestamp,
            int                 appCommand,
            InputType           device,
            InputType           inputType) : base(inputSource, inputType, mode, timestamp)
        {
            _appCommand = appCommand;
            _device = device;
        }

        /// <summary>
        ///     Read-only access to the AppCommand that was reported.
        /// </summary>
        internal int AppCommand { get { return _appCommand; } }

        /// <summary>
        /// Read-only access to the device that generated the AppCommand
        /// </summary>
        internal InputType Device
        {
            get
            {
                return _device;
            }
        }

        private int _appCommand;
        private InputType _device;
    }
}
