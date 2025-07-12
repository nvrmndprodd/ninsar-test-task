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
    }
}