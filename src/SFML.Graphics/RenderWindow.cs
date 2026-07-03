using System.Text;
using Gaiden.SFML.Window;
using Gaiden.SFML.System;

namespace Gaiden.SFML.Graphics;

////////////////////////////////////////////////////////////
/// <summary>
/// Simple wrapper for Window that allows easy
/// 2D rendering
/// </summary>
////////////////////////////////////////////////////////////
public class RenderWindow : Window.Window, IRenderTarget
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create the window with default style, state and creation settings
    /// </summary>
    /// <param name="mode">Video mode to use</param>
    /// <param name="title">Title of the window</param>
    ////////////////////////////////////////////////////////////
    public RenderWindow(VideoMode mode, string title) :
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
    public RenderWindow(VideoMode mode, string title, Styles style, State state) :
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
    public RenderWindow(VideoMode mode, string title, Styles style, State state, ContextSettings settings) :
        base(IntPtr.Zero, 0)
    {
        // Copy the string to a null-terminated UTF-32 byte array
        var titleAsUtf32 = Encoding.UTF32.GetBytes(title + '\0');

        unsafe
        {
            fixed (byte* titlePtr = titleAsUtf32)
            {
                CPointer = CSFMLGraphics.sfRenderWindow_createUnicode(mode, (IntPtr)titlePtr, style, state, ref settings);
            }
        }
        Initialize();
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create the window from an existing control with default creation settings
    /// </summary>
    /// <param name="handle">Platform-specific handle of the control</param>
    ////////////////////////////////////////////////////////////
    public RenderWindow(IntPtr handle) :
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
    public RenderWindow(IntPtr handle, ContextSettings settings) :
        base(CSFMLGraphics.sfRenderWindow_createFromHandle(handle, ref settings), 0) => Initialize();

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Close (destroy) the window.
    /// The Window instance remains valid, and you can call
    /// Create to recreate the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public override void Close() => CSFMLGraphics.sfRenderWindow_close(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Tell whether the window is opened (i.e. has been created).
    /// Note that a hidden window (Show(false))
    /// will still return true
    /// </summary>
    /// <returns>True if the window is opened</returns>
    ////////////////////////////////////////////////////////////
    public override bool IsOpen => CSFMLGraphics.sfRenderWindow_isOpen(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Creation settings of the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public override ContextSettings Settings => CSFMLGraphics.sfRenderWindow_getSettings(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Position of the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public override Vector2i Position
    {
        get => CSFMLGraphics.sfRenderWindow_getPosition(CPointer);
        set => CSFMLGraphics.sfRenderWindow_setPosition(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Size of the rendering region of the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public override Vector2u Size
    {
        get => CSFMLGraphics.sfRenderWindow_getSize(CPointer);
        set => CSFMLGraphics.sfRenderWindow_setSize(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Tell if the render window will use sRGB encoding when drawing on it
    /// </summary>
    ////////////////////////////////////////////////////////////
    public bool IsSrgb => CSFMLGraphics.sfRenderWindow_isSrgb(CPointer);

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
                CSFMLGraphics.sfRenderWindow_setMinimumSize(CPointer, &minimumSizeRef);
            }
            else
            {
                CSFMLGraphics.sfRenderWindow_setMinimumSize(CPointer, null);
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
                CSFMLGraphics.sfRenderWindow_setMaximumSize(CPointer, &maximumSizeRef);
            }
            else
            {
                CSFMLGraphics.sfRenderWindow_setMaximumSize(CPointer, null);
            }
        }
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
                CSFMLGraphics.sfRenderWindow_setUnicodeTitle(CPointer, (IntPtr)titlePtr);
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
    public override void SetIcon(Vector2u size, ReadOnlySpan<byte> pixels)
    {
        unsafe
        {
            fixed (byte* pixelsPtr = pixels)
            {
                CSFMLGraphics.sfRenderWindow_setIcon(CPointer, size, pixelsPtr);
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Show or hide the window
    /// </summary>
    /// <param name="visible">True to show the window, false to hide it</param>
    ////////////////////////////////////////////////////////////
    public override void SetVisible(bool visible) => CSFMLGraphics.sfRenderWindow_setVisible(CPointer, visible);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Enable / disable vertical synchronization
    /// </summary>
    /// <param name="enable">True to enable v-sync, false to deactivate</param>
    ////////////////////////////////////////////////////////////
    public override void SetVerticalSyncEnabled(bool enable) => CSFMLGraphics.sfRenderWindow_setVerticalSyncEnabled(CPointer, enable);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Show or hide the mouse cursor
    /// </summary>
    /// <param name="visible">True to show, false to hide</param>
    ////////////////////////////////////////////////////////////
    public override void SetMouseCursorVisible(bool visible) => CSFMLGraphics.sfRenderWindow_setMouseCursorVisible(CPointer, visible);

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
    public override void SetMouseCursorGrabbed(bool grabbed) => CSFMLGraphics.sfRenderWindow_setMouseCursorGrabbed(CPointer, grabbed);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Set the displayed cursor to a native system cursor
    /// </summary>
    /// <param name="cursor">Native system cursor type to display</param>
    ////////////////////////////////////////////////////////////
    public override void SetMouseCursor(Cursor cursor) => CSFMLGraphics.sfRenderWindow_setMouseCursor(CPointer, cursor.CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Enable or disable automatic key-repeat.
    /// Automatic key-repeat is enabled by default
    /// </summary>
    /// <param name="enable">True to enable, false to disable</param>
    ////////////////////////////////////////////////////////////
    public override void SetKeyRepeatEnabled(bool enable) => CSFMLGraphics.sfRenderWindow_setKeyRepeatEnabled(CPointer, enable);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Limit the framerate to a maximum fixed frequency
    /// </summary>
    /// <param name="limit">Framerate limit, in frames per seconds (use 0 to disable limit)</param>
    ////////////////////////////////////////////////////////////
    public override void SetFramerateLimit(uint limit) => CSFMLGraphics.sfRenderWindow_setFramerateLimit(CPointer, limit);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Change the joystick threshold, i.e. the value below which
    /// no move event will be generated
    /// </summary>
    /// <param name="threshold">New threshold, in range [0, 100]</param>
    ////////////////////////////////////////////////////////////
    public override void SetJoystickThreshold(float threshold) => CSFMLGraphics.sfRenderWindow_setJoystickThreshold(CPointer, threshold);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Activate of deactivate the window as the current target
    /// for rendering
    /// </summary>
    /// <param name="active">True to activate, false to deactivate (true by default)</param>
    /// <returns>True if operation was successful, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public override bool SetActive(bool active) => CSFMLGraphics.sfRenderWindow_setActive(CPointer, active);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Request the current window to be made the active
    /// foreground window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public override void RequestFocus() => CSFMLGraphics.sfRenderWindow_requestFocus(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Check whether the window has the input focus
    /// </summary>
    /// <returns>True if the window has focus, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public override bool HasFocus() => CSFMLGraphics.sfRenderWindow_hasFocus(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create a Vulkan rendering surface
    /// </summary>
    /// <param name="vkInstance">Vulkan instance</param>
    /// <param name="vkSurface">Created surface</param>
    /// <param name="vkAllocator">Allocator to use</param>
    /// <returns>True if surface creation was successful, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public override bool CreateVulkanSurface(IntPtr vkInstance, out IntPtr vkSurface, IntPtr vkAllocator) => CSFMLGraphics.sfRenderWindow_createVulkanSurface(CPointer, vkInstance, out vkSurface, vkAllocator);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Display the window on screen
    /// </summary>
    ////////////////////////////////////////////////////////////
    public override void Display() => CSFMLGraphics.sfRenderWindow_display(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// OS-specific handle of the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public override IntPtr NativeHandle => CSFMLGraphics.sfRenderWindow_getNativeHandle(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Clear the entire window with black color
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void Clear() => CSFMLGraphics.sfRenderWindow_clear(CPointer, Color.Black);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Clear the entire window with a single color
    /// </summary>
    /// <param name="color">Color to use to clear the window</param>
    ////////////////////////////////////////////////////////////
    public void Clear(Color color) => CSFMLGraphics.sfRenderWindow_clear(CPointer, color);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Clear the entire target with a single color and stencil value
    /// <para/>
    /// The specified stencil value is truncated to the bit
    /// width of the current stencil buffer.
    /// </summary>
    /// <param name="color">Fill color to use to clear the render target</param>
    /// <param name="stencilValue">Stencil value to clear to</param>
    ////////////////////////////////////////////////////////////
    public void Clear(Color color, StencilValue stencilValue) => CSFMLGraphics.sfRenderWindow_clearColorAndStencil(CPointer, color, stencilValue);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Clear the stencil buffer to a specific value
    /// <para/>
    /// The specified value is truncated to the bit width of
    /// the current stencil buffer.
    /// </summary>
    /// <param name="stencilValue">Stencil value to clear to</param>
    ////////////////////////////////////////////////////////////
    public void ClearStencil(StencilValue stencilValue) => CSFMLGraphics.sfRenderWindow_clearStencil(CPointer, stencilValue);


    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Change the current active view
    /// </summary>
    /// <param name="view">New view</param>
    ////////////////////////////////////////////////////////////
    public void SetView(View view) => CSFMLGraphics.sfRenderWindow_setView(CPointer, view.CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Return the current active view
    /// </summary>
    /// <returns>The current view</returns>
    ////////////////////////////////////////////////////////////
    public View GetView() => new(CSFMLGraphics.sfRenderWindow_getView(CPointer));

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Default view of the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public View DefaultView => new(_defaultView);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the viewport of a view applied to this target
    /// </summary>
    /// <param name="view">Target view</param>
    /// <returns>Viewport rectangle, expressed in pixels in the current target</returns>
    ////////////////////////////////////////////////////////////
    public IntRect GetViewport(View view) => CSFMLGraphics.sfRenderWindow_getViewport(CPointer, view.CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the scissor rectangle of a view, applied to this render target
    /// <para/>
    /// The scissor rectangle is defined in the view as a ratio. This
    /// function simply applies this ratio to the current dimensions
    /// of the render target to calculate the pixels rectangle
    /// that the scissor rectangle actually covers in the target.
    /// </summary>
    /// <param name="view">The view for which we want to compute the scissor rectangle</param>
    /// <returns>Scissor rectangle, expressed in pixels</returns>
    ////////////////////////////////////////////////////////////
    public IntRect GetScissor(View view) => CSFMLGraphics.sfRenderWindow_getScissor(CPointer, view.CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Convert a point from target coordinates to world
    /// coordinates, using the current view
    ///
    /// This function is an overload of the MapPixelToCoords
    /// function that implicitly uses the current view.
    /// It is equivalent to:
    /// target.MapPixelToCoords(point, target.GetView());
    /// </summary>
    /// <param name="point">Pixel to convert</param>
    /// <returns>The converted point, in "world" coordinates</returns>
    ////////////////////////////////////////////////////////////
    public Vector2f MapPixelToCoords(Vector2i point) => MapPixelToCoords(point, GetView());

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Convert a point from target coordinates to world coordinates
    ///
    /// This function finds the 2D position that matches the
    /// given pixel of the render-target. In other words, it does
    /// the inverse of what the graphics card does, to find the
    /// initial position of a rendered pixel.
    ///
    /// Initially, both coordinate systems (world units and target pixels)
    /// match perfectly. But if you define a custom view or resize your
    /// render-target, this assertion is not true anymore, i.e. a point
    /// located at (10, 50) in your render-target may map to the point
    /// (150, 75) in your 2D world -- if the view is translated by (140, 25).
    ///
    /// For render-windows, this function is typically used to find
    /// which point (or object) is located below the mouse cursor.
    ///
    /// This version uses a custom view for calculations, see the other
    /// overload of the function if you want to use the current view of the
    /// render-target.
    /// </summary>
    /// <param name="point">Pixel to convert</param>
    /// <param name="view">The view to use for converting the point</param>
    /// <returns>The converted point, in "world" coordinates</returns>
    ////////////////////////////////////////////////////////////
    public Vector2f MapPixelToCoords(Vector2i point, View view) => CSFMLGraphics.sfRenderWindow_mapPixelToCoords(CPointer, point, view?.CPointer ?? IntPtr.Zero);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Convert a point from world coordinates to target
    /// coordinates, using the current view
    ///
    /// This function is an overload of the mapCoordsToPixel
    /// function that implicitly uses the current view.
    /// It is equivalent to:
    /// target.MapCoordsToPixel(point, target.GetView());
    /// </summary>
    /// <param name="point">Point to convert</param>
    /// <returns>The converted point, in target coordinates (pixels)</returns>
    ////////////////////////////////////////////////////////////
    public Vector2i MapCoordsToPixel(Vector2f point) => MapCoordsToPixel(point, GetView());

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Convert a point from world coordinates to target coordinates
    ///
    /// This function finds the pixel of the render-target that matches
    /// the given 2D point. In other words, it goes through the same process
    /// as the graphics card, to compute the final position of a rendered point.
    ///
    /// Initially, both coordinate systems (world units and target pixels)
    /// match perfectly. But if you define a custom view or resize your
    /// render-target, this assertion is not true anymore, i.e. a point
    /// located at (150, 75) in your 2D world may map to the pixel
    /// (10, 50) of your render-target -- if the view is translated by (140, 25).
    ///
    /// This version uses a custom view for calculations, see the other
    /// overload of the function if you want to use the current view of the
    /// render-target.
    /// </summary>
    /// <param name="point">Point to convert</param>
    /// <param name="view">The view to use for converting the point</param>
    /// <returns>The converted point, in target coordinates (pixels)</returns>
    ////////////////////////////////////////////////////////////
    public Vector2i MapCoordsToPixel(Vector2f point, View view) => CSFMLGraphics.sfRenderWindow_mapCoordsToPixel(CPointer, point, view?.CPointer ?? IntPtr.Zero);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Draw a drawable object to the render-target, with default render states
    /// </summary>
    /// <param name="drawable">Object to draw</param>
    ////////////////////////////////////////////////////////////
    public void Draw(IDrawable drawable) => Draw(drawable, RenderStates.Default);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Draw a drawable object to the render-target
    /// </summary>
    /// <param name="drawable">Object to draw</param>
    /// <param name="states">Render states to use for drawing</param>
    ////////////////////////////////////////////////////////////
    public void Draw(IDrawable drawable, RenderStates states) => drawable.Draw(this, states);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Draw primitives defined by an array of vertices, with default render states
    /// </summary>
    /// <param name="vertices">Pointer to the vertices</param>
    /// <param name="type">Type of primitives to draw</param>
    ////////////////////////////////////////////////////////////
    public void Draw(ReadOnlySpan<Vertex> vertices, PrimitiveType type) => Draw(vertices, type, RenderStates.Default);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Draw primitives defined by a sub-array of vertices
    /// </summary>
    /// <param name="vertices">Pointer to the vertices</param>
    /// <param name="type">Type of primitives to draw</param>
    /// <param name="states">Render states to use for drawing</param>
    ////////////////////////////////////////////////////////////
    public void Draw(ReadOnlySpan<Vertex> vertices, PrimitiveType type, RenderStates states)
    {
        var marshaledStates = states.Marshal();

        unsafe
        {
            fixed (Vertex* vertexPtr = vertices)
            {
                CSFMLGraphics.sfRenderWindow_drawPrimitives(CPointer, vertexPtr, (UIntPtr)vertices.Length, type, ref marshaledStates);
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Save the current OpenGL render states and matrices.
    /// </summary>
    ///
    /// <example>
    /// // OpenGL code here...
    /// window.PushGLStates();
    /// window.Draw(...);
    /// window.Draw(...);
    /// window.PopGLStates();
    /// // OpenGL code here...
    /// </example>
    ///
    /// <remarks>
    /// <para>This function can be used when you mix SFML drawing
    /// and direct OpenGL rendering. Combined with PopGLStates,
    /// it ensures that:</para>
    /// <para>SFML's internal states are not messed up by your OpenGL code</para>
    /// <para>Your OpenGL states are not modified by a call to a SFML function</para>
    ///
    /// <para>More specifically, it must be used around code that
    /// calls Draw functions.</para>
    ///
    /// <para>Note that this function is quite expensive: it saves all the
    /// possible OpenGL states and matrices, even the ones you
    /// don't care about. Therefore, it should be used wisely.
    /// It is provided for convenience, but the best results will
    /// be achieved if you handle OpenGL states yourself (because
    /// you know which states have really changed, and need to be
    /// saved and restored). Take a look at the <seealso cref="ResetGLStates"/>
    /// function if you do so.</para>
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public void PushGLStates() => CSFMLGraphics.sfRenderWindow_pushGLStates(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Restore the previously saved OpenGL render states and matrices.
    ///
    /// See the description of <seealso cref="PushGLStates"/> to get a detailed
    /// description of these functions.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void PopGLStates() => CSFMLGraphics.sfRenderWindow_popGLStates(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Reset the internal OpenGL states so that the target is ready for drawing.
    /// </summary>
    ///
    /// <remarks>
    /// This function can be used when you mix SFML drawing
    /// and direct OpenGL rendering, if you choose not to use
    /// PushGLStates/PopGLStates. It makes sure that all OpenGL
    /// states needed by SFML are set, so that subsequent Draw()
    /// calls will work as expected.
    /// </remarks>
    ///
    /// <example>
    /// // OpenGL code here...
    /// glPushAttrib(...);
    /// window.ResetGLStates();
    /// window.Draw(...);
    /// window.Draw(...);
    /// glPopAttrib(...);
    /// // OpenGL code here...
    /// </example>
    ////////////////////////////////////////////////////////////
    public void ResetGLStates() => CSFMLGraphics.sfRenderWindow_resetGLStates(CPointer);

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

        return "[RenderWindow]" +
               " Size(" + Size + ")" +
               " Position(" + Position + ")" +
               " Settings(" + Settings + ")" +
               " DefaultView(" + DefaultView + ")" +
               " View(" + GetView() + ")";
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to get the next event
    /// </summary>
    /// <param name="eventToFill">Variable to fill with the raw pointer to the event structure</param>
    /// <returns>True if there was an event, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    protected override bool PollEvent(out Event eventToFill) => CSFMLGraphics.sfRenderWindow_pollEvent(CPointer, out eventToFill);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to get the next event (blocking)
    /// </summary>
    /// <param name="timeout">Maximum time to wait (<see cref="Time.Zero"/> for infinite)</param>
    /// <param name="eventToFill">Variable to fill with the raw pointer to the event structure</param>
    /// <returns>False if any error occurred</returns>
    ////////////////////////////////////////////////////////////
    protected override bool WaitEvent(Time timeout, out Event eventToFill) => CSFMLGraphics.sfRenderWindow_waitEvent(CPointer, timeout, out eventToFill);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to get the mouse position relative to the window.
    /// This function is protected because it is called by another class,
    /// it is not meant to be called by users.
    /// </summary>
    /// <returns>Relative mouse position</returns>
    ////////////////////////////////////////////////////////////
    protected override Vector2i InternalGetMousePosition() => CSFMLGraphics.sfMouse_getPositionRenderWindow(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to set the mouse position relative to the window.
    /// This function is protected because it is called by another class,
    /// it is not meant to be called by users.
    /// </summary>
    /// <param name="position">Relative mouse position</param>
    ////////////////////////////////////////////////////////////
    protected override void InternalSetMousePosition(Vector2i position) => CSFMLGraphics.sfMouse_setPositionRenderWindow(position, CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to get the touch position relative to the window.
    /// This function is protected because it is called by another class of
    /// another module, it is not meant to be called by users.
    /// </summary>
    /// <param name="finger">Finger index</param>
    /// <returns>Relative touch position</returns>
    ////////////////////////////////////////////////////////////
    protected override Vector2i InternalGetTouchPosition(uint finger) => CSFMLGraphics.sfTouch_getPositionRenderWindow(finger, CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing)
    {
        CSFMLGraphics.sfRenderWindow_destroy(CPointer);

        if (disposing)
        {
            _defaultView.Dispose();
        }

        _defaultView = null!;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Do common initializations
    /// </summary>
    ////////////////////////////////////////////////////////////
    private void Initialize()
    {
        _defaultView = new View(CSFMLGraphics.sfRenderWindow_getDefaultView(CPointer));
        GC.SuppressFinalize(_defaultView);
    }

    private View _defaultView = null!;
}
