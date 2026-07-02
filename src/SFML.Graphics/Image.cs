using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Gaiden.SFML.System;
using LoadingFailedException = Gaiden.SFML.Window.LoadingFailedException;

namespace Gaiden.SFML.Graphics;

////////////////////////////////////////////////////////////
/// <summary>
/// Image is the low-level class for loading and
/// manipulating images
/// </summary>
////////////////////////////////////////////////////////////
public partial class Image : ObjectBase
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
    public Image(Vector2u size, Color color) : base(sfImage_createFromColor(size, color))
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
    public Image(string filename) : base(sfImage_createFromFile(filename))
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
            CPointer = sfImage_createFromStream(adaptor.InputStreamPtr);
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
    public Image(byte[] bytes) :
        base(IntPtr.Zero)
    {
        unsafe
        {
            fixed (void* ptr = bytes)
            {
                CPointer = sfImage_createFromMemory((IntPtr)ptr, (UIntPtr)bytes.Length);
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
    /// <param name="pixels">2 dimensions array containing the pixels</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Image(Color[,] pixels) :
        base(IntPtr.Zero)
    {
        var width = (uint)pixels.GetLength(0);
        var height = (uint)pixels.GetLength(1);

        // Transpose the array (.NET gives dimensions in reverse order of what SFML expects)
        var transposed = new Color[height, width];
        for (var x = 0; x < width; ++x)
        {
            for (var y = 0; y < height; ++y)
            {
                transposed[y, x] = pixels[x, y];
            }
        }

        unsafe
        {
            fixed (Color* pixelsPtr = transposed)
            {
                CPointer = sfImage_createFromPixels(new Vector2u(width, height), (byte*)pixelsPtr);
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
    public Image(Vector2u size, byte[] pixels) :
        base(IntPtr.Zero)
    {
        unsafe
        {
            fixed (byte* pixelsPtr = pixels)
            {
                CPointer = sfImage_createFromPixels(size, pixelsPtr);
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
        base(sfImage_copy(copy.CPointer))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Save the contents of the image to a file
    /// </summary>
    /// <param name="filename">Path of the file to save (overwritten if already exist)</param>
    /// <returns>True if saving was successful</returns>
    ////////////////////////////////////////////////////////////
    public bool SaveToFile(string filename) => sfImage_saveToFile(CPointer, filename);

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
    public bool SaveToMemory(out byte[] output, string format)
    {
        using var buffer = new global::Gaiden.SFML.System.Buffer();
        var success = sfImage_saveToMemory(CPointer, buffer.CPointer, format);

        output = success ? buffer.GetData() : [];
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
    public void CreateMaskFromColor(Color color, byte alpha) => sfImage_createMaskFromColor(CPointer, color, alpha);

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
    public void Copy(Image source, Vector2u dest, IntRect sourceRect, bool applyAlpha) => sfImage_copyImage(CPointer, source.CPointer, dest, sourceRect, applyAlpha);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get a pixel from the image
    /// </summary>
    /// <param name="coords">Coordinates of pixel to change</param>
    /// <returns>Color of pixel (x, y)</returns>
    ////////////////////////////////////////////////////////////
    public Color GetPixel(Vector2u coords) => sfImage_getPixel(CPointer, coords);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Change the color of a pixel
    /// </summary>
    /// <param name="coords">Coordinates of pixel to change</param>
    /// <param name="color">New color for pixel (x, y)</param>
    ////////////////////////////////////////////////////////////
    public void SetPixel(Vector2u coords, Color color) => sfImage_setPixel(CPointer, coords, color);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get a copy of the array of pixels (RGBA 8 bits integers components)
    /// Array size is Width x Height x 4
    /// </summary>
    /// <returns>Array of pixels</returns>
    ////////////////////////////////////////////////////////////
    public byte[] Pixels
    {
        get
        {
            var size = Size;
            var pixelsPtr = new byte[size.X * size.Y * 4];
            Marshal.Copy(sfImage_getPixelsPtr(CPointer), pixelsPtr, 0, pixelsPtr.Length);
            return pixelsPtr;
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Size of the image, in pixels
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Vector2u Size => sfImage_getSize(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Flip the image horizontally
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void FlipHorizontally() => sfImage_flipHorizontally(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Flip the image vertically
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void FlipVertically() => sfImage_flipVertically(CPointer);

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
    protected override void Destroy(bool disposing) => sfImage_destroy(CPointer);

    #region Imports
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfImage_createFromColor(Vector2u size, Color col);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe partial IntPtr sfImage_createFromPixels(Vector2u size, byte* pixels);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfImage_createFromFile(string filename);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfImage_createFromStream(IntPtr stream);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfImage_createFromMemory(IntPtr data, UIntPtr size);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfImage_copy(IntPtr image);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfImage_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    private static partial bool sfImage_saveToFile(IntPtr cPointer, string filename);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    private static partial bool sfImage_saveToMemory(IntPtr cPointer, IntPtr bufferOutput, string format);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfImage_createMaskFromColor(IntPtr cPointer, Color col, byte alpha);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfImage_copyImage(IntPtr cPointer, IntPtr source, Vector2u dest, IntRect sourceRect, [MarshalAs(UnmanagedType.Bool)] bool applyAlpha);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfImage_setPixel(IntPtr cPointer, Vector2u coords, Color col);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial Color sfImage_getPixel(IntPtr cPointer, Vector2u coords);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfImage_getPixelsPtr(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial Vector2u sfImage_getSize(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfImage_flipHorizontally(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfImage_flipVertically(IntPtr cPointer);
    #endregion
}
