using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Gaiden.SFML.System;

namespace Gaiden.SFML.Audio;

public static partial class CSFMLAudio
{
    [LibraryImport(CSFML.Audio, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfSoundBuffer_createFromFile(string filename);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfSoundBuffer_createFromStream(IntPtr stream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfSoundBuffer_createFromMemory(IntPtr data, UIntPtr size);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial IntPtr sfSoundBuffer_createFromSamples(short* samples, ulong sampleCount, uint channelsCount, uint sampleRate, SoundChannel* channelMapData, UIntPtr channelMapSize);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfSoundBuffer_copy(IntPtr soundBuffer);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundBuffer_destroy(IntPtr soundBuffer);

    [LibraryImport(CSFML.Audio, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfSoundBuffer_saveToFile(IntPtr soundBuffer, string filename);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfSoundBuffer_getSamples(IntPtr soundBuffer);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong sfSoundBuffer_getSampleCount(IntPtr soundBuffer);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfSoundBuffer_getSampleRate(IntPtr soundBuffer);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfSoundBuffer_getChannelCount(IntPtr soundBuffer);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial SoundChannel* sfSoundBuffer_getChannelMap(IntPtr soundBuffer, out UIntPtr count);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Time sfSoundBuffer_getDuration(IntPtr soundBuffer);
}