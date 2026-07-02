using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Gaiden.SFML.System;

namespace Gaiden.SFML.Graphics;

////////////////////////////////////////////////////////////
/// <summary>
/// Define a set of one or more 2D primitives
/// </summary>
////////////////////////////////////////////////////////////
public partial class VertexArray : ObjectBase, IDrawable
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Default constructor
    /// </summary>
    ////////////////////////////////////////////////////////////
    public VertexArray() :
        base(sfVertexArray_create())
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the vertex array with a <see cref="SFML.Graphics.PrimitiveType"/>
    /// </summary>
    /// <param name="type">Type of primitives</param>
    ////////////////////////////////////////////////////////////
    public VertexArray(PrimitiveType type) :
        base(sfVertexArray_create()) => PrimitiveType = type;

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the vertex array with a <see cref="SFML.Graphics.PrimitiveType"/> and an initial number of vertices
    /// </summary>
    /// <param name="type">Type of primitives</param>
    /// <param name="vertexCount">Initial number of vertices in the array</param>
    ////////////////////////////////////////////////////////////
    public VertexArray(PrimitiveType type, uint vertexCount) :
        base(sfVertexArray_create())
    {
        PrimitiveType = type;
        Resize(vertexCount);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the vertex array from another <see cref="VertexArray"/>
    /// </summary>
    /// <param name="copy">Transformable to copy</param>
    ////////////////////////////////////////////////////////////
    public VertexArray(VertexArray copy) :
        base(sfVertexArray_copy(copy.CPointer))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Total <see cref="Vertex"/> count
    /// </summary>
    ////////////////////////////////////////////////////////////
    public uint VertexCount => (uint)sfVertexArray_getVertexCount(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Read-Write access to vertices by their index.
    /// </summary>
    /// <remarks>
    /// This function doesn't check index, it must be in range
    /// [0, VertexCount - 1]. The behavior is undefined
    /// otherwise. See <see cref="VertexCount"/>.
    /// </remarks>
    /// <param name="index">Index of the vertex to get</param>
    /// <returns>Copy of the index-th vertex.</returns>
    ////////////////////////////////////////////////////////////
    public Vertex this[uint index]
    {
        get
        {
            unsafe
            {
                return *sfVertexArray_getVertex(CPointer, (UIntPtr)index);
            }
        }
        set
        {
            unsafe
            {
                *sfVertexArray_getVertex(CPointer, (UIntPtr)index) = value;
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Clear the vertex array
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void Clear() => sfVertexArray_clear(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Resize the vertex array
    /// </summary>
    /// <remarks>
    /// If <paramref name="vertexCount"/> is greater than the current size, the previous
    /// vertices are kept and new (default-constructed) vertices are
    /// added.
    /// If <paramref name="vertexCount"/> is less than the current size, existing vertices
    /// are removed from the array.
    /// </remarks>
    /// <param name="vertexCount">New size of the array (number of vertices)</param>
    ////////////////////////////////////////////////////////////
    public void Resize(uint vertexCount) => sfVertexArray_resize(CPointer, (UIntPtr)vertexCount);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Add a <see cref="Vertex" /> to the array
    /// </summary>
    /// <param name="vertex">Vertex to add</param>
    ////////////////////////////////////////////////////////////
    public void Append(Vertex vertex) => sfVertexArray_append(CPointer, vertex);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Type of primitives to draw
    /// </summary>
    /// <remarks>
    /// See <see cref="SFML.Graphics.PrimitiveType" />
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public PrimitiveType PrimitiveType
    {
        get => sfVertexArray_getPrimitiveType(CPointer);
        set => sfVertexArray_setPrimitiveType(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Compute the bounding rectangle of the vertex array.
    /// </summary>
    /// <remarks>
    /// Contains the axis-aligned <see cref="FloatRect"/> that contains all the vertices of the array.
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public FloatRect Bounds => sfVertexArray_getBounds(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Draw the vertex array to a <see cref="IRenderTarget" />
    /// </summary>
    /// <param name="target">Render target to draw to</param>
    /// <param name="states">Current render states</param>
    ////////////////////////////////////////////////////////////
    public void Draw(IRenderTarget target, RenderStates states)
    {
        var marshaledStates = states.Marshal();

        if (target is RenderWindow window)
        {
            sfRenderWindow_drawVertexArray(window.CPointer, CPointer, ref marshaledStates);
        }
        else if (target is RenderTexture texture)
        {
            sfRenderTexture_drawVertexArray(texture.CPointer, CPointer, ref marshaledStates);
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing) => sfVertexArray_destroy(CPointer);

    #region Imports
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfVertexArray_create();

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfVertexArray_copy(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfVertexArray_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial UIntPtr sfVertexArray_getVertexCount(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe partial Vertex* sfVertexArray_getVertex(IntPtr cPointer, UIntPtr index);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfVertexArray_clear(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfVertexArray_resize(IntPtr cPointer, UIntPtr vertexCount);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfVertexArray_append(IntPtr cPointer, Vertex vertex);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfVertexArray_setPrimitiveType(IntPtr cPointer, PrimitiveType type);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial PrimitiveType sfVertexArray_getPrimitiveType(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial FloatRect sfVertexArray_getBounds(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfRenderWindow_drawVertexArray(IntPtr cPointer, IntPtr vertexArray, ref RenderStates.MarshalData states);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfRenderTexture_drawVertexArray(IntPtr cPointer, IntPtr vertexArray, ref RenderStates.MarshalData states);
    #endregion
}
