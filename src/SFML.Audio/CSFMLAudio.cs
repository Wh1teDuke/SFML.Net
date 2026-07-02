using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Gaiden.SFML.System;

namespace Gaiden.SFML.Audio;

public static partial class CSFMLAudio
{
    #region Sound
    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfSound_create(IntPtr soundBuffer);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfSound_copy(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_destroy(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_play(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_pause(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_stop(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setBuffer(IntPtr sound, IntPtr buffer);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setLooping(IntPtr sound, [MarshalAs(UnmanagedType.Bool)] bool loop);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfSound_isLooping(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SoundStatus sfSound_getStatus(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setPitch(IntPtr sound, float pitch);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setPan(IntPtr sound, float pan);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setVolume(IntPtr sound, float volume);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setSpatializationEnabled(IntPtr sound, [MarshalAs(UnmanagedType.Bool)] bool enabled);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setPosition(IntPtr sound, Vector3f position);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setDirection(IntPtr sound, Vector3f direction);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void sfSound_setCone(IntPtr sound, Cone.MarshalData cone);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setVelocity(IntPtr sound, Vector3f velocity);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setDopplerFactor(IntPtr sound, float factor);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setDirectionalAttenuationFactor(IntPtr sound, float factor);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setRelativeToListener(IntPtr sound, [MarshalAs(UnmanagedType.Bool)] bool relative);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setMinDistance(IntPtr sound, float minDistance);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setMaxDistance(IntPtr sound, float maxDistance);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setMinGain(IntPtr sound, float gain);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setMaxGain(IntPtr sound, float gain);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setAttenuation(IntPtr sound, float attenuation);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setPlayingOffset(IntPtr sound, Time timeOffset);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSound_setEffectProcessor(IntPtr sound, IntPtr effectProcessor);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSound_getPitch(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSound_getPan(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSound_getVolume(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfSound_isSpatializationEnabled(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfSound_getPosition(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfSound_getDirection(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial Cone.MarshalData sfSound_getCone(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfSound_getVelocity(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSound_getDopplerFactor(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSound_getDirectionalAttenuationFactor(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfSound_isRelativeToListener(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSound_getMinDistance(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSound_getMaxDistance(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSound_getMinGain(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSound_getMaxGain(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSound_getAttenuation(IntPtr sound);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Time sfSound_getPlayingOffset(IntPtr sound);
    #endregion
    
    #region Music
        [LibraryImport(CSFML.Audio, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfMusic_createFromFile(string filename);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial IntPtr sfMusic_createFromStream(IntPtr stream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfMusic_createFromMemory(IntPtr data, UIntPtr size);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_destroy(IntPtr musicStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_play(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_pause(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_stop(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial SoundChannel* sfMusic_getChannelMap(IntPtr music, out UIntPtr count);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SoundStatus sfMusic_getStatus(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Time sfMusic_getPlayingOffset(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Time sfMusic_getDuration(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Music.TimeSpan sfMusic_getLoopPoints(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setLoopPoints(IntPtr music, Music.TimeSpan timePoints);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfMusic_getChannelCount(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfMusic_getSampleRate(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setPitch(IntPtr music, float pitch);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setPan(IntPtr music, float pan);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setLooping(IntPtr music, [MarshalAs(UnmanagedType.Bool)] bool loop);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setVolume(IntPtr music, float volume);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setSpatializationEnabled(IntPtr music, [MarshalAs(UnmanagedType.Bool)] bool enabled);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setPosition(IntPtr music, Vector3f position);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setDirection(IntPtr music, Vector3f direction);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void sfMusic_setCone(IntPtr music, Cone.MarshalData cone);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setVelocity(IntPtr music, Vector3f velocity);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setDopplerFactor(IntPtr music, float factor);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setDirectionalAttenuationFactor(IntPtr music, float factor);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setRelativeToListener(IntPtr music, [MarshalAs(UnmanagedType.Bool)] bool relative);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setMinDistance(IntPtr music, float minDistance);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setMaxDistance(IntPtr music, float maxDistance);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setMinGain(IntPtr music, float gain);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setMaxGain(IntPtr music, float gain);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setAttenuation(IntPtr music, float attenuation);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setPlayingOffset(IntPtr music, Time timeOffset);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfMusic_isLooping(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfMusic_setEffectProcessor(IntPtr music, IntPtr effectProcessor);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfMusic_getPitch(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfMusic_getPan(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfMusic_isSpatializationEnabled(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfMusic_getVolume(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfMusic_getPosition(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfMusic_getDirection(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial Cone.MarshalData sfMusic_getCone(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfMusic_getVelocity(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfMusic_getDopplerFactor(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfMusic_getDirectionalAttenuationFactor(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfMusic_isRelativeToListener(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfMusic_getMinDistance(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfMusic_getMaxDistance(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfMusic_getMinGain(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfMusic_getMaxGain(IntPtr music);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfMusic_getAttenuation(IntPtr music);
    #endregion
    
    #region SoundBuffer
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
    #endregion
    
    #region SoundStream
    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static unsafe partial IntPtr sfSoundStream_create(
        SoundStream.GetDataCallbackType onGetData, 
        SoundStream.SeekCallbackType onSeek, uint channelCount, uint sampleRate, SoundChannel* channelMapData, UIntPtr channelMapSize, IntPtr userData);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_destroy(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_play(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_pause(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_stop(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SoundStatus sfSoundStream_getStatus(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfSoundStream_getChannelCount(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfSoundStream_getSampleRate(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial SoundChannel* sfSoundStream_getChannelMap(IntPtr soundStream, out UIntPtr count);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setPitch(IntPtr soundStream, float pitch);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setPan(IntPtr soundStream, float pan);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setVolume(IntPtr soundStream, float volume);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setSpatializationEnabled(IntPtr soundStream, [MarshalAs(UnmanagedType.Bool)] bool enabled);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setPosition(IntPtr soundStream, Vector3f position);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setDirection(IntPtr soundStream, Vector3f direction);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void sfSoundStream_setCone(IntPtr soundStream, Cone.MarshalData cone);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setVelocity(IntPtr soundStream, Vector3f velocity);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setDopplerFactor(IntPtr soundStream, float factor);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setDirectionalAttenuationFactor(IntPtr soundStream, float factor);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setRelativeToListener(IntPtr soundStream, [MarshalAs(UnmanagedType.Bool)] bool relative);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setMinDistance(IntPtr soundStream, float minDistance);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setMaxDistance(IntPtr soundStream, float maxDistance);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setMinGain(IntPtr soundStream, float gain);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setMaxGain(IntPtr soundStream, float gain);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setAttenuation(IntPtr soundStream, float attenuation);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setPlayingOffset(IntPtr soundStream, Time timeOffset);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setLooping(IntPtr soundStream, [MarshalAs(UnmanagedType.Bool)] bool loop);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSoundStream_getPitch(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSoundStream_getPan(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSoundStream_getVolume(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfSoundStream_isSpatializationEnabled(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfSoundStream_getPosition(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfSoundStream_getDirection(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial Cone.MarshalData sfSoundStream_getCone(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfSoundStream_getVelocity(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSoundStream_getDopplerFactor(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSoundStream_getDirectionalAttenuationFactor(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfSoundStream_isRelativeToListener(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSoundStream_getMinDistance(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSoundStream_getMaxDistance(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSoundStream_getMinGain(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSoundStream_getMaxGain(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfSoundStream_getAttenuation(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfSoundStream_isLooping(IntPtr soundStream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundStream_setEffectProcessor(IntPtr soundStream, IntPtr effectProcessor);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Time sfSoundStream_getPlayingOffset(IntPtr soundStream);
    #endregion
    
    #region SoundRecorder
        [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfSoundRecorder_create(
        SoundRecorder.StartCallback onStart, 
        SoundRecorder.ProcessCallback onProcess, 
        SoundRecorder.StopCallback onStop, IntPtr userData);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundRecorder_destroy(IntPtr soundRecorder);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfSoundRecorder_start(IntPtr soundRecorder, uint sampleRate);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundRecorder_stop(IntPtr soundRecorder);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfSoundRecorder_getSampleRate(IntPtr soundRecorder);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfSoundRecorder_isAvailable();

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial IntPtr* sfSoundRecorder_getAvailableDevices(out UIntPtr count);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfSoundRecorder_getDefaultDevice();

    [LibraryImport(CSFML.Audio, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfSoundRecorder_setDevice(IntPtr soundRecorder, string name);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfSoundRecorder_getDevice(IntPtr soundRecorder);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfSoundRecorder_setChannelCount(IntPtr soundRecorder, uint channelCount);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint sfSoundRecorder_getChannelCount(IntPtr soundRecorder);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial SoundChannel* sfSoundRecorder_getChannelMap(IntPtr soundRecorder, out UIntPtr count);
    #endregion
    
    #region Listener
        [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfListener_setGlobalVolume(float volume);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float sfListener_getGlobalVolume();

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfListener_setPosition(Vector3f position);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfListener_getPosition();

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfListener_setDirection(Vector3f direction);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfListener_getDirection();

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfListener_setVelocity(Vector3f direction);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfListener_getVelocity();

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void sfListener_setCone(Cone.MarshalData cone);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial Cone.MarshalData sfListener_getCone();

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfListener_setUpVector(Vector3f upVector);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Vector3f sfListener_getUpVector();
    #endregion
}