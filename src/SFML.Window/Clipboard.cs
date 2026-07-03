using System.Text;

namespace Gaiden.SFML.Window;

/// <summary>
/// Clipboard provides an interface for getting and setting the contents of the system clipboard.
/// </summary>
public static class Clipboard
{
    /// <summary>
    /// The contents of the Clipboard as a UTF-32 string
    /// </summary>
    public static string Contents // TODO: StringBuilder/Span<char> overloads for anything related to strings
    {
        get
        {
            var source = CSFMLWindow.sfClipboard_getUnicodeString();

            uint length = 0;
            unsafe
            {
                for (var ptr = (uint*)source.ToPointer(); *ptr != 0; ++ptr)
                {
                    length++;
                }
            }

            // Convert it to a C# string
            unsafe
            {
                return Encoding.UTF32.GetString((byte*)source, (int)(length * 4));
            }
        }
        set
        {
            var utf32 = Encoding.UTF32.GetBytes(value + '\0');

            unsafe
            {
                fixed (byte* ptr = utf32)
                {
                    CSFMLWindow.sfClipboard_setUnicodeString((IntPtr)ptr);
                }
            }
        }
    }
}
