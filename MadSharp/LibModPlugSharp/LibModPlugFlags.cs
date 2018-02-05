using System;

namespace LibModPlugSharp
{
	/// <summary>
	/// Bitflags for some settings in ModPlug.
	/// </summary>
	[Flags]
	public enum LibModPlugFlags
	{
		/// <summary>Enable oversampling (highly recommended)</summary>
		ModplugEnableOversampling   = 1 << 0,

		/// <summary>Enable noise reduction</summary>
		ModplugEnableNoiseReduction = 1 << 1,

		/// <summary>Enable reverb</summary>
		ModplugEnableReverb         = 1 << 2,

		/// <summary>Enable megabass</summary>
		ModplugEnableMegaBass       = 1 << 3,

		/// <summary>Enable surround sound</summary>
		ModplugEnableSurround       = 1 << 4,
	}
}
