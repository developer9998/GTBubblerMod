using System;
using System.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine;
using System.IO;

namespace GTBubblerMod.Tools
{
    internal class SoundLoader
    {
        public static AudioType GetAudioType(string path)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));

            string extension = Path.GetExtension(path).ToLowerInvariant();

            return extension switch
            {
                ".wav" => AudioType.WAV,
                ".mp3" => AudioType.MPEG,
                ".ogg" => AudioType.OGGVORBIS,
                ".aif" or ".aiff" => AudioType.AIFF,
                ".xm" => AudioType.XM,
                ".mod" => AudioType.MOD,
                ".it" => AudioType.IT,
                ".s3m" => AudioType.S3M,
                _ => throw new NotSupportedException(extension)
            };
        }

        public static async Task<AudioClip> LoadClip(string path)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));

            using UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(path, GetAudioType(path));

            var taskCompletionSource = new TaskCompletionSource<bool>();
            var webRequest = request.SendWebRequest();
            webRequest.completed += asyncOperation => 
            {
                taskCompletionSource.SetResult(true); 
            };

            await taskCompletionSource.Task;

            if (request.result != UnityWebRequest.Result.Success)
            {
                throw new NullReferenceException(nameof(request));
            }

            return DownloadHandlerAudioClip.GetContent(request);
        }
    }
}
