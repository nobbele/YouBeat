using ManagedBass;
using System;

namespace YouBeat.Audio
{
    public class AudioTrack : ILoadable
    {
        public bool IsLoaded = false;
        int handle;
        readonly string filePath;

        public AudioTrack(string filepath)
        {
            filePath = filepath;
        }

        bool ILoadable.IsLoaded => IsLoaded;

        public void Load()
        {
            if ((handle = Bass.CreateStream(filePath, 0, 0, BassFlags.Prescan)) == 0)
            {
                Errors error = Bass.LastError;
                throw new Exception($"BASS failed to create a stream (error code: {(int)error}, name: \"{error}\")");
            }
            IsLoaded = true;
        }

        public void Play()
        {
            if (!IsLoaded)
                throw new Exception($"Must load track before playing");
            if (!Bass.ChannelPlay(handle))
            {
                Errors error = Bass.LastError;
                throw new Exception($"BASS failed to play song (error code: {(int)error}, name: \"{error}\")");
            }
        }

        public void Pause()
        {
            if (!IsLoaded)
                throw new Exception($"Must load track before pausing");
            if (!Bass.ChannelPause(handle))
            {
                Errors error = Bass.LastError;
                throw new Exception($"BASS failed to stop song (error code: {(int)error}, name: \"{error}\")");
            }
        }

        public void Stop()
        {
            if (!IsLoaded)
                throw new Exception($"Must load track before stopping");
            if (!Bass.ChannelStop(handle))
            {
                Errors error = Bass.LastError;
                throw new Exception($"BASS failed to stop song (error code: {(int)error}, name: \"{error}\")");
            }
        }

        public void Unload()
        {
            if (!IsLoaded)
                throw new Exception($"Must load track before unloading");
            if (!Bass.SampleFree(handle))
            {
                Errors error = Bass.LastError;
                throw new Exception($"BASS failed to free a sample (error code: {(int)error}, name: \"{error}\")");
            }
            IsLoaded = false;
        }

        /// <summary>
        /// Don't call too frequently, try to store it
        /// </summary>
        /// <returns></returns>
        public float GetPosition()
        {
            return (float)Bass.ChannelBytes2Seconds(handle, Bass.ChannelGetPosition(handle)) * 1000;
        }

        public float GetVolume()
        {
            return (float)Bass.ChannelGetAttribute(handle, ChannelAttribute.Volume) * 10000;
        }

        public void SetVolume(float vol)
        {
            Bass.ChannelSetAttribute(handle, ChannelAttribute.Volume, vol / 10000);
        }

        public static float GlobalVolume {
            get => Bass.GlobalStreamVolume / 10000f;
            set => Bass.GlobalStreamVolume = (int)(value * 10000);
        }

        public static void EngineInit()
        {
            if (!Bass.Init())
            {
                Errors error = Bass.LastError;
                throw new Exception($"BASS failed to initialize (error code: {(int)error}, name: \"{error}\")");
            }
        }
    }
}
