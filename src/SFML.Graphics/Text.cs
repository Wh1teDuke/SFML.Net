using System.Buffers;
using System.Runtime.InteropServices;
using System.Text;
using Gaiden.SFML.System;

namespace Gaiden.SFML.Graphics;

////////////////////////////////////////////////////////////
/// <summary>
/// This class defines a graphical 2D text, that can be drawn on screen
/// </summary>
/// <remarks>
/// See also the note on coordinates and undistorted rendering in SFML.Graphics.Transformable.
/// </remarks>
////////////////////////////////////////////////////////////
public class Text : Transformable, IDrawable
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Flags for styles that can be applied to the <see cref="Text"/>
    /// </summary>
    ////////////////////////////////////////////////////////////
    [Flags]
    public enum Styles
    {
        /// <summary>No Style</summary>
        Regular = 0,

        /// <summary>Bold</summary>
        Bold = 1 << 0,

        /// <summary>Italic</summary>
        Italic = 1 << 1,

        /// <summary>Underlined</summary>
        Underlined = 1 << 2,

        /// <summary>Strikethrough</summary>
        StrikeThrough = 1 << 3
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the text from a <see cref="SFML.Graphics.Font"/>
    /// </summary>
    /// <param name="font">Font to use</param>
    ////////////////////////////////////////////////////////////
    public Text(Font font) :
        this(font, "", 30)
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the text from a string and a <see cref="SFML.Graphics.Font"/>
    /// </summary>
    /// <param name="font">Font to use</param>
    /// <param name="str">String to display</param>
    ////////////////////////////////////////////////////////////
    public Text(Font font, string str) :
        this(font, str, 30)
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the text from a string, <see cref="SFML.Graphics.Font"/> and size
    /// </summary>
    /// <param name="font">Font to use</param>
    /// <param name="str">String to display</param>
    /// <param name="characterSize">Font size</param>
    ////////////////////////////////////////////////////////////
    public Text(Font font, string str, uint characterSize) :
        base(CSFMLGraphics.sfText_create(font.CPointer))
    {
        DisplayedString = str;
        Font = font;
        CharacterSize = characterSize;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the text from another <see cref="SFML.Graphics.Text"/>
    /// </summary>
    /// <param name="copy">Text to copy</param>
    ////////////////////////////////////////////////////////////
    public Text(Text copy) :
        base(CSFMLGraphics.sfText_copy(copy.CPointer))
    {
        Origin = copy.Origin;
        Position = copy.Position;
        Rotation = copy.Rotation;
        Scale = copy.Scale;

        Font = copy.Font;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Fill <see cref="SFML.Graphics.Color"/> of the <see cref="Text"/>
    /// </summary>
    ///
    /// <remarks>
    /// By default, the text's fill <see cref="SFML.Graphics.Color"/> is <see cref="SFML.Graphics.Color.White">opaque White</see>.
    /// <para>
    /// Setting the fill color to a transparent <see cref="SFML.Graphics.Color"/> with an outline
    /// will cause the outline to be displayed in the fill area of the text.
    /// </para>
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public Color FillColor
    {
        get => CSFMLGraphics.sfText_getFillColor(CPointer);
        set => CSFMLGraphics.sfText_setFillColor(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Outline <see cref="SFML.Graphics.Color"/> of the <see cref="Text"/>
    /// </summary>
    ///
    /// <remarks>
    /// By default, the text's outline <see cref="SFML.Graphics.Color"/> is <see cref="SFML.Graphics.Color.Black">opaque Black</see>.
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public Color OutlineColor
    {
        get => CSFMLGraphics.sfText_getOutlineColor(CPointer);
        set => CSFMLGraphics.sfText_setOutlineColor(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Thickness of the object's outline
    /// </summary>
    ///
    /// <remarks>
    /// <para>By default, the outline thickness is 0.</para>
    /// <para>Be aware that using a negative value for the outline
    /// thickness will cause distorted rendering.</para>
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public float OutlineThickness
    {
        get => CSFMLGraphics.sfText_getOutlineThickness(CPointer);
        set => CSFMLGraphics.sfText_setOutlineThickness(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// String which is displayed
    /// </summary>
    ////////////////////////////////////////////////////////////
    public string DisplayedString
    {
        get
        {
            // Get a pointer to the source string (UTF-32)
            var source = CSFMLGraphics.sfText_getUnicodeString(CPointer);

            // Find its length (find the terminating 0)
            uint length = 0;
            unsafe
            {
                for (var ptr = (uint*)source.ToPointer(); *ptr != 0; ++ptr)
                {
                    length++;
                }
            }

            // Copy it to a byte array
            var sourceBytes = new byte[length * 4];
            Marshal.Copy(source, sourceBytes, 0, sourceBytes.Length);

            // Convert it to a C# string
            return Encoding.UTF32.GetString(sourceBytes);
        }

        set
        {
            // Copy the string to a null-terminated UTF-32 byte array
            var utf32 = Encoding.UTF32.GetBytes(value + '\0');

            // Pass it to the C API
            unsafe
            {
                fixed (byte* ptr = utf32)
                {
                    CSFMLGraphics.sfText_setUnicodeString(CPointer, (IntPtr)ptr);
                }
            }
        }
    }
    
    /// <summary>
    /// Set the string which is displayed
    /// </summary>
    /// <param name="chars"></param>
    public void SetDisplayedString(ReadOnlySpan<char> chars)
    {
        var i = 0;
        var arr = ArrayPool<int>.Shared.Rent(chars.Length + 1);
        foreach (var c in chars.EnumerateRunes()) arr[i++] = c.Value;
        arr[i++] = 0;

        unsafe
        {
            fixed (int* ptr = arr.AsSpan(0, i))
                CSFMLGraphics.sfText_setUnicodeString(CPointer, (IntPtr)ptr);
        }

        ArrayPool<int>.Shared.Return(arr);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// <see cref="SFML.Graphics.Font"/> used to display the text
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Font? Font
    {
        get => _font;
        set { _font = value; CSFMLGraphics.sfText_setFont(CPointer, value?.CPointer ?? IntPtr.Zero); }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Base size of characters
    /// </summary>
    ////////////////////////////////////////////////////////////
    public uint CharacterSize
    {
        get => CSFMLGraphics.sfText_getCharacterSize(CPointer);
        set => CSFMLGraphics.sfText_setCharacterSize(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Size of the letter spacing factor
    /// </summary>
    ////////////////////////////////////////////////////////////
    public float LetterSpacing
    {
        get => CSFMLGraphics.sfText_getLetterSpacing(CPointer);
        set => CSFMLGraphics.sfText_setLetterSpacing(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Size of the line spacing factor
    /// </summary>
    ////////////////////////////////////////////////////////////
    public float LineSpacing
    {
        get => CSFMLGraphics.sfText_getLineSpacing(CPointer);
        set => CSFMLGraphics.sfText_setLineSpacing(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// <see cref="Styles">Style</see> of the text
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Styles Style
    {
        get => CSFMLGraphics.sfText_getStyle(CPointer);
        set => CSFMLGraphics.sfText_setStyle(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Return the visual position of the Index-th character of the text,
    /// in coordinates relative to the text
    /// </summary>
    /// <remarks>
    /// Translation, origin, rotation and scale are not applied.
    /// </remarks>
    /// <param name="index">Index of the character</param>
    /// <returns>Position of the Index-th character (end of text if Index is out of range)</returns>
    ////////////////////////////////////////////////////////////
    public Vector2f FindCharacterPos(uint index) => CSFMLGraphics.sfText_findCharacterPos(CPointer, (UIntPtr)index);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the local bounding <see cref="FloatRect"/> of the text.
    /// </summary>
    /// <remarks>
    /// The returned <see cref="FloatRect"/> is in local coordinates.
    /// <para>Transformations (Translation, Rotation, Scale) are not applied to the entity.</para>
    /// <para>In other words, this function returns the bounds of the
    /// entity in the entity's coordinate system.</para>
    /// </remarks>
    /// <returns>Local bounding rectangle of the entity</returns>
    ////////////////////////////////////////////////////////////
    public FloatRect GetLocalBounds() => CSFMLGraphics.sfText_getLocalBounds(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the global bounding rectangle of the text.
    /// </summary>
    /// <remarks>
    /// The returned <see cref="FloatRect"/> is in global coordinates.
    /// <para>Transformations (Translation, Rotation, Scale) are applied to the entity.</para>
    /// <para>In other words, this function returns the bounds of the
    /// sprite in the global 2D world's coordinate system.</para>
    /// </remarks>
    /// <returns>Global bounding rectangle of the entity</returns>
    ////////////////////////////////////////////////////////////
    public FloatRect GetGlobalBounds() => Transform.TransformRect(GetLocalBounds()); // we don't use the native getGlobalBounds function, because we override the object's transform

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

        return "[Text]" +
               " FillColor(" + FillColor + ")" +
               " OutlineColor(" + OutlineColor + ")" +
               " String(" + DisplayedString + ")" +
               " Font(" + Font + ")" +
               " CharacterSize(" + CharacterSize + ")" +
               " OutlineThickness(" + OutlineThickness + ")" +
               " Style(" + Style + ")";
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Draw the text to a <see cref="IRenderTarget"/>
    /// </summary>
    /// <param name="target">Render target to draw to</param>
    /// <param name="states">Current render states</param>
    ////////////////////////////////////////////////////////////
    public void Draw(IRenderTarget target, RenderStates states)
    {
        states.Transform *= Transform;
        var marshaledStates = states.Marshal();

        if (target is RenderWindow window)
        {
            CSFMLGraphics.sfRenderWindow_drawText(window.CPointer, CPointer, ref marshaledStates);
        }
        else if (target is RenderTexture texture)
        {
            CSFMLGraphics.sfRenderTexture_drawText(texture.CPointer, CPointer, ref marshaledStates);
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing) => CSFMLGraphics.sfText_destroy(CPointer);

    private Font? _font;
}
