using Gaiden.SFML.System;

namespace Gaiden.SFML.Window;

////////////////////////////////////////////////////////////
/// <summary>
/// Give access to the real-time state of the touches
/// </summary>
////////////////////////////////////////////////////////////
public static class Touch
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Check if a touch event is currently down
    /// </summary>
    /// <param name="finger">Finger index</param>
    /// <returns>True if the finger is currently touching the screen, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public static bool IsDown(uint finger) => CSFMLWindow.sfTouch_isDown(finger);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// This function returns the current touch position
    /// </summary>
    /// <param name="finger">Finger index</param>
    /// <returns>Current position of the finger</returns>
    ////////////////////////////////////////////////////////////
    public static Vector2i GetPosition(uint finger) => GetPosition(finger, null);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// This function returns the current touch position
    /// relative to the given window
    /// </summary>
    /// <param name="finger">Finger index</param>
    /// <param name="relativeTo">Reference window</param>
    /// <returns>Current position of the finger</returns>
    ////////////////////////////////////////////////////////////
    public static Vector2i GetPosition(uint finger, WindowBase? relativeTo)
    {
        if (relativeTo != null)
        {
            return relativeTo.InternalGetTouchPosition(finger);
        }

        return CSFMLWindow.sfTouch_getPosition(finger, IntPtr.Zero);
    }
}
