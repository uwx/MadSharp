using System;
using System.Collections.Generic;
using NAudio.Wave;

namespace Cum
{
    internal class SoundClip
    {
        public static ContO Source;
        public static ContO Player;
        private readonly WaveOutEvent _outputDevice;
        private readonly LoopStream _loop;
        private bool _playing;
        private string _soundName;

        private static List<SoundClip> SoundPool { get; set; } = new List<SoundClip>();

        public SoundClip(string s)
        {
            var audioFile = new AudioFileReader(s);
            _loop = new LoopStream(audioFile);
            _outputDevice = new WaveOutEvent();
            _outputDevice.Init(_loop);
            SoundPool.Add(this);
            _outputDevice.PlaybackStopped += OutputDeviceOnPlaybackStopped;
            _soundName = s;
        }

        private void OutputDeviceOnPlaybackStopped(object sender, StoppedEventArgs stoppedEventArgs)
        {
            _playing = false;
        }

        public void Play()
        {
            if (_soundName.Contains("checkpoint")) Console.WriteLine("Playing " + _soundName);
            if (_playing) _outputDevice.Stop();
            _loop.EnableLooping = false;
            _outputDevice.Play();
            _playing = true;
        }

        public void Checkopen()
        {
        }

        public void Loop()
        {
            if (_soundName.Contains("checkpoint")) Console.WriteLine("Looping " + _soundName);
            if (_playing) _outputDevice.Stop();
            _loop.EnableLooping = true;
            _outputDevice.Play();
            _playing = true;
        }

        public void Stop()
        {
            if (_soundName.Contains("checkpoint")) Console.WriteLine("Stopping " + _soundName);
            _outputDevice.Stop();
            _playing = false;
        }

        public static void StopAll()
        {
            foreach (var s in SoundPool)
            {
                s.Stop();
            }
        }
    }
}