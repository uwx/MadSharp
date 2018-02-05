using System;
using System.IO;
using System.Runtime.InteropServices;

namespace LibModPlugSharp
{
	/// <summary>
	/// The class that contains all the native P/Invoking to libmodplug.
	/// </summary>
	public static class LibModPlugNative
	{
		#region Encapsulation Methods and properties.

		/// <summary>
		/// Encapsulates ModPlug_Load(). Loads a module file.
		/// </summary>
		/// <param name="fileName">The path to the module file.</param>
		/// <returns>An IntPtr handle to the loaded module file.</returns>
		public static IntPtr LoadFile(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
				throw new ArgumentException("fileName cannot be empty or null.", nameof(fileName));

			byte[] modFile = File.ReadAllBytes(fileName);
			return ModPlug_Load(modFile, modFile.Length);
		}

		/// <summary>
		/// Encapsulates ModPlug_Load(). Loads a module file.
		/// </summary>
		/// <param name="modFile">The module file contents.</param>
		/// <returns>An IntPtr handle to the loaded module file.</returns>
		public static IntPtr LoadBytes(byte[] modFile)
		{
			return ModPlug_Load(modFile, modFile.Length);
		}

		/// <summary>
		/// Encapsulates ModPlug_Unload(). Unloads a handle to a loaded mod file.
		/// </summary>
		/// <param name="modToUnload">The handle to a mod file to unload.</param>
		public static void UnloadMod(IntPtr modToUnload)
		{
			ModPlug_Unload(modToUnload);
		}

		/// <summary>
		/// Encapsulates ModPlug_GetName(). Gets the name of the module file.
		/// </summary>
		/// <param name="modFileHandle">A handle to the currently loaded module file.</param>
		/// <returns>The name of the module file.</returns>
		public static string GetModuleName(IntPtr modFileHandle)
		{
			return Marshal.PtrToStringAnsi(ModPlug_GetName(modFileHandle));
		}

		/// <summary>
		/// Encapsulates ModPlug_GetLength(). Gets the length of the module in milliseconds.
		/// </summary>
		/// <remarks>
		/// Note that this may not always be accurate, especially in the case of mods with loops.
		/// </remarks>
		/// <param name="modFileHandle">A handle to the currently loaded module file.</param>
		/// <returns>The playback length in milliseconds.</returns>
		public static int GetLengthInMillis(IntPtr modFileHandle)
		{
			return ModPlug_GetLength(modFileHandle);
		}

		/// <summary>
		/// Encapsulates ModPlug_Seek. Seeks to a particular position in the song.
		/// <para></para>
		/// Note that seeking and MODs don't mix very well. <br/>
		/// Some mods will be missing instruments for a short time after a seek, as
		/// ModPlug does not scan the sequence backwards to find out which instruments
		/// were supposed to be playing at that time. (Doing so would be difficult and not
		/// very reliable).
		/// <para></para>
		/// Also , note that seeking is not very exact in some mods -- especially for those
		/// which ModPlug_GetLength() does not report the full length.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <param name="milliseconds">The amount of milliseconds to seek from the current position.</param>
		public static void SeekMillis(IntPtr modFileHandle, int milliseconds)
		{
			ModPlug_Seek(modFileHandle, milliseconds);
		}

		/// <summary>
		/// Encapsulates ModPlug_GetSettings(). Gets the ModPlug mod decoding settings.
		/// </summary>
		/// <returns>The ModPlug mod decoding settings.</returns>
		public static LibModPlugSettings GetModPlugSettings()
		{
			LibModPlugSettings settings;
			ModPlug_GetSettings(out settings);
			return settings;
		}

		/// <summary>
		/// Encapsulates ModPlug_SetSettings(). Sets the mod decoder settings.
		/// </summary>
		/// <remarks>
		/// All options, except for channels, bits-per-sample, sampling rate, and loop count,
		/// will take effect immediately.
		/// <para></para>
		/// Those options which don't take effect immediately
		/// </remarks>
		/// <param name="newSettings">Reference to a <see cref="LibModPlugSettings"/> struct.</param>
		public static void SetModPlugSettings(LibModPlugSettings newSettings)
		{
			ModPlug_SetSettings(ref newSettings);
		}

		/// <summary>
		/// Gets the master volume (ranges from 1 - 512).
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The master volume.</returns>
		public static int GetMasterVolume(IntPtr modFileHandle)
		{
			return ModPlug_GetMasterVolume(modFileHandle);
		}

		/// <summary>
		/// Sets the master volume to a new specified value (within 1 - 512).
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <param name="newVolume">The new volume to set the master volume to.</param>
		public static void SetMasterVolume(IntPtr modFileHandle, int newVolume)
		{
			ModPlug_SetMasterVolume(modFileHandle, newVolume);
		}

