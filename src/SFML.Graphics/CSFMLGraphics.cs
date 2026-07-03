using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Gaiden.SFML.System;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Gaiden.SFML.Graphics;

public static partial class CSFMLGraphics
{
    #region View
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfView_create();

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfView_createFromRect(FloatRect rect);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfView_copy(IntPtr view);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfView_destroy(IntPtr view);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfView_setCenter(IntPtr view, Vector2f center);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfView_setSize(IntPtr view, Vector2f size);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfView_setRotation(IntPtr view, float angle);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfView_setViewport(IntPtr view, FloatRect viewport);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfView_setScissor(IntPtr view, FloatRect viewport);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2f sfView_getCenter(IntPtr view);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2f sfView_getSize(IntPtr view);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfView_getRotation(IntPtr view);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial FloatRect sfView_getViewport(IntPtr view);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial FloatRect sfView_getScissor(IntPtr view);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfView_move(IntPtr view, Vector2f offset);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfView_rotate(IntPtr view, float angle);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfView_zoom(IntPtr view, float factor);
    #endregion

    #region VertexBuffer
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfVertexBuffer_create(uint vertexCount, PrimitiveType type, VertexBuffer.UsageSpecifier usage);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfVertexBuffer_copy(IntPtr copy);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfVertexBuffer_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfVertexBuffer_getVertexCount(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static unsafe partial bool sfVertexBuffer_update(IntPtr cPointer, Vertex* vertices, uint vertexCount, uint offset);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfVertexBuffer_updateFromVertexBuffer(IntPtr cPointer, IntPtr other);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfVertexBuffer_swap(IntPtr cPointer, IntPtr other);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfVertexBuffer_getNativeHandle(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfVertexBuffer_setPrimitiveType(IntPtr cPointer, PrimitiveType primitiveType);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial PrimitiveType sfVertexBuffer_getPrimitiveType(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfVertexBuffer_setUsage(IntPtr cPointer, VertexBuffer.UsageSpecifier usageType);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial VertexBuffer.UsageSpecifier sfVertexBuffer_getUsage(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfVertexBuffer_bind(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfVertexBuffer_isAvailable();

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_drawVertexBuffer(IntPtr cPointer, IntPtr vertexArray, ref RenderStates.MarshalData states);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_drawVertexBufferRange(IntPtr cPointer, IntPtr vertexBuffer, UIntPtr firstVertex, UIntPtr vertexCount, ref RenderStates.MarshalData states);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_drawVertexBuffer(IntPtr cPointer, IntPtr vertexBuffer, ref RenderStates.MarshalData states);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_drawVertexBufferRange(IntPtr cPointer, IntPtr vertexBuffer, UIntPtr firstVertex, UIntPtr vertexCount, ref RenderStates.MarshalData states);
    #endregion

    #region VertexArray
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfVertexArray_create();

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfVertexArray_copy(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfVertexArray_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr sfVertexArray_getVertexCount(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial Vertex* sfVertexArray_getVertex(IntPtr cPointer, UIntPtr index);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfVertexArray_clear(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfVertexArray_resize(IntPtr cPointer, UIntPtr vertexCount);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfVertexArray_append(IntPtr cPointer, Vertex vertex);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfVertexArray_setPrimitiveType(IntPtr cPointer, PrimitiveType type);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial PrimitiveType sfVertexArray_getPrimitiveType(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial FloatRect sfVertexArray_getBounds(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_drawVertexArray(IntPtr cPointer, IntPtr vertexArray, ref RenderStates.MarshalData states);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_drawVertexArray(IntPtr cPointer, IntPtr vertexArray, ref RenderStates.MarshalData states);
    #endregion

    #region Transform
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Transform sfTransform_getInverse(ref Transform transform);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2f sfTransform_transformPoint(ref Transform transform, Vector2f point);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial FloatRect sfTransform_transformRect(ref Transform transform, FloatRect rectangle);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTransform_combine(ref Transform transform, ref Transform other);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTransform_translate(ref Transform transform, Vector2f offset);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTransform_rotate(ref Transform transform, float angle);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTransform_rotateWithCenter(ref Transform transform, float angle, Vector2f center);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTransform_scale(ref Transform transform, Vector2f scale);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTransform_scaleWithCenter(ref Transform transform, Vector2f scale, Vector2f center);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfTransform_equal(ref Transform left, ref Transform right);
    #endregion
    
    #region Texture
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfTexture_create(Vector2u size);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfTexture_createSrgb(Vector2u size);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfTexture_createFromFile(string filename, ref IntRect area);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfTexture_createSrgbFromFile(string filename, ref IntRect area);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfTexture_createFromStream(IntPtr stream, ref IntRect area);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfTexture_createSrgbFromStream(IntPtr stream, ref IntRect area);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfTexture_createFromImage(IntPtr image, ref IntRect area);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfTexture_createSrgbFromImage(IntPtr image, ref IntRect area);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfTexture_createFromMemory(IntPtr data, UIntPtr size, ref IntRect area);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfTexture_createSrgbFromMemory(IntPtr data, UIntPtr size, ref IntRect area);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfTexture_copy(IntPtr texture);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTexture_destroy(IntPtr texture);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool sfTexture_resize(IntPtr texture, Vector2u size);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool sfTexture_resizeSrgb(IntPtr texture, Vector2u size);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2u sfTexture_getSize(IntPtr texture);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfTexture_copyToImage(IntPtr texture);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfTexture_updateFromPixels(IntPtr texture, byte* pixels, Vector2u size, Vector2u offset);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTexture_updateFromTexture(IntPtr cPointer, IntPtr texture, Vector2u offset);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTexture_updateFromImage(IntPtr texture, IntPtr image, Vector2u offset);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTexture_updateFromWindow(IntPtr texture, IntPtr window, Vector2u offset);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTexture_updateFromRenderWindow(IntPtr texture, IntPtr renderWindow, Vector2u offset);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTexture_bind(IntPtr texture, CoordinateType type);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTexture_setSmooth(IntPtr texture, [MarshalAs(UnmanagedType.Bool)] bool smooth);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfTexture_isSmooth(IntPtr texture);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfTexture_isSrgb(IntPtr texture);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTexture_setRepeated(IntPtr texture, [MarshalAs(UnmanagedType.Bool)] bool repeated);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfTexture_isRepeated(IntPtr texture);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfTexture_generateMipmap(IntPtr texture);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfTexture_swap(IntPtr cPointer, IntPtr right);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfTexture_getNativeHandle(IntPtr shader);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfTexture_getMaximumSize();
    #endregion
    
    #region Text
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfText_create(IntPtr font);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfText_copy(IntPtr text);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfText_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfText_setFillColor(IntPtr cPointer, Color color);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfText_setOutlineColor(IntPtr cPointer, Color color);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfText_setOutlineThickness(IntPtr cPointer, float thickness);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Color sfText_getFillColor(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Color sfText_getOutlineColor(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfText_getOutlineThickness(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_drawText(IntPtr cPointer, IntPtr text, ref RenderStates.MarshalData states);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_drawText(IntPtr cPointer, IntPtr text, ref RenderStates.MarshalData states);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfText_setUnicodeString(IntPtr cPointer, IntPtr text);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfText_setFont(IntPtr cPointer, IntPtr font);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfText_setCharacterSize(IntPtr cPointer, uint size);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfText_setLineSpacing(IntPtr cPointer, float spacingFactor);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfText_setLetterSpacing(IntPtr cPointer, float spacingFactor);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfText_setStyle(IntPtr cPointer, Text.Styles style);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfText_getUnicodeString(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfText_getCharacterSize(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfText_getLetterSpacing(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfText_getLineSpacing(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Text.Styles sfText_getStyle(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2f sfText_findCharacterPos(IntPtr cPointer, UIntPtr index);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial FloatRect sfText_getLocalBounds(IntPtr cPointer);
    #endregion
    
    #region Sprite
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfSprite_create(IntPtr texture);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfSprite_copy(IntPtr sprite);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSprite_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSprite_setColor(IntPtr cPointer, Color color);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Color sfSprite_getColor(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_drawSprite(IntPtr cPointer, IntPtr sprite, ref RenderStates.MarshalData states);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_drawSprite(IntPtr cPointer, IntPtr sprite, ref RenderStates.MarshalData states);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSprite_setTexture(IntPtr cPointer, IntPtr texture, [MarshalAs(UnmanagedType.Bool)] bool adjustToNewSize);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSprite_setTextureRect(IntPtr cPointer, IntRect rect);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntRect sfSprite_getTextureRect(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial FloatRect sfSprite_getLocalBounds(IntPtr cPointer);
    #endregion
    
    #region Shape
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfShape_create(Shape.GetPointCountCallbackType getPointCount, Shape.GetPointCallbackType getPoint, IntPtr userData);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShape_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShape_setTexture(IntPtr cPointer, IntPtr texture, [MarshalAs(UnmanagedType.Bool)] bool adjustToNewSize);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShape_setTextureRect(IntPtr cPointer, IntRect rect);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntRect sfShape_getTextureRect(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShape_setFillColor(IntPtr cPointer, Color color);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Color sfShape_getFillColor(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShape_setOutlineColor(IntPtr cPointer, Color color);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Color sfShape_getOutlineColor(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShape_setOutlineThickness(IntPtr cPointer, float thickness);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfShape_getOutlineThickness(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2f sfShape_getGeometricCenter(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial FloatRect sfShape_getLocalBounds(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShape_update(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_drawShape(IntPtr cPointer, IntPtr shape, ref RenderStates.MarshalData states);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_drawShape(IntPtr cPointer, IntPtr shape, ref RenderStates.MarshalData states);
    #endregion
    
    #region Shader
    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfShader_createFromFile(string vertexShaderFilename, string geometryShaderFilename, string fragmentShaderFilename);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfShader_createFromMemory(string vertexShader, string geometryShader, string fragmentShader);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfShader_createFromStream(IntPtr vertexShaderStream, IntPtr geometryShaderStream, IntPtr fragmentShaderStream);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_destroy(IntPtr shader);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setFloatUniform(IntPtr shader, string name, float x);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setVec2Uniform(IntPtr shader, string name, Vec2 vector);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setVec3Uniform(IntPtr shader, string name, Vec3 vector);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setVec4Uniform(IntPtr shader, string name, Vec4 vector);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setIntUniform(IntPtr shader, string name, int x);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setColorUniform(IntPtr shader, string name, Color color);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setIvec2Uniform(IntPtr shader, string name, Ivec2 vector);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setIvec3Uniform(IntPtr shader, string name, Ivec3 vector);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setIvec4Uniform(IntPtr shader, string name, Ivec4 vector);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setBoolUniform(IntPtr shader, string name, [MarshalAs(UnmanagedType.Bool)] bool x);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setBvec2Uniform(IntPtr shader, string name, Bvec2 vector);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setBvec3Uniform(IntPtr shader, string name, Bvec3 vector);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setBvec4Uniform(IntPtr shader, string name, Bvec4 vector);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setMat3Uniform(IntPtr shader, string name, Mat3 matrix);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setMat4Uniform(IntPtr shader, string name, Mat4 matrix);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setTextureUniform(IntPtr shader, string name, IntPtr texture);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_setCurrentTextureUniform(IntPtr shader, string name);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfShader_setFloatUniformArray(IntPtr shader, string name, float* data, UIntPtr length);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfShader_setVec2UniformArray(IntPtr shader, string name, Vec2* data, UIntPtr length);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfShader_setVec3UniformArray(IntPtr shader, string name, Vec3* data, UIntPtr length);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfShader_setVec4UniformArray(IntPtr shader, string name, Vec4* data, UIntPtr length);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfShader_setMat3UniformArray(IntPtr shader, string name, Mat3* data, UIntPtr length);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfShader_setMat4UniformArray(IntPtr shader, string name, Mat4* data, UIntPtr length);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfShader_getNativeHandle(IntPtr shader);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfShader_bind(IntPtr shader);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfShader_isAvailable();

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfShader_isGeometryAvailable();
    #endregion

    #region RenderWindow
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfRenderWindow_createUnicode(Window.VideoMode mode, IntPtr title, Window.Styles style, Window.State state, ref Window.ContextSettings settings);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfRenderWindow_createFromHandle(IntPtr handle, ref Window.ContextSettings settings);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_close(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfRenderWindow_isOpen(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Window.ContextSettings sfRenderWindow_getSettings(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfRenderWindow_pollEvent(IntPtr cPointer, out Window.Event evt);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfRenderWindow_waitEvent(IntPtr cPointer, Time timeout, out Window.Event evt);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2i sfRenderWindow_getPosition(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_setPosition(IntPtr cPointer, Vector2i position);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2u sfRenderWindow_getSize(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfRenderWindow_isSrgb(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_setSize(IntPtr cPointer, Vector2u size);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfRenderWindow_setMinimumSize(IntPtr cPointer, Vector2u* minimumSize);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfRenderWindow_setMaximumSize(IntPtr cPointer, Vector2u* maximumSize);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_setUnicodeTitle(IntPtr cPointer, IntPtr title);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfRenderWindow_setIcon(IntPtr cPointer, Vector2u size, byte* pixels);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_setVisible(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_setVerticalSyncEnabled(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool enable);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_setMouseCursorVisible(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_setMouseCursorGrabbed(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool grabbed);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_setMouseCursor(IntPtr window, IntPtr cursor);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_setKeyRepeatEnabled(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool enable);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_setFramerateLimit(IntPtr cPointer, uint limit);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_setJoystickThreshold(IntPtr cPointer, float threshold);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfRenderWindow_setActive(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool active);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_requestFocus(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfRenderWindow_hasFocus(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_display(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfRenderWindow_getNativeHandle(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_clear(IntPtr cPointer, Color clearColor);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_clearStencil(IntPtr cPointer, StencilValue stencilValue);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_clearColorAndStencil(IntPtr cPointer, Color clearColor, StencilValue stencilValue);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_setView(IntPtr cPointer, IntPtr view);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfRenderWindow_getView(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfRenderWindow_getDefaultView(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntRect sfRenderWindow_getViewport(IntPtr cPointer, IntPtr targetView);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntRect sfRenderWindow_getScissor(IntPtr cPointer, IntPtr targetView);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2f sfRenderWindow_mapPixelToCoords(IntPtr cPointer, Vector2i point, IntPtr view);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2i sfRenderWindow_mapCoordsToPixel(IntPtr cPointer, Vector2f point, IntPtr view);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfRenderWindow_drawPrimitives(IntPtr cPointer, Vertex* vertexPtr, UIntPtr vertexCount, PrimitiveType type, ref RenderStates.MarshalData renderStates);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_pushGLStates(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_popGLStates(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderWindow_resetGLStates(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2i sfMouse_getPositionRenderWindow(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMouse_setPositionRenderWindow(Vector2i position, IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2i sfTouch_getPositionRenderWindow(uint finger, IntPtr relativeTo);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfRenderWindow_createVulkanSurface(IntPtr cPointer, IntPtr vkInstance, out IntPtr surface, IntPtr vkAllocator);
    #endregion

    #region RenderTexture
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfRenderTexture_create(Vector2u size, ref Window.ContextSettings settings);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_clear(IntPtr cPointer, Color clearColor);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_clearStencil(IntPtr cPointer, StencilValue stencilValue);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_clearColorAndStencil(IntPtr cPointer, Color clearColor, StencilValue stencilValue);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2u sfRenderTexture_getSize(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfRenderTexture_isSrgb(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfRenderTexture_setActive(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool active);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_display(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_setView(IntPtr cPointer, IntPtr view);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfRenderTexture_getView(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfRenderTexture_getDefaultView(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntRect sfRenderTexture_getViewport(IntPtr cPointer, IntPtr targetView);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntRect sfRenderTexture_getScissor(IntPtr cPointer, IntPtr targetView);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2i sfRenderTexture_mapCoordsToPixel(IntPtr cPointer, Vector2f point, IntPtr view);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2f sfRenderTexture_mapPixelToCoords(IntPtr cPointer, Vector2i point, IntPtr view);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfRenderTexture_getTexture(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfRenderTexture_getMaximumAntiAliasingLevel();

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_setSmooth(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool smooth);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfRenderTexture_isSmooth(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_setRepeated(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool repeated);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfRenderTexture_isRepeated(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfRenderTexture_generateMipmap(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void sfRenderTexture_drawPrimitives(IntPtr cPointer, Vertex* vertexPtr, UIntPtr vertexCount, PrimitiveType type, ref RenderStates.MarshalData renderStates);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_pushGLStates(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_popGLStates(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfRenderTexture_resetGLStates(IntPtr cPointer);
    #endregion
    
    #region CircleShape
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2f sfCircleShape_getGeometricCenter(IntPtr cPointer);
    #endregion
    
    #region Font
    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfFont_createFromFile(string filename);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfFont_createFromStream(IntPtr stream);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfFont_createFromMemory(IntPtr data, UIntPtr size);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfFont_copy(IntPtr font);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfFont_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Glyph sfFont_getGlyph(IntPtr cPointer, uint codePoint, uint characterSize, [MarshalAs(UnmanagedType.Bool)] bool bold, float outlineThickness);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfFont_hasGlyph(IntPtr font, uint codePoint);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfFont_getKerning(IntPtr cPointer, uint first, uint second, uint characterSize);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfFont_getBoldKerning(IntPtr cPointer, uint first, uint second, uint characterSize);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfFont_getLineSpacing(IntPtr cPointer, uint characterSize);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfFont_getUnderlinePosition(IntPtr cPointer, uint characterSize);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfFont_getUnderlineThickness(IntPtr cPointer, uint characterSize);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfFont_getTexture(IntPtr cPointer, uint characterSize);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfFont_setSmooth(IntPtr cPointer, [MarshalAs(UnmanagedType.Bool)] bool smooth);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfFont_isSmooth(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Font.InfoMarshalData sfFont_getInfo(IntPtr cPointer);
    #endregion

    #region Image
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfImage_createFromColor(Vector2u size, Color col);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial IntPtr sfImage_createFromPixels(Vector2u size, byte* pixels);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfImage_createFromFile(string filename);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfImage_createFromStream(IntPtr stream);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfImage_createFromMemory(IntPtr data, UIntPtr size);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfImage_copy(IntPtr image);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfImage_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfImage_saveToFile(IntPtr cPointer, string filename);

    [LibraryImport(CSFML.Graphics, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfImage_saveToMemory(IntPtr cPointer, IntPtr bufferOutput, string format);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfImage_createMaskFromColor(IntPtr cPointer, Color col, byte alpha);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfImage_copyImage(IntPtr cPointer, IntPtr source, Vector2u dest, IntRect sourceRect, [MarshalAs(UnmanagedType.Bool)] bool applyAlpha);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfImage_setPixel(IntPtr cPointer, Vector2u coords, Color col);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Color sfImage_getPixel(IntPtr cPointer, Vector2u coords);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfImage_getPixelsPtr(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2u sfImage_getSize(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfImage_flipHorizontally(IntPtr cPointer);

    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfImage_flipVertically(IntPtr cPointer);
    #endregion
    
    #region RectangleShape
    [LibraryImport(CSFML.Graphics), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector2f sfRectangleShape_getGeometricCenter(IntPtr cPointer);
    #endregion
}