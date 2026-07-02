using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Gaiden.SFML.System;

namespace Gaiden.SFML.Window;

////////////////////////////////////////////////////////////
/// <summary>
/// Give access to the real-time state of sensors
/// </summary>
////////////////////////////////////////////////////////////
public static partial class Sensor
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Sensor types
    /// </summary>
    ////////////////////////////////////////////////////////////
    public enum Type
    {
        /// <summary>Measures the raw acceleration (m/s^2)</summary>
        Accelerometer,

        /// <summary>Measures the raw rotation rates (degrees/s)</summary>
        Gyroscope,

        /// <summary>Measures the ambient magnetic field (micro-teslas)</summary>
        Magnetometer,

        /// <summary>Measures the direction and intensity of gravity, independent of device acceleration (m/s^2)</summary>
        Gravity,

        /// <summary>Measures the direction and intensity of device acceleration, independent of the gravity (m/s^2)</summary>
        UserAcceleration,

        /// <summary>Measures the absolute 3D orientation (degrees)</summary>
        Orientation
    };

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// The total number of sensor types
    /// </summary>
    ////////////////////////////////////////////////////////////
    public static readonly uint Count = (uint)Type.Orientation + 1;

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Check if a sensor is available on the underlying platform
    /// </summary>
    /// <param name="sensor">Sensor to check</param>
    /// <returns>True if the sensor is available, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public static bool IsAvailable(Type sensor) => sfSensor_isAvailable(sensor);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Enable or disable a sensor
    /// </summary>
    /// <param name="sensor">Sensor to check</param>
    /// <param name="enabled">True to enable, false to disable</param>
    ////////////////////////////////////////////////////////////
    public static void SetEnabled(Type sensor, bool enabled) => sfSensor_setEnabled(sensor, enabled);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the current sensor value
    /// </summary>
    /// <param name="sensor">Sensor to check</param>
    /// <returns>The current sensor value</returns>
    ////////////////////////////////////////////////////////////
    public static Vector3f GetValue(Type sensor) => sfSensor_getValue(sensor);

    #region Imports
    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    private static partial bool sfSensor_isAvailable(Type sensor);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfSensor_setEnabled(Type sensor, [MarshalAs(UnmanagedType.Bool)] bool enabled);

    [LibraryImport(CSFML.Window), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial Vector3f sfSensor_getValue(Type sensor);
    #endregion
}
