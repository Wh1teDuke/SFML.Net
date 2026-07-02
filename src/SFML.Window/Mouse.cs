using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Gaiden.SFML.System;

namespace Gaiden.SFML.Window;

////////////////////////////////////////////////////////////
/// <summary>
/// Give access to the real-time state of the mouse
/// </summary>
////////////////////////////////////////////////////////////
public static partial class Mouse
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Mouse buttons
    /// </summary>
    ////////////////////////////////////////////////////////////
    public enum Button
    {
        /// <summary>The left mouse button</summary>
        Left,

        /// <summary>The right mouse button</summary>
        Right,

        /// <summary>The middle (wheel) mouse button</summary>
        Middle,

        /// <summary>The first extra mouse button</summary>
        Extra1,

        /// <summary>The second extra mouse button</summary>
        Extra2
    };

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// The total number of mouse buttons
    /// </summary>
    ////////////////////////////////////////////////////////////
    public static readonly uint ButtonCount = (uint)Button.Extra2 + 1;

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Mouse wheels
    /// </summary>
    ////////////////////////////////////////////////////////////
    public enum Wheel
    {
        /// <summary>The vertical mouse wheel</summary>
        Vertical,

        /// <summary>The horizontal mouse wheel</summary>
        Horizontal
    };

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Check if a mouse button is pressed
    /// </summary>
    /// <param name="button">Button to check</param>
    /// <returns>True if the button is pressed, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public static bool IsButtonPressed(Button button) => sfMouse_isButtonPressed(button);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the current position of the mouse
    /// </summary>
    /// This function returns the current position of the mouse
    /// cursor in desktop coordinates.
    /// <returns>Current position of the mouse</returns>
    ////////////////////////////////////////////////////////////
    public static Vector2i GetPosition() => GetPosition(null);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the current position of the mouse
    /// </summary>
    /// This function returns the current position of the mouse
    /// cursor relative to a window.
    /// <param name="relativeTo">Reference window</param>
    /// <returns>Current position of the mouse</returns>
    ////////////////////////////////////////////////////////////
    public static Vector2i GetPosition(WindowBase? relativeTo)
    {
        if (relativeTo != null)
        {
            return relativeTo.InternalGetMousePosition();
        }
        else
        {
            return sfMouse_getPosition(IntPtr.Zero);
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Set the current position of the mouse
    /// </summary>
    /// This function sets the current position of the mouse
    /// cursor in desktop coordinates.
    /// <param name="position">New position of the mouse</param>
    ////////////////////////////////////////////////////////////
    public static void SetPosition(Vector2i position) => SetPosition(position, null);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Set the current position of the mouse
    /// </summary>
    /// This function sets the current position of the mouse
    /// cursor relative to a window.
    /// <param name="position">New position of the mouse</param>
    /// <param name="relativeTo">Reference window</param>
    ////////////////////////////////////////////////////////////
    public static void SetPosition(Vector2i position, WindowBase? relativeTo)
    {
        if (relativeTo != null)
        {
            relativeTo.InternalSetMousePosition(position);
        }
        else
        {
            sfMouse_setPosition(position, IntPtr.Zero);
        }
    }

    #region Imports
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    private static partial bool sfMouse_isButtonPressed(Button button);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial Vector2i sfMouse_getPosition(IntPtr relativeTo);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfMouse_setPosition(Vector2i position, IntPtr relativeTo);
    #endregion
}
