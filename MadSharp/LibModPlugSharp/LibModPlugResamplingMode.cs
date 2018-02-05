namespace LibModPlugSharp
{
	/// <summary>
	/// Signifies possible resampling modes in ModPlug.
	/// </summary>
	public enum LibModPlugResamplingMode
	{
		/// <summary>No interpolation (very fast, bad quality)</summary>
		ResampleNearest = 0,

		/// <summary>Linear interpolation (fast, good quality)</summary>
		ResampleLinear  = 1,

		/// <summary>Cubic spline interpolation (high quality)</summary>
		ResampleSpline  = 2,

		/// <summary>8-tap FIR filter (extremely high quality)</summary>
		ResampleFir     = 3,
	}
}
