namespace Gaiden.SFML.System;

////////////////////////////////////////////////////////////
/// <summary>
/// Internal helper class for CSFML's sfBuffer
/// </summary>
////////////////////////////////////////////////////////////
public sealed class Buffer : ObjectBase
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the buffer
    /// </summary>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Buffer() :
        base(CSFMLSystem.sfBuffer_create())
    {
        if (IsInvalid)
        {
            throw new LoadingFailedException("buffer");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get a copy of the buffer data
    /// </summary>
    /// <returns>A byte array containing the buffer data</returns>
    ////////////////////////////////////////////////////////////
    public ReadOnlySpan<byte> GetData()
    {
        var size = CSFMLSystem.sfBuffer_getSize(CPointer);
        var ptr = CSFMLSystem.sfBuffer_getData(CPointer);

        if (ptr == IntPtr.Zero)
        {
            return Array.Empty<byte>();
        }

        unsafe
        {
            return new ReadOnlySpan<byte>(ptr.ToPointer(), (int)size);
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal constructor
    /// </summary>
    /// <param name="cPointer">Pointer to the object in C library</param>
    ////////////////////////////////////////////////////////////
    internal Buffer(IntPtr cPointer) :
        base(cPointer)
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing) => CSFMLSystem.sfBuffer_destroy(CPointer);
}
