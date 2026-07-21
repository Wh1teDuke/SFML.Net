using System.Runtime.InteropServices;

namespace Gaiden.SFML.System;

/// <summary>
/// Allows you to load the sfml dlls from the specified directory
/// <example>
/// <code>
/// var targetPath = new DirectoryInfo(
///     Path.Join(AppContext.BaseDirectory, "lib"));
/// var resolver = CustomLibResolver.With(targetPath);
/// foreach (var type in (ReadOnlySpan{Type})[
///              typeof(CSFMLWindow),
///              typeof(CSFMLGraphics),
///              typeof(CSFMLAudio),
///              typeof(CSFMLSystem)])
///     NativeLibrary.SetDllImportResolver(type.Assembly, resolver);
/// </code>
/// </example>
/// </summary>
public static class CustomLibResolver
{
    /// <summary>
    /// Creates the custom lib resolver pointing to the specified directory
    /// </summary>
    /// <param name="dir">The directory used to search for the DLLs</param>
    /// <returns></returns>
    public static DllImportResolver With(DirectoryInfo dir) =>
        (libraryName, _, _) =>
        {
            var isWin = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            var isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            var isMac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            var fileName = libraryName;

            if ((isLinux || isMac) && !fileName.StartsWith("lib")) 
                fileName = "lib" + fileName;

            if (!Path.HasExtension(fileName))
            {
                if (isWin) fileName += ".dll";
                else if (isLinux) fileName += ".so";
                else if (isMac) fileName += ".dylib";
            }

            var targetPath = Path.Join(dir.FullName, fileName);
            return NativeLibrary.TryLoad(targetPath, out var handle)
                ? handle
                : IntPtr.Zero;
        };
}