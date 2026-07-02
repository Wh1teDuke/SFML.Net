namespace Gaiden.SFML.System;

////////////////////////////////////////////////////////////
/// <summary>
/// Utility class that measures the elapsed time
/// </summary>
////////////////////////////////////////////////////////////
public class Clock : ObjectBase
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Default Constructor
    ///
    /// The clock starts automatically after being constructed.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Clock() : base(CSFMLSystem.sfClock_create()) { }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing) => CSFMLSystem.sfClock_destroy(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Gets the time elapsed since the last call to Restart
    /// (or the construction of the instance if Restart
    /// has not been called).
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Time ElapsedTime => CSFMLSystem.sfClock_getElapsedTime(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Check whether the clock is running
    /// </summary>
    ////////////////////////////////////////////////////////////
    public bool IsRunning => CSFMLSystem.sfClock_isRunning(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Start the clock
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void Start() => CSFMLSystem.sfClock_start(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Stop the clock
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void Stop() => CSFMLSystem.sfClock_stop(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// This function puts the time counter back to zero.
    /// </summary>
    /// <returns>Time elapsed since the clock was started.</returns>
    ////////////////////////////////////////////////////////////
    public Time Restart() => CSFMLSystem.sfClock_restart(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Reset the clock
    ///
    /// This function puts the time counter back to zero, returns
    /// the elapsed time, and leaves the clock in a paused state.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Time Reset() => CSFMLSystem.sfClock_reset(CPointer);
}
