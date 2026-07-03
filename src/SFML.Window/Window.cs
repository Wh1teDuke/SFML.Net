using System.Text;
using Gaiden.SFML.System;

namespace Gaiden.SFML.Window;

////////////////////////////////////////////////////////////
/// <summary>
/// Window that serves as a target for OpenGL rendering
/// </summary>
////////////////////////////////////////////////////////////
public class Window : WindowBase
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create the window with default style and creation settings
    /// </summary>
    /// <param name="mode">Video mode to use</param>
    /// <param name="title">Title of the window</param>
    ////////////////////////////////////////////////////////////
    public Window(VideoMode mode, string title) :
        this(mode, title, Styles.Default, State.Windowed, new ContextSettings(0, 0))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create the window with default creation settings
    /// </summary>
    /// <param name="mode">Video mode to use</param>
    /// <param name="title">Title of the window</param>
    /// <param name="style">Window style (Resize | Close by default)</param>
    /// <param name="state">Window state</param>
    ////////////////////////////////////////////////////////////
    public Window(VideoMode mode, string title, Styles style, State state) :
        this(mode, title, style, state, new ContextSettings(0, 0))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create the window
    /// </summary>
    /// <param name="mode">Video mode to use</param>
    /// <param name="title">Title of the window</param>
    /// <param name="style">Window style (Resize | Close by default)</param>
    /// <param name="state">Window state</param>
    /// <param name="settings">Creation parameters</param>
    ////////////////////////////////////////////////////////////
    public Window(VideoMode mode, string title, Styles style, State state, ContextSettings settings) :
        base(IntPtr.Zero)
    {
        // Copy the title to a null-terminated UTF-32 byte array
        var titleAsUtf32 = Encoding.UTF32.GetBytes(title + '\0');

        unsafe
        {
            fixed (byte* titlePtr = titleAsUtf32)
            {
                CPointer = CSFMLWindow.sfWindow_createUnicode(mode, (IntPtr)titlePtr, style, state, ref settings);
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create the window from an existing control with default creation settings
    /// </summary>
    /// <param name="handle">Platform-specific handle of the control</param>
    ////////////////////////////////////////////////////////////
    public Window(IntPtr handle) :
        this(handle, new ContextSettings(0, 0))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create the window from an existing control
    /// </summary>
    /// <param name="handle">Platform-specific handle of the control</param>
    /// <param name="settings">Creation parameters</param>
    ////////////////////////////////////////////////////////////
    public Window(IntPtr handle, ContextSettings settings) :
        base(CSFMLWindow.sfWindow_createFromHandle(handle, ref settings))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Tell whether the window is opened (i.e. has been created).
    /// Note that a hidden window (Show(false))
    /// will still return true
    /// </summary>
    /// <returns>True if the window is opened</returns>
    ////////////////////////////////////////////////////////////
    public override bool IsOpen => CSFMLWindow.sfWindow_isOpen(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Close (destroy) the window.
    /// The Window instance remains valid, and you can call
    /// Create to recreate the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public override void Close() => CSFMLWindow.sfWindow_close(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Display the window on screen
    /// </summary>
    ////////////////////////////////////////////////////////////
    public virtual void Display() => CSFMLWindow.sfWindow_display(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Creation settings of the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public virtual ContextSettings Settings => CSFMLWindow.sfWindow_getSettings(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Position of the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public override Vector2i Position
    {
        get => CSFMLWindow.sfWindow_getPosition(CPointer);
        set => CSFMLWindow.sfWindow_setPosition(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Size of the rendering region of the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public override Vector2u Size
    {
        get => CSFMLWindow.sfWindow_getSize(CPointer);
        set => CSFMLWindow.sfWindow_setSize(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Change the title of the window
    /// </summary>
    /// <param name="title">New title</param>
    ////////////////////////////////////////////////////////////
    public override void SetTitle(string title)
    {
        // Copy the title to a null-terminated UTF-32 byte array
        var titleAsUtf32 = Encoding.UTF32.GetBytes(title + '\0');

        unsafe
        {
            fixed (byte* titlePtr = titleAsUtf32)
            {
                CSFMLWindow.sfWindow_setUnicodeTitle(CPointer, (IntPtr)titlePtr);
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Set the minimum window rendering region size
    /// </summary>
    /// <param name="minimumSize">New minimum size, in pixels, null to reset the minimum size</param>
    ////////////////////////////////////////////////////////////
    public override void SetMinimumSize(Vector2u? minimumSize)
    {
        unsafe
        {
            if (minimumSize.HasValue)
            {
                var minimumSizeRef = minimumSize.Value;
                CSFMLWindow.sfWindow_setMinimumSize(CPointer, &minimumSizeRef);
            }
            else
            {
                CSFMLWindow.sfWindow_setMinimumSize(CPointer, null);
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Set the maximum window rendering region size
    /// </summary>
    /// <param name="maximumSize">New maximum size, in pixels, null to reset the maximum size</param>
    ////////////////////////////////////////////////////////////
    public override void SetMaximumSize(Vector2u? maximumSize)
    {
        unsafe
        {
            if (maximumSize.HasValue)
            {
                var maximumSizeRef = maximumSize.Value;
                CSFMLWindow.sfWindow_setMaximumSize(CPointer, &maximumSizeRef);
            }
            else
            {
                CSFMLWindow.sfWindow_setMaximumSize(CPointer, null);
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Change the window's icon
    /// </summary>
    /// <param name="size">Icon's width and height, in pixels</param>
    /// <param name="pixels">Array of pixels, format must be RGBA 32 bits</param>
    ////////////////////////////////////////////////////////////
    public override void SetIcon(Vector2u size, byte[] pixels)
    {
        unsafe
        {
            fixed (byte* pixelsPtr = pixels)
            {
                CSFMLWindow.sfWindow_setIcon(CPointer, size, pixelsPtr);
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Show or hide the window
    /// </summary>
    /// <param name="visible">True to show the window, false to hide it</param>
    ////////////////////////////////////////////////////////////
    public override void SetVisible(bool visible) => CSFMLWindow.sfWindow_setVisible(CPointer, visible);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Show or hide the mouse cursor
    /// </summary>
    /// <param name="visible"></param>
    ////////////////////////////////////////////////////////////
    public override void SetMouseCursorVisible(bool visible) => CSFMLWindow.sfWindow_setMouseCursorVisible(CPointer, visible);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Grab or release the mouse cursor
    /// </summary>
    /// <param name="grabbed">True to grab, false to release</param>
    ///
    /// <remarks>
    /// If set, grabs the mouse cursor inside this window's client
    /// area so it may no longer be moved outside its bounds.
    /// Note that grabbing is only active while the window has
    /// focus and calling this function for fullscreen windows
    /// won't have any effect (fullscreen windows always grab the
    /// cursor).
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public override void SetMouseCursorGrabbed(bool grabbed) => CSFMLWindow.sfWindow_setMouseCursorGrabbed(CPointer, grabbed);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Set the displayed cursor to a native system cursor
    /// </summary>
    /// <param name="cursor">Native system cursor type to display</param>
    ////////////////////////////////////////////////////////////
    public override void SetMouseCursor(Cursor cursor) => CSFMLWindow.sfWindow_setMouseCursor(CPointer, cursor.CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Enable / disable vertical synchronization
    /// </summary>
    /// <param name="enable">True to enable v-sync, false to deactivate</param>
    ////////////////////////////////////////////////////////////
    public virtual void SetVerticalSyncEnabled(bool enable) => CSFMLWindow.sfWindow_setVerticalSyncEnabled(CPointer, enable);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Enable or disable automatic key-repeat.
    /// Automatic key-repeat is enabled by default
    /// </summary>
    /// <param name="enable">True to enable, false to disable</param>
    ////////////////////////////////////////////////////////////
    public override void SetKeyRepeatEnabled(bool enable) => CSFMLWindow.sfWindow_setKeyRepeatEnabled(CPointer, enable);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Activate the window as the current target
    /// for rendering
    /// </summary>
    /// <returns>True if operation was successful, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public virtual bool SetActive() => SetActive(true);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Activate of deactivate the window as the current target
    /// for rendering
    /// </summary>
    /// <param name="active">True to activate, false to deactivate (true by default)</param>
    /// <returns>True if operation was successful, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public virtual bool SetActive(bool active) => CSFMLWindow.sfWindow_setActive(CPointer, active);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Limit the framerate to a maximum fixed frequency
    /// </summary>
    /// <param name="limit">Framerate limit, in frames per seconds (use 0 to disable limit)</param>
    ////////////////////////////////////////////////////////////
    public virtual void SetFramerateLimit(uint limit) => CSFMLWindow.sfWindow_setFramerateLimit(CPointer, limit);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Change the joystick threshold, i.e. the value below which
    /// no move event will be generated
    /// </summary>
    /// <param name="threshold">New threshold, in range [0, 100]</param>
    ////////////////////////////////////////////////////////////
    public override void SetJoystickThreshold(float threshold) => CSFMLWindow.sfWindow_setJoystickThreshold(CPointer, threshold);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// OS-specific handle of the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public override IntPtr NativeHandle => CSFMLWindow.sfWindow_getNativeHandle(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Request the current window to be made the active
    /// foreground window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public override void RequestFocus() => CSFMLWindow.sfWindow_requestFocus(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Check whether the window has the input focus
    /// </summary>
    /// <returns>True if the window has focus, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public override bool HasFocus() => CSFMLWindow.sfWindow_hasFocus(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create a Vulkan rendering surface
    /// </summary>
    /// <param name="vkInstance">Vulkan instance</param>
    /// <param name="vkSurface">Created surface</param>
    /// <param name="vkAllocator">Allocator to use</param>
    /// <returns>True if surface creation was successful, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public override bool CreateVulkanSurface(IntPtr vkInstance, out IntPtr vkSurface, IntPtr vkAllocator) => CSFMLWindow.sfWindow_createVulkanSurface(CPointer, vkInstance, out vkSurface, vkAllocator);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Provide a string describing the object
    /// </summary>
    /// <returns>String description of the object</returns>
    ////////////////////////////////////////////////////////////
    public override string ToString()
    {
        if (IsInvalid)
        {
            return MakeDisposedObjectString();
        }

        return "[Window]" +
               " Size(" + Size + ")" +
               " Position(" + Position + ")" +
               " Settings(" + Settings + ")";
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Constructor for derived classes
    /// </summary>
    /// <param name="cPointer">Pointer to the internal object in the C API</param>
    /// <param name="dummy">Internal hack :)</param>
    ////////////////////////////////////////////////////////////
    protected Window(IntPtr cPointer, int dummy) :
        base(cPointer, 0)
    {
        // TODO : find a cleaner way of separating this constructor from Window(IntPtr handle)
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to get the mouse position relative to the window.
    /// This function is protected because it is called by another class of
    /// another module, it is not meant to be called by users.
    /// </summary>
    /// <returns>Relative mouse position</returns>
    ////////////////////////////////////////////////////////////
    protected internal override Vector2i InternalGetMousePosition() => CSFMLWindow.sfMouse_getPosition(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to set the mouse position relative to the window.
    /// This function is protected because it is called by another class of
    /// another module, it is not meant to be called by users.
    /// </summary>
    /// <param name="position">Relative mouse position</param>
    ////////////////////////////////////////////////////////////
    protected internal override void InternalSetMousePosition(Vector2i position) => CSFMLWindow.sfMouse_setPosition(position, CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to get the touch position relative to the window.
    /// This function is protected because it is called by another class of
    /// another module, it is not meant to be called by users.
    /// </summary>
    /// <param name="finger">Finger index</param>
    /// <returns>Relative touch position</returns>
    ////////////////////////////////////////////////////////////
    protected internal override Vector2i InternalGetTouchPosition(uint finger) => CSFMLWindow.sfTouch_getPosition(finger, CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to get the next event (non-blocking)
    /// </summary>
    /// <param name="eventToFill">Variable to fill with the raw pointer to the event structure</param>
    /// <returns>True if there was an event, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    protected override bool PollEvent(out Event eventToFill) => CSFMLWindow.sfWindow_pollEvent(CPointer, out eventToFill);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to get the next event (blocking)
    /// </summary>
    /// <param name="timeout">Maximum time to wait (<see cref="Time.Zero"/> for infinite)</param>
    /// <param name="eventToFill">Variable to fill with the raw pointer to the event structure</param>
    /// <returns>False if any error occurred</returns>
    ////////////////////////////////////////////////////////////
    protected override bool WaitEvent(Time timeout, out Event eventToFill) => CSFMLWindow.sfWindow_waitEvent(CPointer, timeout, out eventToFill);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing) => CSFMLWindow.sfWindow_destroy(CPointer);
}
