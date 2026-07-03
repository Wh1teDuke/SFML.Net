using System.Runtime.InteropServices;
using Gaiden.SFML.Window;
using Gaiden.SFML.System;
using LoadingFailedException = Gaiden.SFML.Window.LoadingFailedException;

namespace Gaiden.SFML.Graphics;

////////////////////////////////////////////////////////////
/// <summary>
/// Font is the low-level class for loading and
/// manipulating character fonts. This class is meant to
/// be used by Text.
/// </summary>
////////////////////////////////////////////////////////////
public class Font : ObjectBase
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the font from a file
    /// </summary>
    /// <param name="filename">Font file to load</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Font(string filename) : base(CSFMLGraphics.sfFont_createFromFile(filename))
    {
        if (IsInvalid)
        {
            throw new LoadingFailedException("font", filename);
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the font from a custom stream
    /// </summary>
    /// <param name="stream">Source stream to read from</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Font(Stream stream) : base(IntPtr.Zero)
    {
        // Stream needs to stay alive as long as the Font instance is alive
        // Disposing of it can only be done in Font's Dispose method
        _myStream = new StreamAdaptor(stream);
        CPointer = CSFMLGraphics.sfFont_createFromStream(_myStream.InputStreamPtr);

        if (IsInvalid)
        {
            throw new LoadingFailedException("font");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the font from a file in memory
    /// </summary>
    /// <param name="bytes">Byte array containing the file contents</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Font(byte[] bytes) :
        base(IntPtr.Zero)
    {
        // Memory needs to stay pinned as long as the Font instance is alive
        // Freeing the handle can only be done in Font's Dispose method
        _myBytesPin = GCHandle.Alloc(bytes, GCHandleType.Pinned);
        CPointer = CSFMLGraphics.sfFont_createFromMemory(_myBytesPin.AddrOfPinnedObject(), (UIntPtr)bytes.Length);

        if (IsInvalid)
        {
            _myBytesPin.Free();
            throw new LoadingFailedException("font");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the font from another font
    /// </summary>
    /// <param name="copy">Font to copy</param>
    ////////////////////////////////////////////////////////////
    public Font(Font copy) : base(CSFMLGraphics.sfFont_copy(copy.CPointer)) { }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get a glyph in the font
    /// </summary>
    /// <param name="codePoint">Unicode code point of the character to get</param>
    /// <param name="characterSize">Character size</param>
    /// <param name="bold">Retrieve the bold version or the regular one?</param>
    /// <param name="outlineThickness">Thickness of outline (when != 0 the glyph will not be filled)</param>
    /// <returns>The glyph corresponding to the character</returns>
    ////////////////////////////////////////////////////////////
    public Glyph GetGlyph(uint codePoint, uint characterSize, bool bold, float outlineThickness) => CSFMLGraphics.sfFont_getGlyph(CPointer, codePoint, characterSize, bold, outlineThickness);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Determine if this font has a glyph representing the requested code point
    /// <para/>
    /// Most fonts only include a very limited selection of glyphs from
    /// specific Unicode subsets, like Latin, Cyrillic, or Asian characters.
    /// <para/>
    /// While code points without representation will return a font specific
    /// default character, it might be useful to verify whether specific
    /// code points are included to determine whether a font is suited
    /// to display text in a specific language.
    /// </summary>
    /// <param name="codePoint">Unicode code point to check</param>
    /// <returns>True if the codepoint has a glyph representation, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public bool HasGlyph(uint codePoint) => CSFMLGraphics.sfFont_hasGlyph(CPointer, codePoint);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the kerning value corresponding to a given pair of
    /// characters in a font
    /// </summary>
    /// <param name="first">Unicode code point of the first character</param>
    /// <param name="second">Unicode code point of the second character</param>
    /// <param name="characterSize">Character size, in pixels</param>
    /// <returns>Kerning offset, in pixels</returns>
    ////////////////////////////////////////////////////////////
    public float GetKerning(uint first, uint second, uint characterSize) => CSFMLGraphics.sfFont_getKerning(CPointer, first, second, characterSize);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the bold kerning value corresponding to a given pair
    /// of characters in a font
    /// </summary>
    /// <param name="first">Unicode code point of the first character</param>
    /// <param name="second">Unicode code point of the second character</param>
    /// <param name="characterSize">Character size, in pixels</param>
    /// <returns>Kerning offset, in pixels</returns>
    ////////////////////////////////////////////////////////////
    public float GetBoldKerning(uint first, uint second, uint characterSize) => CSFMLGraphics.sfFont_getBoldKerning(CPointer, first, second, characterSize);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get spacing between two consecutive lines
    /// </summary>
    /// <param name="characterSize">Character size</param>
    /// <returns>Line spacing, in pixels</returns>
    ////////////////////////////////////////////////////////////
    public float GetLineSpacing(uint characterSize) => CSFMLGraphics.sfFont_getLineSpacing(CPointer, characterSize);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the position of the underline
    /// </summary>
    /// <param name="characterSize">Character size</param>
    /// <returns>Underline position, in pixels</returns>
    ////////////////////////////////////////////////////////////
    public float GetUnderlinePosition(uint characterSize) => CSFMLGraphics.sfFont_getUnderlinePosition(CPointer, characterSize);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the thickness of the underline
    /// </summary>
    /// <param name="characterSize">Character size</param>
    /// <returns>Underline thickness, in pixels</returns>
    ////////////////////////////////////////////////////////////
    public float GetUnderlineThickness(uint characterSize) => CSFMLGraphics.sfFont_getUnderlineThickness(CPointer, characterSize);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the texture containing the glyphs of a given size
    /// </summary>
    /// <param name="characterSize">Character size</param>
    /// <returns>Texture storing the glyphs for the given size</returns>
    ////////////////////////////////////////////////////////////
    public Texture GetTexture(uint characterSize)
    {
        _textures[characterSize] = new Texture(CSFMLGraphics.sfFont_getTexture(CPointer, characterSize));
        return _textures[characterSize];
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Enable or disable the smooth filter
    ///
    /// When the filter is activated, the font appears smoother
    /// so that pixels are less noticeable. However, if you want
    /// the font to look exactly the same as its source file,
    /// you should disable it.
    /// The smooth filter is enabled by default.
    /// </summary>
    /// <param name="smooth">True to enable smoothing, false to disable it</param>
    ////////////////////////////////////////////////////////////
    public void SetSmooth(bool smooth) => CSFMLGraphics.sfFont_setSmooth(CPointer, smooth);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Tell whether the smooth filter is enabled or disabled
    /// </summary>
    /// <returns>True if smoothing is enabled, false if it is disabled</returns>
    ////////////////////////////////////////////////////////////
    public bool IsSmooth() => CSFMLGraphics.sfFont_isSmooth(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the font information
    /// </summary>
    /// <returns>A structure that holds the font information</returns>
    ////////////////////////////////////////////////////////////
    public Info GetInfo()
    {
        var data = CSFMLGraphics.sfFont_getInfo(CPointer);
        var info = new Info
        {
            Family = Marshal.PtrToStringAnsi(data.Family)!
        };

        return info;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Provide a string describing the object
    /// </summary>
    /// <returns>String description of the object</returns>
    ////////////////////////////////////////////////////////////
    public override string ToString() => nameof(Font);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing)
    {
        if (!disposing)
        {
            _ = Context.Global.SetActive(true);
        }

        CSFMLGraphics.sfFont_destroy(CPointer);

        if (disposing)
        {
            foreach (var texture in _textures.Values)
            {
                texture.Dispose();
            }

            _myStream?.Dispose();
        }

        if (_myBytesPin.IsAllocated)
        {
            _myBytesPin.Free();
        }

        if (!disposing)
        {
            _ = Context.Global.SetActive(false);
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Info holds various information about a font
    /// </summary>
    ////////////////////////////////////////////////////////////
    public struct Info
    {
        /// <summary>The font family</summary>
        public string Family;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal struct used for marshaling the font info
    /// struct from unmanaged code.
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct InfoMarshalData
    {
        public IntPtr Family;
    }

    private readonly Dictionary<uint, Texture> _textures = [];
    private readonly StreamAdaptor? _myStream;
    private GCHandle _myBytesPin;
}
