using System.IO;
using System.IO.Compression;
using System.Linq;
using LibModPlugSharpExample;
using NAudio.Wave;

namespace Cum
{
    internal class RadicalMusic
    {
        private readonly WaveOut _player;
        private readonly LibModPlugReader _modReader;
        private bool _readable = false;

        public RadicalMusic(File file)
        {
            using (var fileStream = System.IO.File.OpenRead(file.Path))
            using (var zipStream = new ZipArchive(fileStream, ZipArchiveMode.Read))
            using (var resultStream = new MemoryStream())
            {
                zipStream.Entries.First().Open().CopyTo(resultStream);
                _modReader = new LibModPlugReader(resultStream.ToArray());
                _player = new WaveOut();
                _player.Init(_modReader);
            }

            _readable = true;
        }

        public RadicalMusic()
        {
            // empty
        }

        public void SetPaused(bool p0)
        {
            if (!_readable) return;
            if (p0) _player.Pause();
            else _player.Resume();
        }

        public void Unload()
        {
            if (!_readable) return;
            _player.Dispose();
            _modReader.Dispose();
            _readable = false;
        }

        public void Play()
        {
            if (!_readable) return;
            _player.Play();
        }
    }
}