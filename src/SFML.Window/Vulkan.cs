using System.Runtime.InteropServices;

namespace Gaiden.SFML.Window;

/// <summary>Vulkan helper functions</summary>
public static class Vulkan
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Tell whether the system supports Vulkan
    ///
    /// This function should always be called before using
    /// the Vulkan features. If it returns false, then
    /// any attempt to use Vulkan will fail.
    ///
    /// If only compute is required, set <paramref name="requireGraphics"/>
    /// to false to skip checking for the extensions necessary
    /// for graphics rendering.
    /// </summary>
    /// <param name="requireGraphics"> True to skip checking for graphics extensions, false otherwise </param>
    /// <returns>True if Vulkan is supported, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public static bool IsAvailable(bool requireGraphics = true) => CSFMLWindow.sfVulkan_isAvailable(requireGraphics);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the address of a Vulkan function
    /// </summary>
    /// <param name="name"> Name of the function to get the address of </param>
    /// <returns>Address of the Vulkan function, <see cref="nint.Zero"/> on failure</returns>
    ////////////////////////////////////////////////////////////
    public static IntPtr GetFunction(string name) => CSFMLWindow.sfVulkan_getFunction(name);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get Vulkan instance extensions required for graphics
    /// </summary>
    /// <returns>Vulkan instance extensions required for graphics</returns>
    ////////////////////////////////////////////////////////////
    public static string[] GetGraphicsRequiredInstanceExtensions()
    {
        unsafe
        {
            var extensionsPtr = CSFMLWindow.sfVulkan_getGraphicsRequiredInstanceExtensions(out var count);
            var extensions = new string[(int)count];

            for (var i = 0; i < (int)count; ++i)
            {
                extensions[i] = Marshal.PtrToStringAnsi(extensionsPtr[i])!;
            }

            return extensions;
        }
    }
}