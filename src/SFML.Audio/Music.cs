using System.Runtime.InteropServices;
using Gaiden.SFML.System;

namespace Gaiden.SFML.Audio;

////////////////////////////////////////////////////////////
/// <summary>
/// Streamed music played from an audio file
/// </summary>
////////////////////////////////////////////////////////////
public sealed class Music : ObjectBase
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Constructs a music from a file
    ///
    /// This constructor doesn't start playing the music (call
    /// <see cref="Play"/> to do so).
    /// Here is a complete list of all the supported audio formats:
    /// ogg, wav, flac, mp3, aiff, au, raw, paf, svx, nist, voc, ircam,
    /// w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
    /// </summary>
    /// <param name="filename">Path of the music file to open</param>
    ////////////////////////////////////////////////////////////
    public Music(string filename) :
        base(CSFMLAudio.sfMusic_createFromFile(filename))
    {
        if (IsInvalid)
        {
            throw new LoadingFailedException("music", filename);
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Constructs a music from a custom stream
    ///
    /// This constructor doesn't start playing the music (call
    /// <see cref="Play"/> to do so).
    /// Here is a complete list of all the supported audio formats:
    /// ogg, wav, flac, mp3, aiff, au, raw, paf, svx, nist, voc, ircam,
    /// w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
    /// </summary>
    /// <param name="stream">Source stream to read from</param>
    ////////////////////////////////////////////////////////////
    public Music(Stream stream) :
        base(IntPtr.Zero)
    {
        // Stream needs to stay alive as long as the Music instance is alive
        // Disposing of it can only be done in Music's Dispose method
        _stream = new StreamAdaptor(stream);
        CPointer = CSFMLAudio.sfMusic_createFromStream(_stream.InputStreamPtr);

        if (IsInvalid)
        {
            throw new LoadingFailedException("music");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Constructs a music from an audio file in memory
    ///
    /// This constructor doesn't start playing the music (call
    /// <see cref="Play"/> to do so).
    /// Here is a complete list of all the supported audio formats:
    /// ogg, wav, flac, mp3, aiff, au, raw, paf, svx, nist, voc, ircam,
    /// w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
    /// </summary>
    /// <param name="bytes">Byte array containing the file contents</param>
    /// <exception cref="LoadingFailedException" />
    ////////////////////////////////////////////////////////////
    public Music(byte[] bytes) :
        base(IntPtr.Zero)
    {
        // Memory needs to stay pinned as long as the Music instance is alive
        // Freeing the handle can only be done in Music's Dispose method
        _bytesPin = GCHandle.Alloc(bytes, GCHandleType.Pinned);
        CPointer = CSFMLAudio.sfMusic_createFromMemory(_bytesPin.AddrOfPinnedObject(), (UIntPtr)bytes.Length);

        if (IsInvalid)
        {
            _bytesPin.Free();
            throw new LoadingFailedException("music");
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Start or resume playing the audio stream.
    ///
    /// This function starts the stream if it was stopped, resumes
    /// it if it was paused, and restarts it from beginning if it
    /// was it already playing.
    /// This function uses its own thread so that it doesn't block
    /// the rest of the program while the stream is played.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void Play() => CSFMLAudio.sfMusic_play(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Pause the audio stream.
    ///
    /// This function pauses the stream if it was playing,
    /// otherwise (stream already paused or stopped) it has no effect.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void Pause() => CSFMLAudio.sfMusic_pause(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Stop playing the audio stream.
    ///
    /// This function stops the stream if it was playing or paused,
    /// and does nothing if it was already stopped.
    /// It also resets the playing position (unlike Pause()).
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void Stop() => CSFMLAudio.sfMusic_stop(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Sample rate of the music.
    ///
    /// The sample rate is the number of audio samples played per
    /// second. The higher, the better the quality.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public uint SampleRate => CSFMLAudio.sfMusic_getSampleRate(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the map of position in sample frame to sound channel
    /// <para/>
    /// This is used to map a sample in the sample stream to a
    /// position during spatialisation.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public ReadOnlySpan<SoundChannel> ChannelMap
    {
        get
        {
            unsafe
            {
                var channels = CSFMLAudio.sfMusic_getChannelMap(
                    CPointer, out var count);
                Array.Resize(ref _channels, (int)count);

                for (var i = 0; i < _channels.Length; i++)
                {
                    _channels[i] = channels[i];
                }
            }
            
            return _channels;
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Number of channels (1 = mono, 2 = stereo)
    /// </summary>
    ////////////////////////////////////////////////////////////
    public uint ChannelCount => CSFMLAudio.sfMusic_getChannelCount(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Current status of the music (see SoundStatus enum)
    /// </summary>
    ////////////////////////////////////////////////////////////
    public SoundStatus Status => CSFMLAudio.sfMusic_getStatus(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Total duration of the music
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Time Duration => CSFMLAudio.sfMusic_getDuration(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Flag if the music should loop after reaching the end.
    ///
    /// If set, the music will restart from beginning after
    /// reaching the end and so on, until it is stopped or
    /// IsLooping = false is set.
    /// The default looping state for music is false.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public bool IsLooping
    {
        get => CSFMLAudio.sfMusic_isLooping(CPointer);
        set => CSFMLAudio.sfMusic_setLooping(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Pitch of the music.
    ///
    /// The pitch represents the perceived fundamental frequency
    /// of a sound; thus you can make a sound more acute or grave
    /// by changing its pitch. A side effect of changing the pitch
    /// is to modify the playing speed of the sound as well.
    /// The default value for the pitch is 1.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public float Pitch
    {
        get => CSFMLAudio.sfMusic_getPitch(CPointer);
        set => CSFMLAudio.sfMusic_setPitch(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Set the pan of the sound
    /// <para/>
    /// Using panning, a mono sound can be panned between
    /// stereo channels. When the pan is set to -1, the sound
    /// is played only on the left channel, when the pan is set
    /// to +1, the sound is played only on the right channel.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public float Pan
    {
        get => CSFMLAudio.sfMusic_getPan(CPointer);
        set => CSFMLAudio.sfMusic_setPan(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Volume of the music.
    ///
    /// The volume is a value between 0 (mute) and 100 (full volume).
    /// The default value for the volume is 100.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public float Volume
    {
        get => CSFMLAudio.sfMusic_getVolume(CPointer);
        set => CSFMLAudio.sfMusic_setVolume(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Gets or sets whether spatialization of the sound is enabled
    /// <para/>
    /// Spatialization is the application of various effects to
    /// simulate a sound being emitted at a virtual position in
    /// 3D space and exhibiting various physical phenomena such as
    /// directional attenuation and doppler shift.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public bool IsSpatializationEnabled
    {
        get => CSFMLAudio.sfMusic_isSpatializationEnabled(CPointer);
        set => CSFMLAudio.sfMusic_setSpatializationEnabled(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// 3D position of the music in the audio scene.
    /// <para/>
    /// Only sounds with one channel (mono sounds) can be
    /// spatialized.
    /// The default position of a sound is (0, 0, 0).
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Vector3f Position
    {
        get => CSFMLAudio.sfMusic_getPosition(CPointer);
        set => CSFMLAudio.sfMusic_setPosition(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// 3D direction of the sound in the audio scene
    /// <para/>
    /// The direction defines where the sound source is facing
    /// in 3D space. It will affect how the sound is attenuated
    /// if facing away from the listener.
    /// The default direction of a sound is (0, 0, -1).
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Vector3f Direction
    {
        get => CSFMLAudio.sfMusic_getDirection(CPointer);
        set => CSFMLAudio.sfMusic_setDirection(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Set the cone properties of the sound in the audio scene
    /// <para/>
    /// The cone defines how directional attenuation is applied.
    /// The default cone of a sound is (2 * PI, 2 * PI, 1).
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Cone Cone
    {
        get => new(CSFMLAudio.sfMusic_getCone(CPointer));
        set => CSFMLAudio.sfMusic_setCone(CPointer, value.Marshal());
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// 3D velocity of the sound in the audio scene
    /// <para/>
    /// The velocity is used to determine how to doppler shift
    /// the sound. Sounds moving towards the listener will be
    /// perceived to have a higher pitch and sounds moving away
    /// from the listener will be perceived to have a lower pitch.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Vector3f Velocity
    {
        get => CSFMLAudio.sfMusic_getVelocity(CPointer);
        set => CSFMLAudio.sfMusic_setVelocity(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Doppler factor of the sound
    /// <para/>
    /// The doppler factor determines how strong the doppler
    /// shift will be.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public float DopplerFactor
    {
        get => CSFMLAudio.sfMusic_getDopplerFactor(CPointer);
        set => CSFMLAudio.sfMusic_setDopplerFactor(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Directional attenuation factor of the sound
    /// <para/>
    /// Depending on the virtual position of an output channel
    /// relative to the listener (such as in surround sound
    /// setups), sounds will be attenuated when emitting them
    /// from certain channels. This factor determines how strong
    /// the attenuation based on output channel position
    /// relative to the listener is.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public float DirectionalAttenuationFactor
    {
        get => CSFMLAudio.sfMusic_getDirectionalAttenuationFactor(CPointer);
        set => CSFMLAudio.sfMusic_setDirectionalAttenuationFactor(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Make the music's position relative to the listener or absolute.
    ///
    /// Making a sound relative to the listener will ensure that it will always
    /// be played the same way regardless the position of the listener.
    /// This can be useful for non-spatialized sounds, sounds that are
    /// produced by the listener, or sounds attached to it.
    /// The default value is false (position is absolute).
    /// </summary>
    ////////////////////////////////////////////////////////////
    public bool RelativeToListener
    {
        get => CSFMLAudio.sfMusic_isRelativeToListener(CPointer);
        set => CSFMLAudio.sfMusic_setRelativeToListener(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Minimum distance of the music.
    ///
    /// The "minimum distance" of a sound is the maximum
    /// distance at which it is heard at its maximum volume. Further
    /// than the minimum distance, it will start to fade out according
    /// to its attenuation factor. A value of 0 ("inside the head
    /// of the listener") is an invalid value and is forbidden.
    /// The default value of the minimum distance is 1.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public float MinDistance
    {
        get => CSFMLAudio.sfMusic_getMinDistance(CPointer);
        set => CSFMLAudio.sfMusic_setMinDistance(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Maximum distance of the sound
    /// <para/>
    /// The "maximum distance" of a sound is the minimum
    /// distance at which it is heard at its minimum volume. Closer
    /// than the maximum distance, it will start to fade in according
    /// to its attenuation factor.
    /// The default value of the maximum distance is the maximum
    /// value a float can represent.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public float MaxDistance
    {
        get => CSFMLAudio.sfMusic_getMaxDistance(CPointer);
        set => CSFMLAudio.sfMusic_setMaxDistance(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Minimum gain of the sound
    /// <para/>
    /// When the sound is further away from the listener than
    /// the "maximum distance" the attenuated gain is clamped
    /// so it cannot go below the minimum gain value.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public float MinGain
    {
        get => CSFMLAudio.sfMusic_getMinGain(CPointer);
        set => CSFMLAudio.sfMusic_setMinGain(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Maximum gain of the sound
    /// <para/>
    /// When the sound is closer to the listener than
    /// the "minimum distance" the attenuated gain is clamped
    /// so it cannot go above the maximum gain value.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public float MaxGain
    {
        get => CSFMLAudio.sfMusic_getMaxGain(CPointer);
        set => CSFMLAudio.sfMusic_setMaxGain(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Attenuation factor of the music.
    ///
    /// The attenuation is a multiplicative factor which makes
    /// the music more or less loud according to its distance
    /// from the listener. An attenuation of 0 will produce a
    /// non-attenuated sound, i.e. its volume will always be the same
    /// whether it is heard from near or from far. On the other hand,
    /// an attenuation value such as 100 will make the sound fade out
    /// very quickly as it gets further from the listener.
    /// The default value of the attenuation is 1.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public float Attenuation
    {
        get => CSFMLAudio.sfMusic_getAttenuation(CPointer);
        set => CSFMLAudio.sfMusic_setAttenuation(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Current playing position of the music.
    ///
    /// The playing position can be changed when the music is
    /// either paused or playing.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public Time PlayingOffset
    {
        get => CSFMLAudio.sfMusic_getPlayingOffset(CPointer);
        set => CSFMLAudio.sfMusic_setPlayingOffset(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Current loop points of the music.
    ///
    /// Since setting performs some adjustments on the
    /// provided values and rounds them to internal samples, getting this
    /// value later is not guaranteed to return the same times passed
    /// into it. However, it is guaranteed to return times that will map
    /// to the valid internal samples of this Music if they are later
    /// set again.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public TimeSpan LoopPoints
    {
        get => CSFMLAudio.sfMusic_getLoopPoints(CPointer);
        set => CSFMLAudio.sfMusic_setLoopPoints(CPointer, value);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Set the effect processor to be applied to the sound.
    /// <para/>
    /// The effect processor is a callable that will be called
    /// with sound data to be processed.
    /// </summary>
    /// <param name="effectProcessor">The effect processor to attach to this sound, attach a null processor to disable processing</param>
    ////////////////////////////////////////////////////////////
    public void SetEffectProcessor(EffectProcessor effectProcessor)
    {
        EffectProcessorUtil.Set(
            this, effectProcessor, CSFMLAudio.sfMusic_setEffectProcessor, out _effectProcessor);
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

        return "[Music]" +
               " SampleRate(" + SampleRate + ")" +
               " ChannelCount(" + ChannelCount + ")" +
               " Status(" + Status + ")" +
               " Duration(" + Duration + ")" +
               " IsLooping(" + IsLooping + ")" +
               " Pitch(" + Pitch + ")" +
               " Volume(" + Volume + ")" +
               " Position(" + Position + ")" +
               " RelativeToListener(" + RelativeToListener + ")" +
               " MinDistance(" + MinDistance + ")" +
               " Attenuation(" + Attenuation + ")" +
               " PlayingOffset(" + PlayingOffset + ")" +
               " LoopPoints(" + LoopPoints + ")";
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing)
    {
        if (disposing)
        {
            _stream?.Dispose();
        }

        if (_bytesPin.IsAllocated)
        {
            _bytesPin.Free();
        }

        CSFMLAudio.sfMusic_destroy(CPointer);
    }

    private readonly StreamAdaptor? _stream;
    private GCHandle _bytesPin;
    private SoundChannel[]? _channels;
    private EffectProcessorInternal? _effectProcessor;

    /// <summary>
    /// Structure defining a Time range.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TimeSpan
    {
        /// <summary>
        /// Constructs TimeSpan from offset and a length
        /// </summary>
        /// <param name="offset">beginning offset of the time range</param>
        /// <param name="length">length of the time range</param>
        public TimeSpan(Time offset, Time length)
        {
            Offset = offset;
            Length = length;
        }

        /// <summary>
        /// The beginning of the time range
        /// </summary>
        public Time Offset;

        /// <summary>
        /// The length of the time range
        /// </summary>
        public Time Length;
    }
}
