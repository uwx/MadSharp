using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using ManagedBass;

namespace Cum
{
    internal class RadicalMusic
    {
        private bool _readable;
        private readonly int _music;

        public RadicalMusic(File file)
        {
            using (var fileStream = System.IO.File.OpenRead(file.Path))
            using (var zipStream = new ZipArchive(fileStream, ZipArchiveMode.Read))
            using (var resultStream = new MemoryStream())
            {
                zipStream.Entries.First().Open().CopyTo(resultStream);
                var arr = resultStream.ToArray();
                if ((_music = Bass.MusicLoad(arr, 0, arr.Length, BassFlags.Loop)) == 0)
                {
                    // it ain't playable
                    throw new Exception(SoundClip.GetBassError(Bass.LastError));
                }
                _readable = true;
                SetVolume(GameSparker.Volume);
            }
        }

        public RadicalMusic()
        {
            // empty
        }

        public void SetPaused(bool p0)
        {
            if (!_readable) return;
            if (p0) Bass.ChannelPause(_music);
            else Bass.ChannelPlay(_music);
        }

        public void Unload()
        {
            if (!_readable) return;
            Bass.MusicFree(_music);
            _readable = false;
        }

        public void Play()
        {
            if (!_readable) return;
            Bass.ChannelPlay(_music);
        }

        public void SetVolume(float vol)
        {
            if (!_readable) return;
            Bass.ChannelSetAttribute(_music, ChannelAttribute.Volume, vol);
        }
    }
}