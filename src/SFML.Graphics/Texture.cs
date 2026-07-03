using Gaiden.SFML.Window;
using Gaiden.SFML.System;
using LoadingFailedException = Gaiden.SFML.Window.LoadingFailedException;

namespace Gaiden.SFML.Graphics;

////////////////////////////////////////////////////////////
/// <summary>
/// Image living on the graphics card that can be used for drawing
/// <para/>
/// When providing texture data from an image file or memory, it can
/// either be stored in a linear color space or an sRGB color space.
/// Most digital images account for gamma correction already, so they
/// would need to be "uncorrected" back to linear color space before
/// being processed by the hardware. The hardware can automatically
/// convert it from the sRGB color space to a linear color space when
/// it gets sampled. When the rendered image gets output to the final
/// framebuffer, it gets converted back to sRGB.
/// <para/>
/// This load option is only useful in conjunction with an sRGB capable
/// framebuffer. This can be requested during window creation.
/// </summary>
////////////////////////////////////////////////////////////
public sealed class Texture : ObjectBase
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the texture
    /// </summary>
    /// <remarks>
    /// Textures created this way are uninitialized and have indeterminate contents.
    /// </remarks>
    /// <param name="size">Width and height of the texture</param>
    /// <param name="srgb">True to convert the texture source from sRGB, false otherwise</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Texture(Vector2u size, bool srgb = false) :
        base(IntPtr.Zero)
    {
        if (srgb)
        {
            CPointer = CSFMLGraphics.sfTexture_createSrgb(size);
        }
        else
        {
            CPointer = CSFMLGraphics.sfTexture_create(size);
        }

        if (IsInvalid)
        {
            throw new LoadingFailedException("texture");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the texture from a file
    /// </summary>
    /// <param name="filename">Path of the image file to load</param>
    /// <param name="srgb">True to convert the texture source from sRGB, false otherwise</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Texture(string filename, bool srgb = false) :
        this(filename, new IntRect((0, 0), (0, 0)), srgb)
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the texture from a file
    /// </summary>
    /// <param name="filename">Path of the image file to load</param>
    /// <param name="area">Area of the image to load</param>
    /// <param name="srgb">True to convert the texture source from sRGB, false otherwise</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Texture(string filename, IntRect area, bool srgb = false) :
        base(IntPtr.Zero)
    {
        if (srgb)
        {
            CPointer = CSFMLGraphics.sfTexture_createSrgbFromFile(filename, ref area);
        }
        else
        {
            CPointer = CSFMLGraphics.sfTexture_createFromFile(filename, ref area);
        }

        if (IsInvalid)
        {
            throw new LoadingFailedException("texture", filename);
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the texture from a file in a stream
    /// </summary>
    /// <param name="stream">Stream containing the file contents</param>
    /// <param name="srgb">True to convert the texture source from sRGB, false otherwise</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Texture(Stream stream, bool srgb = false) :
        this(stream, new IntRect((0, 0), (0, 0)), srgb)
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the texture from a file in a stream
    /// </summary>
    /// <param name="stream">Stream containing the file contents</param>
    /// <param name="area">Area of the image to load</param>
    /// <param name="srgb">True to convert the texture source from sRGB, false otherwise</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Texture(Stream stream, IntRect area, bool srgb = false) :
        base(IntPtr.Zero)
    {
        using (var adaptor = new StreamAdaptor(stream))
        {
            if (srgb)
            {
                CPointer = CSFMLGraphics.sfTexture_createSrgbFromStream(adaptor.InputStreamPtr, ref area);
            }
            else
            {
                CPointer = CSFMLGraphics.sfTexture_createFromStream(adaptor.InputStreamPtr, ref area);
            }
        }

        if (IsInvalid)
        {
            throw new LoadingFailedException("texture");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the texture from an image
    /// </summary>
    /// <param name="image">Image to load to the texture</param>
    /// <param name="srgb">True to convert the texture source from sRGB, false otherwise</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Texture(Image image, bool srgb = false) :
        this(image, new IntRect((0, 0), (0, 0)), srgb)
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the texture from an image
    /// </summary>
    /// <param name="image">Image to load to the texture</param>
    /// <param name="area">Area of the image to load</param>
    /// <param name="srgb">True to convert the texture source from sRGB, false otherwise</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Texture(Image image, IntRect area, bool srgb = false) :
        base(IntPtr.Zero)
    {
        if (srgb)
        {
            CPointer = CSFMLGraphics.sfTexture_createSrgbFromImage(image.CPointer, ref area);
        }
        else
        {
            CPointer = CSFMLGraphics.sfTexture_createFromImage(image.CPointer, ref area);
        }

        if (IsInvalid)
        {
            throw new LoadingFailedException("texture");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the texture from a file in memory
    /// </summary>
    /// <param name="bytes">Byte array containing the file contents</param>
    /// <param name="srgb">True to convert the texture source from sRGB, false otherwise</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Texture(ReadOnlySpan<byte> bytes, bool srgb = false) :
        this(bytes, new IntRect((0, 0), (0, 0)), srgb)
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the texture from a file in memory
    /// </summary>
    /// <param name="bytes">Byte array containing the file contents</param>
    /// <param name="area">Area of the image to load</param>
    /// <param name="srgb">True to convert the texture source from sRGB, false otherwise</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Texture(ReadOnlySpan<byte> bytes, IntRect area, bool srgb = false) :
        base(IntPtr.Zero)
    {
        unsafe
        {
            fixed (void* ptr = bytes)
            {
                if (srgb)
                {
                    CPointer = CSFMLGraphics.sfTexture_createSrgbFromMemory((IntPtr)ptr, (UIntPtr)bytes.Length, ref area);
                }
                else
                {
                    CPointer = CSFMLGraphics.sfTexture_createFromMemory((IntPtr)ptr, (UIntPtr)bytes.Length, ref area);
                }
            }
        }

        if (IsInvalid)
        {
            throw new LoadingFailedException("texture");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the texture from another texture
    /// </summary>
    /// <param name="copy">Texture to copy</param>
    ////////////////////////////////////////////////////////////
    public Texture(Texture copy) :
        base(CSFMLGraphics.sfTexture_copy(copy.CPointer))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the underlying OpenGL handle of the texture.
    /// </summary>
    /// <remarks>
    /// You shouldn't need to use this handle, unless you have
    /// very specific stuff to implement that SFML doesn't support,
    /// or implement a temporary workaround until a bug is fixed.
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public uint NativeHandle => CSFMLGraphics.sfTexture_getNativeHandle(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Copy a texture's pixels to an image
    /// </summary>
    /// <returns>Image containing the texture's pixels</returns>
    ////////////////////////////////////////////////////////////
    public Image CopyToImage() => new(CSFMLGraphics.sfTexture_copyToImage(CPointer));

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Resize the texture.
    /// </summary>
    /// <param name="size">Width and height of the texture</param>
    /// <param name="srgb">True to enable sRGB conversion, false to disable it</param>
    ////////////////////////////////////////////////////////////
    public bool Resize(Vector2u size, bool srgb = false) => srgb ? CSFMLGraphics.sfTexture_resizeSrgb(CPointer, size) : CSFMLGraphics.sfTexture_resize(CPointer, size);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Update a texture from an array of pixels
    /// </summary>
    /// <param name="pixels">Array of pixels to copy to the texture</param>
    ////////////////////////////////////////////////////////////
    public void Update(ReadOnlySpan<byte> pixels) => Update(pixels, Size, new Vector2u());

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Update a texture from an array of pixels
    /// </summary>
    /// <param name="pixels">Array of pixels to copy to the texture</param>
    /// <param name="size">Width and height of the pixel region contained in pixels</param>
    /// <param name="dest">Coordinates of the destination position</param>
    ////////////////////////////////////////////////////////////
    public void Update(ReadOnlySpan<byte> pixels, Vector2u size, Vector2u dest)
    {
        unsafe
        {
            fixed (byte* ptr = pixels)
            {
                CSFMLGraphics.sfTexture_updateFromPixels(CPointer, ptr, size, dest);
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Update a part of this texture from another texture
    /// </summary>
    /// <param name="texture">Source texture to copy to destination texture</param>
    /// <param name="dest">Coordinates of the destination position</param>
    ////////////////////////////////////////////////////////////
    public void Update(Texture texture, Vector2u dest) => CSFMLGraphics.sfTexture_updateFromTexture(CPointer, texture.CPointer, dest);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Update a texture from an image
    /// </summary>
    /// <param name="image">Image to copy to the texture</param>
    ////////////////////////////////////////////////////////////
    public void Update(Image image) => Update(image, new Vector2u());

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Update a texture from an image
    /// </summary>
    /// <param name="image">Image to copy to the texture</param>
    /// <param name="dest">Coordinates of the destination position</param>
    ////////////////////////////////////////////////////////////
    public void Update(Image image, Vector2u dest) => CSFMLGraphics.sfTexture_updateFromImage(CPointer, image.CPointer, dest);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Update a texture from the contents of a window
    /// </summary>
    /// <param name="window">Window to copy to the texture</param>
    ////////////////////////////////////////////////////////////
    public void Update(global::Gaiden.SFML.Window.Window window) => Update(window, new Vector2u());

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Update a texture from the contents of a window
    /// </summary>
    /// <param name="window">Window to copy to the texture</param>
    /// <param name="dest">Coordinates of the destination position</param>
    ////////////////////////////////////////////////////////////
    public void Update(global::Gaiden.SFML.Window.Window window, Vector2u dest) => CSFMLGraphics.sfTexture_updateFromWindow(CPointer, window.CPointer, dest);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Update a texture from the contents of a render-window
    /// </summary>
    /// <param name="window">Render-window to copy to the texture</param>
    ////////////////////////////////////////////////////////////
    public void Update(RenderWindow window) => Update(window, new Vector2u());

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Update a texture from the contents of a render-window
    /// </summary>
    /// <param name="window">Render-window to copy to the texture</param>
    /// <param name="dest">Coordinates of the destination position</param>
    ////////////////////////////////////////////////////////////
    public void Update(RenderWindow window, Vector2u dest) => CSFMLGraphics.sfTexture_updateFromRenderWindow(CPointer, window.CPointer, dest);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Generate a mipmap using the current texture data
    /// </summary>
    ///
    /// <remarks>
    /// <para>Mipmaps are pre-computed chains of optimized textures. Each
    /// level of texture in a mipmap is generated by halving each of
    /// the previous level's dimensions. This is done until the final
    /// level has the size of 1x1. The textures generated in this process may
    /// make use of more advanced filters which might improve the visual quality
    /// of textures when they are applied to objects much smaller than they are.
    /// This is known as minification. Because fewer texels (texture elements)
    /// have to be sampled from when heavily minified, usage of mipmaps
    /// can also improve rendering performance in certain scenarios.</para>
    ///
    /// <para>Mipmap generation relies on the necessary OpenGL extension being
    /// available. If it is unavailable or generation fails due to another
    /// reason, this function will return false. Mipmap data is only valid from
    /// the time it is generated until the next time the base level image is
    /// modified, at which point this function will have to be called again to
    /// regenerate it.</para>
    /// </remarks>
    ///
    /// <returns>True if mipmap generation was successful, false if unsuccessful</returns>
    ////////////////////////////////////////////////////////////
    public bool GenerateMipmap() => CSFMLGraphics.sfTexture_generateMipmap(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Swap the contents of this texture with those of another
    /// </summary>
    /// <param name="right">Instance to swap with</param>
    ////////////////////////////////////////////////////////////
    public void Swap(Texture right) => CSFMLGraphics.sfTexture_swap(CPointer, right.CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Control the smooth filter
    /// </summary>
    ////////////////////////////////////////////////////////////
    public bool Smooth
    {
        get => CSFMLGraphics.sfTexture_isSmooth(CPointer);
        set => CSFMLGraphics.sfTexture_setSmooth(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Enable or disable conversion from sRGB
    /// </summary>
    ///
    /// <remarks>
    /// <para>When providing texture data from an image file or memory, it can
    /// either be stored in a linear color space or an sRGB color space.
    /// Most digital images account for gamma correction already, so they
    /// would need to be "uncorrected" back to linear color space before
    /// being processed by the hardware. The hardware can automatically
    /// convert it from the sRGB color space to a linear color space when
    /// it gets sampled. When the rendered image gets output to the final
    /// framebuffer, it gets converted back to sRGB.</para>
    ///
    /// <para>After enabling or disabling sRGB conversion, make sure to reload
    /// the texture data in order for the setting to take effect.</para>
    ///
    /// <para>This option is only useful in conjunction with an sRGB capable
    /// framebuffer. This can be requested during window creation.</para>
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public bool IsSrgb => CSFMLGraphics.sfTexture_isSrgb(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Control the repeat mode
    /// </summary>
    ////////////////////////////////////////////////////////////
    public bool Repeated
    {
        get => CSFMLGraphics.sfTexture_isRepeated(CPointer);
        set => CSFMLGraphics.sfTexture_setRepeated(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Size of the texture, in pixels
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Vector2u Size => CSFMLGraphics.sfTexture_getSize(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Bind a texture for rendering
    /// </summary>
    /// <param name="texture">Shader to bind (can be null to use no texture)</param>
    /// <param name="type">Type of texture coordinates to use</param>
    ////////////////////////////////////////////////////////////
    public static void Bind(Texture? texture, CoordinateType type) => 
        CSFMLGraphics.sfTexture_bind(texture?.CPointer ?? IntPtr.Zero, type);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Maximum texture size allowed
    /// </summary>
    ////////////////////////////////////////////////////////////
    public static uint MaximumSize => CSFMLGraphics.sfTexture_getMaximumSize();

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

        return "[Texture]" +
               " Size(" + Size + ")" +
               " Smooth(" + Smooth + ")" +
               " Repeated(" + Repeated + ")";
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal constructor
    /// </summary>
    /// <param name="cPointer">Pointer to the object in C library</param>
    ////////////////////////////////////////////////////////////
    internal Texture(IntPtr cPointer) :
        base(cPointer) => _external = true;

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing)
    {
        if (!_external)
        {
            if (!disposing)
            {
                _ = Context.Global.SetActive(true);
            }

            CSFMLGraphics.sfTexture_destroy(CPointer);

            if (!disposing)
            {
                _ = Context.Global.SetActive(false);
            }
        }
    }

    private readonly bool _external;
}
