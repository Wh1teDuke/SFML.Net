using System.Runtime.InteropServices;

namespace Gaiden.SFML.System;

////////////////////////////////////////////////////////////
/// <summary>
/// Internal helper class for CSFML's sfBuffer
/// </summary>
////////////////////////////////////////////////////////////
public class Buffer : ObjectBase
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
    public byte[] GetData()
    {
        var size = CSFMLSystem.sfBuffer_getSize(CPointer);
        var ptr = CSFMLSystem.sfBuffer_getData(CPointer);

        if (ptr == IntPtr.Zero)
        {
            return [];
        }

        var data = new byte[(int)size];
        Marshal.Copy(ptr, data, 0, (int)size);

        return data;
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
