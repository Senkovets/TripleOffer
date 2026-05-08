using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace TripleOffer.CodeBase
{
    public class FileSaveLoadService : ISaveLoadService
    {
        private readonly JsonSerializerSettings _settings;

        public FileSaveLoadService()
        {
            _settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
        }

        public void Save<T>(string key, T data)
        {
            string path = GetPath(key);

            string json =
                JsonConvert.SerializeObject(
                    data,
                    _settings
                );

            File.WriteAllText(path, json);
        }

        public T Load<T>(string key)
        {
            string path = GetPath(key);
            
            if (!File.Exists(path))
            {
                Debug.LogWarning($"[SaveLoad] File not found at {path}. Returning default.");
                return default; // Или создавай новый пустой объект
            }

            string json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(
                json,
                _settings
            );
        }

        public bool Exists(string key)
        {
            return File.Exists(GetPath(key));
        }

        private string GetPath(string key)
        {
            return Path.Combine(
                Application.persistentDataPath,
                $"{key}.json"
            );
        }
    }
}