using Gaiden.SFML.System;
using LoadingFailedException = Gaiden.SFML.Window.LoadingFailedException;

namespace Gaiden.SFML.Graphics;

////////////////////////////////////////////////////////////
/// <summary>
/// Image is the low-level class for loading and
/// manipulating images
/// </summary>
////////////////////////////////////////////////////////////
public sealed class Image : ObjectBase
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the image with black color
    /// </summary>
    /// <param name="size">Width and height of the image</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Image(Vector2u size) : this(size, Color.Black) { }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the image from a single color
    /// </summary>
    /// <param name="size">Width and height of the image</param>
    /// <param name="color">Color to fill the image with</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Image(Vector2u size, Color color) : base(CSFMLGraphics.sfImage_createFromColor(size, color))
    {
        if (IsInvalid)
        {
            throw new LoadingFailedException("image");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the image from a file
    /// </summary>
    /// <param name="filename">Path of the image file to load</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Image(string filename) : base(CSFMLGraphics.sfImage_createFromFile(filename))
    {
        if (IsInvalid)
        {
            throw new LoadingFailedException("image", filename);
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the image from a file in a stream
    /// </summary>
    /// <param name="stream">Stream containing the file contents</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Image(Stream stream) :
        base(IntPtr.Zero)
    {
        using (var adaptor = new StreamAdaptor(stream))
        {
            CPointer = CSFMLGraphics.sfImage_createFromStream(adaptor.InputStreamPtr);
        }

        if (IsInvalid)
        {
            throw new LoadingFailedException("image");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the image from a file in memory
    /// </summary>
    /// <param name="bytes">Byte array containing the file contents</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Image(ReadOnlySpan<byte> bytes) :
        base(IntPtr.Zero)
    {
        unsafe
        {
            fixed (void* ptr = bytes)
            {
                CPointer = CSFMLGraphics.sfImage_createFromMemory((IntPtr)ptr, (UIntPtr)bytes.Length);
            }
        }

        if (IsInvalid)
        {
            throw new LoadingFailedException("image");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the image directly from an array of pixels
    /// </summary>
    /// <param name="size">Width and height of the image</param>
    /// <param name="pixels">array containing the pixels</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Image(Vector2u size, ReadOnlySpan<byte> pixels) :
        base(IntPtr.Zero)
    {
        unsafe
        {
            fixed (byte* pixelsPtr = pixels)
            {
                CPointer = CSFMLGraphics.sfImage_createFromPixels(size, pixelsPtr);
            }
        }

        if (IsInvalid)
        {
            throw new LoadingFailedException("image");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the image from another image
    /// </summary>
    /// <param name="copy">Image to copy</param>
    ////////////////////////////////////////////////////////////
    public Image(Image copy) :
        base(CSFMLGraphics.sfImage_copy(copy.CPointer))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Save the contents of the image to a file
    /// </summary>
    /// <param name="filename">Path of the file to save (overwritten if already exist)</param>
    /// <returns>True if saving was successful</returns>
    ////////////////////////////////////////////////////////////
    public bool SaveToFile(string filename) => CSFMLGraphics.sfImage_saveToFile(CPointer, filename);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Save the image to a buffer in memory
    ///
    /// The format of the image must be specified.
    /// The supported image formats are bmp, png, tga and jpg.
    /// This function fails if the image is empty, or if
    /// the format was invalid.
    /// </summary>
    /// <param name="output">Byte array filled with encoded data</param>
    /// <param name="format">Encoding format to use</param>
    /// <returns>True if saving was successful</returns>
    ////////////////////////////////////////////////////////////
    public bool SaveToMemory(Span<byte> output, string format)
    {
        using var buffer = new System.Buffer();
        var success = CSFMLGraphics.sfImage_saveToMemory(CPointer, buffer.CPointer, format);

        var data = success ? buffer.GetData() : Array.Empty<byte>();
        data.CopyTo(output);
        return success;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create a transparency mask from a specified color key
    /// </summary>
    /// <param name="color">Color to become transparent</param>
    ////////////////////////////////////////////////////////////
    public void CreateMaskFromColor(Color color) => CreateMaskFromColor(color, 0);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create a transparency mask from a specified color key
    /// </summary>
    /// <param name="color">Color to become transparent</param>
    /// <param name="alpha">Alpha value to use for transparent pixels</param>
    ////////////////////////////////////////////////////////////
    public void CreateMaskFromColor(Color color, byte alpha) => CSFMLGraphics.sfImage_createMaskFromColor(CPointer, color, alpha);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Copy pixels from another image onto this one.
    /// This function does a slow pixel copy and should only
    /// be used at initialization time
    /// </summary>
    /// <param name="source">Source image to copy</param>
    /// <param name="dest">Coordinates of the destination position</param>
    ////////////////////////////////////////////////////////////
    public void Copy(Image source, Vector2u dest) => Copy(source, dest, new IntRect((0, 0), (0, 0)));

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Copy pixels from another image onto this one.
    /// This function does a slow pixel copy and should only
    /// be used at initialization time
    /// </summary>
    /// <param name="source">Source image to copy</param>
    /// <param name="dest">Coordinates of the destination position</param>
    /// <param name="sourceRect">Sub-rectangle of the source image to copy</param>
    ////////////////////////////////////////////////////////////
    public void Copy(Image source, Vector2u dest, IntRect sourceRect) => Copy(source, dest, sourceRect, false);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Copy pixels from another image onto this one.
    /// This function does a slow pixel copy and should only
    /// be used at initialization time
    /// </summary>
    /// <param name="source">Source image to copy</param>
    /// <param name="dest">Coordinates of the destination position</param>
    /// <param name="sourceRect">Sub-rectangle of the source image to copy</param>
    /// <param name="applyAlpha">Should the copy take in account the source transparency?</param>
    ////////////////////////////////////////////////////////////
    public void Copy(Image source, Vector2u dest, IntRect sourceRect, bool applyAlpha) => CSFMLGraphics.sfImage_copyImage(CPointer, source.CPointer, dest, sourceRect, applyAlpha);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get a pixel from the image
    /// </summary>
    /// <param name="coords">Coordinates of pixel to change</param>
    /// <returns>Color of pixel (x, y)</returns>
    ////////////////////////////////////////////////////////////
    public Color GetPixel(Vector2u coords) => CSFMLGraphics.sfImage_getPixel(CPointer, coords);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Change the color of a pixel
    /// </summary>
    /// <param name="coords">Coordinates of pixel to change</param>
    /// <param name="color">New color for pixel (x, y)</param>
    ////////////////////////////////////////////////////////////
    public void SetPixel(Vector2u coords, Color color) => CSFMLGraphics.sfImage_setPixel(CPointer, coords, color);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get a copy of the array of pixels (RGBA 8 bits integers components) into the provided span
    /// Array size is Width x Height x 4
    /// </summary>
    /// <returns>The same span passed as argument with the right size</returns>
    ////////////////////////////////////////////////////////////
    public Span<byte> GetPixels(Span<byte> pixels)
    {
        var size = Size;
        var len = (int)(size.X * size.Y * 4);
    
        if (len < pixels.Length)
            throw new ArgumentOutOfRangeException(nameof(pixels));

        unsafe
        {        
            var ptr = CSFMLGraphics.sfImage_getPixelsPtr(CPointer);
            var nativeSpan = new ReadOnlySpan<byte>((void*)ptr, len);
            nativeSpan.CopyTo(pixels);
            return pixels[..len];
        }
    }
    
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get a copy of the array of pixels (RGBA 8 bits integers components)
    /// Array size is Width x Height x 4
    /// </summary>
    /// <returns>Array of pixels</returns>
    ////////////////////////////////////////////////////////////
    public ReadOnlySpan<byte> Pixels
    {
        get
        {
            // You can't resize images from C#, so the memory shouldn't get invalidated
            var size = Size;
            var ptr = CSFMLGraphics.sfImage_getPixelsPtr(CPointer);
            var pixelCount = size.X * size.Y * 4;

            unsafe
            {
                return new ReadOnlySpan<byte>(ptr.ToPointer(), (int)pixelCount);
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Size of the image, in pixels
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Vector2u Size =>
        _size ??= CSFMLGraphics.sfImage_getSize(CPointer);
    private Vector2u? _size;

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Flip the image horizontally
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void FlipHorizontally() => CSFMLGraphics.sfImage_flipHorizontally(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Flip the image vertically
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void FlipVertically() => CSFMLGraphics.sfImage_flipVertically(CPointer);

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

        return $"[Image] Size({Size})";
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal constructor
    /// </summary>
    /// <param name="cPointer">Pointer to the object in C library</param>
    ////////////////////////////////////////////////////////////
    internal Image(IntPtr cPointer) : base(cPointer) { }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing) => CSFMLGraphics.sfImage_destroy(CPointer);
}