		/// <summary>
		/// Gets the current track speed.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The current track speed.</returns>
		public static int GetCurrentSpeed(IntPtr modFileHandle)
		{
			return ModPlug_GetCurrentSpeed(modFileHandle);
		}

		/// <summary>
		/// Gets the current track tempo.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The current track tempo.</returns>
		public static int GetCurrentTempo(IntPtr modFileHandle)
		{
			return ModPlug_GetCurrentTempo(modFileHandle);
		}

		/// <summary>
		/// Gets the current track order.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The current track order.</returns>
		public static int GetCurrentOrder(IntPtr modFileHandle)
		{
			return ModPlug_GetCurrentOrder(modFileHandle);
		}

		/// <summary>
		/// Gets the currently playing track pattern.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The currently playing track pattern.</returns>
		public static int GetCurrentPattern(IntPtr modFileHandle)
		{
			return ModPlug_GetCurrentPattern(modFileHandle);
		}

		/// <summary>
		/// Gets the currently playing track row.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The currently playing track row.</returns>
		public static int GetCurrentRow(IntPtr modFileHandle)
		{
			return ModPlug_GetCurrentRow(modFileHandle);
		}

		/// <summary>
		/// Gets the number of currently active channels.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The number of currently active channels.</returns>
		public static int GetPlayingChannels(IntPtr modFileHandle)
		{
			return ModPlug_GetPlayingChannels(modFileHandle);
		}

		/// <summary>
		/// The number of instruments in this module file.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <returns>The number of instruments in this module file.</returns>
		public static int NumInstruments(IntPtr modFileHandle)
		{
			return ModPlug_NumInstruments(modFileHandle);
		}

		/// <summary>
		/// The number of samples in this module file.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <returns>The number of samples in this module file.</returns>
		public static int NumSamples(IntPtr modFileHandle)
		{
			return ModPlug_NumSamples(modFileHandle);
		}

		/// <summary>
		/// The number of patterns in this module file.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <returns>The number of patterns in this module file.</returns>
		public static int NumPatterns(IntPtr modFileHandle)
		{
			return ModPlug_NumPatterns(modFileHandle);
		}

		/// <summary>
		/// The number of channels used by this module file.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <returns>The number of channels used by this module file.</returns>
		public static int NumChannels(IntPtr modFileHandle)
		{
			return ModPlug_NumChannels(modFileHandle);
		}

		/// <summary>
		/// Gets the name of a specified sample.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <param name="sample">The sample to get the name of.</param>
		/// <returns>The name of a specified sample.</returns>
		public static string GetSampleName(IntPtr modFileHandle, int sample)
		{
			// TODO: Internal checking for sample limit.

			IntPtr sampleName;
			ModPlug_SampleName(modFileHandle, sample, out sampleName);

			return Marshal.PtrToStringAnsi(sampleName);
		}

		/// <summary>
		/// Gets the name of a specified sample.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <param name="instrument">The instrument to get the name of.</param>
		/// <returns>The name of a specified instrument.</returns>
		public static string GetInstrumentName(IntPtr modFileHandle, int instrument)
		{
			// TODO: Internal checking for sample limit.
			IntPtr instrumentName;
			ModPlug_InstrumentName(modFileHandle, instrument, out instrumentName);

			return Marshal.PtrToStringAnsi(instrumentName);
		}

		/// <summary>
		/// Gets the message written by the author of this module.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <returns></returns>
		public static string GetMessage(IntPtr modFileHandle)
		{
			// TODO: Doesn't return full string. Needs to pinvoke a string array instead.
			return Marshal.PtrToStringAnsi(ModPlug_GetMessage(modFileHandle));
		}


		#endregion


		#region P/Invoke Methods

		private const string DllName = "libmodplug-1";

		/// <summary>
		/// Load a mod file.
		/// </summary>
		/// <param name="data">A block of memory containing the module file.</param>
		/// <param name="size">The size of the data containing the module file.</param>
		/// <returns>An IntPtr handle to the module file on success. Null upon failure.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr ModPlug_Load(byte[] data, int size);

		/// <summary>
		/// Unloads a mod file.
		/// </summary>
		/// <param name="modFileHandle">The handle to the mod file to unload.</param>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern void ModPlug_Unload(IntPtr modFileHandle);

		/// <summary>
		/// Reads sample data into the buffer.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <param name="buffer">The buffer to generate samples into.</param>
		/// <param name="size">The size of the buffer.</param>
		/// <returns>The number of bytes read. Returns 0 if the end of the mod file has been reached.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ModPlug_Read(IntPtr modFileHandle, [In, Out] byte[] buffer, int size);

		/// <summary>
		/// Gets the name of the mod file.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>A string as the name of the mod file.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		private static extern IntPtr ModPlug_GetName(IntPtr modFileHandle);

