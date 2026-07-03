using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Gaiden.SFML.System;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Gaiden.SFML.Window;

public static partial class CSFMLWindow
{
    #region WindowBase
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfWindowBase_createUnicode(VideoMode mode, IntPtr title, Styles style, State state);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfWindowBase_createFromHandle(IntPtr handle);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindowBase_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindowBase_close(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfWindowBase_isOpen(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfWindowBase_pollEvent(IntPtr cPointer, out Event evt);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfWindowBase_waitEvent(IntPtr cPointer, Time timeout, out Event evt);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2i sfWindowBase_getPosition(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindowBase_setPosition(IntPtr cPointer, Vector2i position);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2u sfWindowBase_getSize(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindowBase_setSize(IntPtr cPointer, Vector2u size);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfWindowBase_setMinimumSize(IntPtr cPointer, Vector2u* minimumSize);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfWindowBase_setMaximumSize(IntPtr cPointer, Vector2u* maximumSize);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindowBase_setUnicodeTitle(IntPtr cPointer, IntPtr title);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfWindowBase_setIcon(IntPtr cPointer, Vector2u size, byte* pixels);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindowBase_setVisible(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindowBase_setMouseCursorVisible(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool show);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindowBase_setMouseCursorGrabbed(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool grabbed);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindowBase_setMouseCursor(IntPtr cPointer, IntPtr cursor);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindowBase_setKeyRepeatEnabled(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool enable);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindowBase_setJoystickThreshold(IntPtr cPointer, float threshold);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindowBase_requestFocus(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfWindowBase_hasFocus(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfWindowBase_getNativeHandle(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfWindowBase_createVulkanSurface(IntPtr cPointer, IntPtr vkInstance, out IntPtr surface, IntPtr vkAllocator);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2i sfMouse_getPositionWindowBase(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMouse_setPositionWindowBase(Vector2i position, IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2i sfTouch_getPositionWindowBase(uint finger, IntPtr relativeTo);
    #endregion
    
    #region Window
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfWindow_createUnicode(VideoMode mode, IntPtr title, Styles style, State state, ref ContextSettings settings);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfWindow_createFromHandle(IntPtr handle, ref ContextSettings settings);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfWindow_isOpen(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_close(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfWindow_pollEvent(IntPtr cPointer, out Event evt);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfWindow_waitEvent(IntPtr cPointer, Time timeout, out Event evt);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_display(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ContextSettings sfWindow_getSettings(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2i sfWindow_getPosition(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_setPosition(IntPtr cPointer, Vector2i position);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2u sfWindow_getSize(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_setSize(IntPtr cPointer, Vector2u size);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfWindow_setMinimumSize(IntPtr cPointer, Vector2u* minimumSize);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfWindow_setMaximumSize(IntPtr cPointer, Vector2u* maximumSize);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_setUnicodeTitle(IntPtr cPointer, IntPtr title);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfWindow_setIcon(IntPtr cPointer, Vector2u size, byte* pixels);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_setVisible(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_setMouseCursorVisible(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool show);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_setMouseCursorGrabbed(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool grabbed);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_setMouseCursor(IntPtr cPointer, IntPtr cursor);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_setVerticalSyncEnabled(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool enable);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_setKeyRepeatEnabled(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool enable);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfWindow_setActive(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool active);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_setFramerateLimit(IntPtr cPointer, uint limit);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_setJoystickThreshold(IntPtr cPointer, float threshold);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfWindow_getNativeHandle(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfWindow_requestFocus(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfWindow_hasFocus(IntPtr cPointer);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfWindow_createVulkanSurface(IntPtr cPointer, IntPtr vkInstance, out IntPtr surface, IntPtr vkAllocator);
    #endregion

    #region Vulkan
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfVulkan_isAvailable([MarshalAs(UnmanagedType.Bool)] bool requireGraphics);

    [LibraryImport(CSFML.Window, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfVulkan_getFunction(string name);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial IntPtr* sfVulkan_getGraphicsRequiredInstanceExtensions(out UIntPtr count);
    #endregion

    #region VideoMode
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial VideoMode sfVideoMode_getDesktopMode();

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial VideoMode* sfVideoMode_getFullscreenModes(out UIntPtr count);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfVideoMode_isValid(VideoMode mode);
    #endregion

    #region Touch
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfTouch_isDown(uint finger);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2i sfTouch_getPosition(uint finger, IntPtr relativeTo);
    #endregion

    #region Sensor
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfSensor_isAvailable(Sensor.Type sensor);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSensor_setEnabled(Sensor.Type sensor, [MarshalAs(UnmanagedType.Bool)] bool enabled);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfSensor_getValue(Sensor.Type sensor);
    #endregion

    #region Mouse
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfMouse_isButtonPressed(Mouse.Button button);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2i sfMouse_getPosition(IntPtr relativeTo);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMouse_setPosition(Vector2i position, IntPtr relativeTo);
    #endregion
    
    #region Keyboard
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfKeyboard_isKeyPressed(Keyboard.Key key);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfKeyboard_isScancodePressed(Keyboard.Scancode code);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Keyboard.Key sfKeyboard_localize(Keyboard.Scancode code);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Keyboard.Scancode sfKeyboard_delocalize(Keyboard.Key key);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfKeyboard_getDescription(Keyboard.Scancode code);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfKeyboard_setVirtualKeyboardVisible([MarshalAs(UnmanagedType.Bool)] bool visible);
    #endregion
    
    #region Joystick
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfJoystick_isConnected(uint joystick);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfJoystick_getButtonCount(uint joystick);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfJoystick_hasAxis(uint joystick, Joystick.Axis axis);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfJoystick_isButtonPressed(uint joystick, uint button);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfJoystick_getAxisPosition(uint joystick, Joystick.Axis axis);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfJoystick_update();

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Joystick.IdentificationMarshalData sfJoystick_getIdentification(uint joystick);
    #endregion
    
    #region Cursor
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfCursor_createFromSystem(Cursor.CursorType type);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfCursor_createFromPixels(IntPtr pixels, Vector2u size, Vector2u hotspot);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfCursor_destroy(IntPtr cPointer);
    #endregion

    #region Context
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfContext_create();

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfContext_destroy(IntPtr view);

    [LibraryImport(CSFML.Window, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfContext_isExtensionAvailable(string name);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfContext_setActive(IntPtr view, [MarshalAs(UnmanagedType.Bool)] bool active);

    [LibraryImport(CSFML.Window, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfContext_getFunction(string name);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ContextSettings sfContext_getSettings(IntPtr view);
    #endregion
    
    #region Clipboard
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfClipboard_getUnicodeString();

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfClipboard_setUnicodeString(IntPtr ptr);
    #endregion
}