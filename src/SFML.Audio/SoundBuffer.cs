using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Gaiden.SFML.System;

namespace Gaiden.SFML.Audio;

////////////////////////////////////////////////////////////
/// <summary>
/// Storage for audio samples defining a sound
/// </summary>
////////////////////////////////////////////////////////////
public partial class SoundBuffer : ObjectBase
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct a sound buffer from a file
    ///
    /// Here is a complete list of all the supported audio formats:
    /// ogg, wav, flac, mp3, aiff, au, raw, paf, svx, nist, voc, ircam,
    /// w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
    /// </summary>
    /// <param name="filename">Path of the sound file to load</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public SoundBuffer(string filename) :
        base(sfSoundBuffer_createFromFile(filename))
    {
        if (IsInvalid)
        {
            throw new LoadingFailedException("sound buffer", filename);
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct a sound buffer from a custom stream.
    ///
    /// Here is a complete list of all the supported audio formats:
    /// ogg, wav, flac, mp3, aiff, au, raw, paf, svx, nist, voc, ircam,
    /// w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
    /// </summary>
    /// <param name="stream">Source stream to read from</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public SoundBuffer(Stream stream) :
        base(IntPtr.Zero)
    {
        using (var adaptor = new StreamAdaptor(stream))
        {
            CPointer = sfSoundBuffer_createFromStream(adaptor.InputStreamPtr);
        }

        if (IsInvalid)
        {
            throw new LoadingFailedException("sound buffer");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct a sound buffer from a file in memory.
    ///
    /// Here is a complete list of all the supported audio formats:
    /// ogg, wav, flac, mp3, aiff, au, raw, paf, svx, nist, voc, ircam,
    /// w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
    /// </summary>
    /// <param name="bytes">Byte array containing the file contents</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public SoundBuffer(byte[] bytes) :
        base(IntPtr.Zero)
    {
        unsafe
        {
            fixed (void* ptr = bytes)
            {
                CPointer = sfSoundBuffer_createFromMemory((IntPtr)ptr, (UIntPtr)bytes.Length);
            }
        }

        if (IsInvalid)
        {
            throw new LoadingFailedException("sound buffer");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct a sound buffer from an array of samples
    /// </summary>
    /// <param name="samples">Array of samples</param>
    /// <param name="channelCount">Channel count</param>
    /// <param name="sampleRate">Sample rate</param>
    /// <param name="channelMapData">Map of position in sample frame to sound channel</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public SoundBuffer(short[] samples, uint channelCount, uint sampleRate, SoundChannel[] channelMapData) :
        base(IntPtr.Zero)
    {
        unsafe
        {
            fixed (short* samplesPtr = samples)
            {
                fixed (SoundChannel* channels = channelMapData)
                {
                    CPointer = sfSoundBuffer_createFromSamples(samplesPtr, (uint)samples.Length, channelCount, sampleRate, channels, (UIntPtr)channelMapData.Length);
                }
            }
        }

        if (IsInvalid)
        {
            throw new LoadingFailedException("sound buffer");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Construct a sound buffer from another sound buffer
    /// </summary>
    /// <param name="copy">Sound buffer to copy</param>
    ////////////////////////////////////////////////////////////
    public SoundBuffer(SoundBuffer copy) :
        base(sfSoundBuffer_copy(copy.CPointer))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Save the sound buffer to an audio file.
    ///
    /// Here is a complete list of all the supported audio formats:
    /// ogg, wav, flac, mp3, aiff, au, raw, paf, svx, nist, voc, ircam,
    /// w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
    /// </summary>
    /// <param name="filename">Path of the sound file to write</param>
    /// <returns>True if saving has been successful</returns>
    ////////////////////////////////////////////////////////////
    public bool SaveToFile(string filename) => sfSoundBuffer_saveToFile(CPointer, filename);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Sample rate of the sound buffer.
    ///
    /// The sample rate is the number of audio samples played per
    /// second. The higher, the better the quality.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public uint SampleRate => sfSoundBuffer_getSampleRate(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Number of channels (1 = mono, 2 = stereo)
    /// </summary>
    ////////////////////////////////////////////////////////////
    public uint ChannelCount => sfSoundBuffer_getChannelCount(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Total duration of the buffer
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Time Duration => sfSoundBuffer_getDuration(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Array of audio samples stored in the buffer.
    ///
    /// The format of the returned samples is 16 bits signed integer
    /// (sf::Int16).
    /// </summary>
    ////////////////////////////////////////////////////////////
    public short[] Samples
    {
        get
        {
            var samplesArray = new short[sfSoundBuffer_getSampleCount(CPointer)];
            Marshal.Copy(sfSoundBuffer_getSamples(CPointer), samplesArray, 0, samplesArray.Length);
            return samplesArray;
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the map of position in sample frame to sound channel
    /// <para/>
    /// This is used to map a sample in the sample stream to a
    /// position during spatialisation.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public virtual SoundChannel[] ChannelMap
    {
        get
        {
            unsafe
            {
                var channels = sfSoundBuffer_getChannelMap(CPointer, out var count);
                var arr = new SoundChannel[(int)count];

                for (var i = 0; i < arr.Length; i++)
                {
                    arr[i] = channels[i];
                }

                return arr;
            }
        }
    }

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

        return "[SoundBuffer]" +
               " SampleRate(" + SampleRate + ")" +
               " ChannelCount(" + ChannelCount + ")" +
               " Duration(" + Duration + ")";
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing) => sfSoundBuffer_destroy(CPointer);

    #region Imports
    [LibraryImport(CSFML.Audio, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfSoundBuffer_createFromFile(string filename);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfSoundBuffer_createFromStream(IntPtr stream);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfSoundBuffer_createFromMemory(IntPtr data, UIntPtr size);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe partial IntPtr sfSoundBuffer_createFromSamples(short* samples, ulong sampleCount, uint channelsCount, uint sampleRate, SoundChannel* channelMapData, UIntPtr channelMapSize);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfSoundBuffer_copy(IntPtr soundBuffer);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void sfSoundBuffer_destroy(IntPtr soundBuffer);

    [LibraryImport(CSFML.Audio, StringMarshalling = StringMarshalling.Utf8), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    private static partial bool sfSoundBuffer_saveToFile(IntPtr soundBuffer, string filename);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr sfSoundBuffer_getSamples(IntPtr soundBuffer);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ulong sfSoundBuffer_getSampleCount(IntPtr soundBuffer);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial uint sfSoundBuffer_getSampleRate(IntPtr soundBuffer);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial uint sfSoundBuffer_getChannelCount(IntPtr soundBuffer);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe partial SoundChannel* sfSoundBuffer_getChannelMap(IntPtr soundBuffer, out UIntPtr count);

    [LibraryImport(CSFML.Audio), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial Time sfSoundBuffer_getDuration(IntPtr soundBuffer);
    #endregion
}