		/// <summary>
		/// Gets the length of the module in milliseconds.
		/// </summary>
		/// <remarks>
		/// Note that this may not always be accurate, especially in the case of mods with loops.
		/// </remarks>
		/// <param name="modFileHandle"></param>
		/// <returns></returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_GetLength(IntPtr modFileHandle);

		/// <summary>
		/// Seeks to a particular position in the song.
		/// <para></para>
		/// Note that seeking and MODs don't mix very well. <br/>
		/// Some mods will be missing instruments for a short time after a seek, as
		/// ModPlug does not scan the sequence backwards to find out which instruments
		/// were supposed to be playing at that time. (Doing so would be difficult and not
		/// very reliable).
		/// <para></para>
		/// Also, note that seeking is not very exact in some mods -- especially for those
		/// which ModPlug_GetLength() does not report the full length.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <param name="milliseconds">The amount of milliseconds to seek from the current position.</param>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern void ModPlug_Seek(IntPtr modFileHandle, int milliseconds);

		/// <summary>
		/// Gets the mod decoder settings.
		/// </summary>
		/// <param name="modplugSettings">The modplug settings that get returned.</param>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern void ModPlug_GetSettings(out LibModPlugSettings modplugSettings);

		/// <summary>
		/// Sets the mod decoder settings.
		/// </summary>
		/// <remarks>
		/// All options, except for channels, bits-per-sample, sampling rate, and loop count,
		/// will take effect immediately.
		/// <para></para>
		/// Those options which don't take effect immediately
		/// </remarks>
		/// <param name="modplugSettings">Reference to a <see cref="LibModPlugSettings"/> struct.</param>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern void ModPlug_SetSettings(ref LibModPlugSettings modplugSettings);

		/// <summary>
		/// Gets the master volume (ranges from 1 - 512).
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The master volume.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_GetMasterVolume(IntPtr modFileHandle);

		/// <summary>
		/// Sets a new master volume value (within ranges 1 - 512).
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <param name="newVolume">The new volume to set the master volume to.</param>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern void ModPlug_SetMasterVolume(IntPtr modFileHandle, int newVolume);

		/// <summary>
		/// Gets the current track speed.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The current track speed.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_GetCurrentSpeed(IntPtr modFileHandle);

		/// <summary>
		/// Gets the current track tempo.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The current track tempo.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_GetCurrentTempo(IntPtr modFileHandle);

		/// <summary>
		/// Gets the currently playing track order.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The current playing track order.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_GetCurrentOrder(IntPtr modFileHandle);

		/// <summary>
		/// Gets the currently playing track pattern.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The current playing track pattern.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_GetCurrentPattern(IntPtr modFileHandle);

		/// <summary>
		/// Gets the currently playing track row.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The currently playing track row.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_GetCurrentRow(IntPtr modFileHandle);

		/// <summary>
		/// Gets the number of currently active channels.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded mod file.</param>
		/// <returns>The number of currently active channels.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_GetPlayingChannels(IntPtr modFileHandle);

		/// <summary>
		/// Gets the number of instruments in this module file.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <returns>The number of instruments in this module.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_NumInstruments(IntPtr modFileHandle);

		/// <summary>
		/// The number of samples in this module file.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <returns>The number of samples in this module file.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_NumSamples(IntPtr modFileHandle);

		/// <summary>
		/// The number of patterns in this module file.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <returns>The number of patterns in this module file.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_NumPatterns(IntPtr modFileHandle);

		/// <summary>
		/// The number of channels this module uses.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <returns>The number of channels this module uses.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_NumChannels(IntPtr modFileHandle);

		/// <summary>
		/// Gets the name of a specified sample.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <param name="sample">The sample to get the name of.</param>
		/// <param name="sampleName">The output which is the name of the sample.</param>
		/// <returns>The name of a specified sample.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_SampleName(IntPtr modFileHandle, int sample, out IntPtr sampleName);

		/// <summary>
		/// Gets the name of a specified sample.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <param name="instrument">The instrument to get the name of.</param>
		/// <param name="instrumentName">The output which is the name of the instrument.</param>
		/// <returns>The name of a specified instrument.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_InstrumentName(IntPtr modFileHandle, int instrument, out IntPtr instrumentName);

		/// <summary>
		/// Gets an int that identifies the module type.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <returns>An int that identifies the module type.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern int ModPlug_GetModuleType(IntPtr modFileHandle);

		/// <summary>
		/// Gets the message written by the author of this module.
		/// </summary>
		/// <param name="modFileHandle">The handle to the currently loaded module file.</param>
		/// <returns>The message written by the author of this module.</returns>
		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr ModPlug_GetMessage(IntPtr modFileHandle);

		#endregion
	}
}
