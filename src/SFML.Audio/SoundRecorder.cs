using System.Runtime.InteropServices;
using Gaiden.SFML.System;

namespace Gaiden.SFML.Audio;

////////////////////////////////////////////////////////////
/// <summary>
/// Base class intended for capturing sound data
/// </summary>
////////////////////////////////////////////////////////////
public abstract class SoundRecorder : ObjectBase
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Default constructor
    /// </summary>
    ////////////////////////////////////////////////////////////
    protected SoundRecorder() :
        base(IntPtr.Zero)
    {
        _startCallback = new StartCallback(StartRecording);
        _processCallback = new ProcessCallback(ProcessSamples);
        _stopCallback = new StopCallback(StopRecording);

        CPointer = CSFMLAudio.sfSoundRecorder_create(_startCallback, _processCallback, _stopCallback, IntPtr.Zero);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Start the capture using the default sample rate (44100 Hz).
    ///
    /// Please note that only one capture can happen at the same time.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public bool Start() => Start(44100);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Start the capture.
    ///
    /// The sampleRate parameter defines the number of audio samples
    /// captured per second. The higher, the better the quality
    /// (for example, 44100 samples/sec is CD quality).
    /// This function uses its own thread so that it doesn't block
    /// the rest of the program while the capture runs.
    ///
    /// Please note that only one capture can happen at the same time.
    /// </summary>
    /// <param name="sampleRate"> Sound frequency; the more samples, the higher the quality (44100 by default = CD quality)</param>
    ////////////////////////////////////////////////////////////
    public bool Start(uint sampleRate) => CSFMLAudio.sfSoundRecorder_start(CPointer, sampleRate);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Stop the capture
    /// </summary>
    ////////////////////////////////////////////////////////////
    public void Stop() => CSFMLAudio.sfSoundRecorder_stop(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Sample rate of the sound recorder.
    /// </summary>
    ///
    /// <remarks>
    /// The sample rate defines the number of audio samples
    /// captured per second. The higher, the better the quality
    /// (for example, 44100 samples/sec is CD quality).
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public uint SampleRate => CSFMLAudio.sfSoundRecorder_getSampleRate(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get/Set the channel count of the audio capture device
    /// </summary>
    ///
    /// <remarks>
    /// This method allows you to specify the number of channels
    /// used for recording. Currently only 16-bit mono (1) and
    /// 16-bit stereo (2) are supported.
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public uint ChannelCount
    {
        get => CSFMLAudio.sfSoundRecorder_getChannelCount(CPointer);
        set => CSFMLAudio.sfSoundRecorder_setChannelCount(CPointer, value);
    }

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
                var channels = CSFMLAudio.sfSoundRecorder_getChannelMap(CPointer, out var count);
                Array.Resize(ref _channels, (int)count);

                for (var i = 0; i < _channels.Length; i++)
                {
                    _channels[i] = channels[i];
                }

                return _channels;
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Check if the system supports audio capture.
    /// </summary>
    ///
    /// <remarks>
    /// This function should always be called before using
    /// the audio capture features. If it returns false, then
    /// any attempt to use the SoundRecorder or one of its derived
    /// classes will fail.
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public static bool IsAvailable => CSFMLAudio.sfSoundRecorder_isAvailable();

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

        return "[SoundRecorder]" + " SampleRate(" + SampleRate + ")";
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Start capturing audio data.
    ///
    /// This virtual function may be overridden by a derived class
    /// if something has to be done every time a new capture
    /// starts. If not, this function can be ignored; the default
    /// implementation does nothing.
    /// </summary>
    /// <returns>False to abort recording audio data, true to continue</returns>
    ////////////////////////////////////////////////////////////
    protected virtual bool OnStart() =>
        // Does nothing by default
        true;

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Process a new chunk of recorded samples.
    ///
    /// This virtual function is called every time a new chunk of
    /// recorded data is available. The derived class can then do
    /// whatever it wants with it (storing it, playing it, sending
    /// it over the network, etc.).
    /// </summary>
    /// <param name="samples">Array of samples to process</param>
    /// <returns>False to stop recording audio data, true to continue</returns>
    ////////////////////////////////////////////////////////////
    protected abstract bool OnProcessSamples(ReadOnlySpan<short> samples);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Stop capturing audio data.
    ///
    /// This virtual function may be overridden by a derived class
    /// if something has to be done every time the capture
    /// ends. If not, this function can be ignored; the default
    /// implementation does nothing.
    /// </summary>
    ////////////////////////////////////////////////////////////
    protected virtual void OnStop()
    {
        // Does nothing by default
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the list of the names of all available audio capture devices
    /// </summary>
    ////////////////////////////////////////////////////////////
    public static ReadOnlySpan<string> AvailableDevices
    {
        get
        {
            unsafe
            {
                var devicesPtr = CSFMLAudio.sfSoundRecorder_getAvailableDevices(out var count);
                Array.Resize(ref _availableDevices, (int)count);

                for (var i = 0; i < _availableDevices.Length; i++)
                {
                    _availableDevices[i] = Marshal.PtrToStringAnsi(devicesPtr[i])!;
                }

                return _availableDevices;
            }
        }
    }
    private static string[]? _availableDevices;

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the name of the default audio capture device
    /// </summary>
    ////////////////////////////////////////////////////////////
    public static string DefaultDevice => Marshal.PtrToStringAnsi(CSFMLAudio.sfSoundRecorder_getDefaultDevice())!;

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Set the audio capture device
    /// </summary>
    /// <param name="name">The name of the audio capture device</param>
    /// <returns>True, if it was able to set the requested device</returns>
    ////////////////////////////////////////////////////////////
    public bool SetDevice(string name) => CSFMLAudio.sfSoundRecorder_setDevice(CPointer, name);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Get the name of the current audio capture device
    /// </summary>
    /// <returns>The name of the current audio capture device</returns>
    ////////////////////////////////////////////////////////////
    public string GetDevice() => Marshal.PtrToStringAnsi(CSFMLAudio.sfSoundRecorder_getDevice(CPointer))!;

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing) => CSFMLAudio.sfSoundRecorder_destroy(CPointer);

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Function called directly by the C library ; convert
    /// arguments and forward them to the internal virtual function
    /// </summary>
    /// <param name="userData">User data -- unused</param>
    /// <returns>False to stop recording audio data, true to continue</returns>
    ////////////////////////////////////////////////////////////
    private bool StartRecording(IntPtr userData) => OnStart();

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Function called directly by the C library ; convert
    /// arguments and forward them to the internal virtual function
    /// </summary>
    /// <param name="samples">Pointer to the array of samples</param>
    /// <param name="nbSamples">Number of samples in the array</param>
    /// <param name="userData">User data -- unused</param>
    /// <returns>False to stop recording audio data, true to continue</returns>
    ////////////////////////////////////////////////////////////
    private bool ProcessSamples(IntPtr samples, UIntPtr nbSamples, IntPtr userData)
    {
        var samplesArray = new short[(int)nbSamples];
        Marshal.Copy(samples, samplesArray, 0, samplesArray.Length);

        return OnProcessSamples(samplesArray);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Function called directly by the C library ; convert
    /// arguments and forward them to the internal virtual function
    /// </summary>
    /// <param name="userData">User data -- unused</param>
    ////////////////////////////////////////////////////////////
    private void StopRecording(IntPtr userData) => OnStop();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool StartCallback(IntPtr userData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool ProcessCallback(IntPtr samples, UIntPtr nbSamples, IntPtr userData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void StopCallback(IntPtr userData);

    private readonly StartCallback _startCallback;
    private readonly ProcessCallback _processCallback;
    private readonly StopCallback _stopCallback;
    private SoundChannel[]? _channels;
}
