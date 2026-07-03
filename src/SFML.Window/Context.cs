using System.Runtime.ConstrainedExecution;

// TODO getActiveContext
// TODO getActiveContextId

namespace Gaiden.SFML.Window;

//////////////////////////////////////////////////////////////////
/// <summary>
/// This class defines a .NET interface to an SFML OpenGL Context
/// </summary>
//////////////////////////////////////////////////////////////////
public sealed class Context : CriticalFinalizerObject
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Default constructor
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Context() => _this = CSFMLWindow.sfContext_create();

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Finalizer
    /// </summary>
    ////////////////////////////////////////////////////////////
    ~Context() => CSFMLWindow.sfContext_destroy(_this);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Check whether a given OpenGL extension is available.
    /// </summary>
    /// <param name="name">Name of the extension to check for</param>
    /// <returns>True if available, false if unavailable</returns>
    ////////////////////////////////////////////////////////////
    public static bool IsExtensionAvailable(string name) => CSFMLWindow.sfContext_isExtensionAvailable(name);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Activate or deactivate the context
    /// </summary>
    /// <param name="active">True to activate, false to deactivate</param>
    /// <returns>True on success, false on failure</returns>
    ////////////////////////////////////////////////////////////
    public bool SetActive(bool active) => CSFMLWindow.sfContext_setActive(_this, active);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the address of an OpenGL function.
    /// </summary>
    /// <param name="name">Name of the function to get the address of</param>
    /// <returns>Address of the OpenGL function, <see cref="nint.Zero"/> on failure</returns>
    ////////////////////////////////////////////////////////////
    public static IntPtr GetFunction(string name) => CSFMLWindow.sfContext_getFunction(name);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the settings of the context.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public ContextSettings Settings => CSFMLWindow.sfContext_getSettings(_this);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Global helper context
    /// </summary>
    ////////////////////////////////////////////////////////////
    public static Context Global
    {
        get
        {
            field ??= new Context();
            return field;
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Provide a string describing the object
    /// </summary>
    /// <returns>String description of the object</returns>
    ////////////////////////////////////////////////////////////
    public override string ToString() => "[Context]";

    private readonly IntPtr _this = IntPtr.Zero;
}
