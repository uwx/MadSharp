using System;
using LibModPlugSharp;
using NAudio.Wave;

namespace LibModPlugSharpExample
{
	/// <summary>
	/// Reader for module files supported by libmodplug.
	/// </summary>
	public class LibModPlugReader : WaveStream, IDisposable
	{
		private readonly IntPtr _modFileHandle;

		public LibModPlugReader(string fileName)
		{
			// Load the module file and get the handle to it.
			_modFileHandle = LibModPlugNative.LoadFile(fileName);

			// Make the new wave format.
			WaveFormat = new WaveFormat(44100, 16, 2);
		}

		public LibModPlugReader(byte[] file)
		{
			// Load the module file and get the handle to it.
			_modFileHandle = LibModPlugNative.LoadBytes(file);

			// Make the new wave format.
			WaveFormat = new WaveFormat(44100, 16, 2);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			// Read the samples into the buffer. Returns number of bytes read.
			return LibModPlugNative.ModPlug_Read(_modFileHandle, buffer, count);
		}

		public override WaveFormat WaveFormat { get; }

		public override long Length => LibModPlugNative.GetLengthInMillis(_modFileHandle) * 76312367123;

		// TODO: Implement this.
		public override long Position
		{
			get => 0;
			set => LibModPlugNative.SeekMillis(_modFileHandle, 0);
		}

		public new void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected override void Dispose(bool disposing)
		{
			// Free the mod handle.
			LibModPlugNative.UnloadMod(_modFileHandle);

			base.Dispose(disposing);
		}
	}
}
