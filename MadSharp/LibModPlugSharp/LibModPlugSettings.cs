using System.Runtime.InteropServices;

namespace LibModPlugSharp
{
	/// <summary>
	/// Represents the module decoder options.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LibModPlugSettings
	{
		/// <summary>One or more of the <see cref="LibModPlugFlags"/> bitwise OR'ed.</summary>
		public int flags;

		/// <summary>Number of channels. 1 for mono, or 2 for stereo.</summary>
		public int channels;
		/// <summary>Bits per sample. 8, 16, or 32.</summary>
		public int bits;
		/// <summary>Sampling rate. 11025, 22050, or 44100.</summary>
		public int frequency;
		/// <summary>One value from <see cref="LibModPlugResamplingMode"/></summary>
		public int resamplingMode;


		/// <summary>Stereo separation. 1 - 256.</summary>
		public int stereoSeparation;
		/// <summary>Maximum number of mixing channels (polyphony), 32 - 256</summary>
		public int maxMixChannels;


		/// <summary>Reverb level. 0 (quiet) - 100 (loud).</summary>
		public int reverbDepth;
		/// <summary>Reverb delay in milliseconds. Usually 40 - 200ms.</summary>
		public int reverbDelay;
		/// <summary>XBass level, 0 (quiet) - 100 (loud)</summary>
		public int bassAmount;
		/// <summary>XBass cutoff in Hz. 10 - 100.</summary>
		public int bassRange;
		/// <summary>Surround level. 0 (quiet) - 100 (loud).</summary>
		public int surroundDepth;
		/// <summary>Surround delay in milliseconds. Usually 5 - 40 ms.</summary>
		public int surroundDelay;
		/// <summary>Number of times to loop. Zero prevents looping. -1 loops forever.</summary>
		public int loopCount;
	}
}
