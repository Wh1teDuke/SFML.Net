using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace Gaiden.SFML.System;

////////////////////////////////////////////////////////////
/// <summary>
/// Utility class that measures the elapsed time
/// </summary>
////////////////////////////////////////////////////////////
public partial class Clock : ObjectBase
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Default Constructor
    ///
    /// The clock starts automatically after being constructed.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Clock() : base(sfClock_create()) { }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing) => sfClock_destroy(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Gets the time elapsed since the last call to Restart
    /// (or the construction of the instance if Restart
    /// has not been called).
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Time ElapsedTime => sfClock_getElapsedTime(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Check whether the clock is running
    /// </summary>
    ////////////////////////////////////////////////////////////
    public bool IsRunning => sfClock_isRunning(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Start the clock
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void Start() => sfClock_start(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Stop the clock
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void Stop() => sfClock_stop(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// This function puts the time counter back to zero.
    /// </summary>
    /// <returns>Time elapsed since the clock was started.</returns>
    ////////////////////////////////////////////////////////////
    public Time Restart() => sfClock_restart(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Reset the clock
    ///
    /// This function puts the time counter back to zero, returns
    /// the elapsed time, and leaves the clock in a paused state.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Time Reset() => sfClock_reset(CPointer);

    #region Imports
    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfClock_create();

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfClock_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial Time sfClock_getElapsedTime(IntPtr clock);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    private static partial bool sfClock_isRunning(IntPtr clock);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfClock_start(IntPtr clock);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfClock_stop(IntPtr clock);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial Time sfClock_restart(IntPtr clock);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial Time sfClock_reset(IntPtr clock);
    #endregion
}
