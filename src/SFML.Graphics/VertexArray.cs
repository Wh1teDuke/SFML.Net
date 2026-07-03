using Gaiden.SFML.System;

namespace Gaiden.SFML.Graphics;

////////////////////////////////////////////////////////////
/// <summary>
/// Define a set of one or more 2D primitives
/// </summary>
////////////////////////////////////////////////////////////
public sealed class VertexArray : ObjectBase, IDrawable
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Default constructor
    /// </summary>
    ////////////////////////////////////////////////////////////
    public VertexArray() :
        base(CSFMLGraphics.sfVertexArray_create())
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the vertex array with a <see cref="SFML.Graphics.PrimitiveType"/>
    /// </summary>
    /// <param name="type">Type of primitives</param>
    ////////////////////////////////////////////////////////////
    public VertexArray(PrimitiveType type) :
        base(CSFMLGraphics.sfVertexArray_create()) => PrimitiveType = type;

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct the vertex array with a <see cref="SFML.Graphics.PrimitiveType"/> and an initial number of vertices
    /// </summary>
    /// <param name="type">Type of primitives</param>
    /// <param name="vertexCount">Initial number of vertices in the array</param>
    ////////////////////////////////////////////////////////////
    public VertexArray(PrimitiveType type, uint vertexCount) :
        base(CSFMLGraphics.sfVertexArray_create())
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
        base(CSFMLGraphics.sfVertexArray_copy(copy.CPointer))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Total <see cref="Vertex"/> count
    /// </summary>
    ////////////////////////////////////////////////////////////
    public uint VertexCount => (uint)CSFMLGraphics.sfVertexArray_getVertexCount(CPointer);

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
                return *CSFMLGraphics.sfVertexArray_getVertex(CPointer, (UIntPtr)index);
            }
        }
        set
        {
            unsafe
            {
                *CSFMLGraphics.sfVertexArray_getVertex(CPointer, (UIntPtr)index) = value;
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Clear the vertex array
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void Clear() => CSFMLGraphics.sfVertexArray_clear(CPointer);

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
    public void Resize(uint vertexCount) => CSFMLGraphics.sfVertexArray_resize(CPointer, (UIntPtr)vertexCount);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Add a <see cref="Vertex" /> to the array
    /// </summary>
    /// <param name="vertex">Vertex to add</param>
    ////////////////////////////////////////////////////////////
    public void Append(Vertex vertex) => CSFMLGraphics.sfVertexArray_append(CPointer, vertex);

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
        get => CSFMLGraphics.sfVertexArray_getPrimitiveType(CPointer);
        set => CSFMLGraphics.sfVertexArray_setPrimitiveType(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Compute the bounding rectangle of the vertex array.
    /// </summary>
    /// <remarks>
    /// Contains the axis-aligned <see cref="FloatRect"/> that contains all the vertices of the array.
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public FloatRect Bounds => CSFMLGraphics.sfVertexArray_getBounds(CPointer);

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
            CSFMLGraphics.sfRenderWindow_drawVertexArray(window.CPointer, CPointer, ref marshaledStates);
        }
        else if (target is RenderTexture texture)
        {
            CSFMLGraphics.sfRenderTexture_drawVertexArray(texture.CPointer, CPointer, ref marshaledStates);
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing) => CSFMLGraphics.sfVertexArray_destroy(CPointer);
}
