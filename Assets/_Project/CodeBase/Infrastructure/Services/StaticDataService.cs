using System.IO;
using System.Threading.Tasks;
using CodeBase.Extensions;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class StaticDataService
    {
        public StaticDataService()
        {
            Debug.Log($"{nameof(StaticDataService)} created");
        }

        public async Task<TData> LoadDataAsync<TData>(string path) where TData : ScriptableObject
        {
            return await Resources.LoadAsync<TData>(path).AsTask<TData>();
        }

        public async Task<string> ReadStreamingAssetAsync(string relativePath)
        {
            string path = Path.Combine(Application.streamingAssetsPath, relativePath);

            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException($"File not found: {path}");
            }
            
            return await File.ReadAllTextAsync(path);
        }
    }
}