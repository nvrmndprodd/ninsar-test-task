using System;
using System.Threading.Tasks;
using CodeBase.Infrastructure.Services;
using Newtonsoft.Json;

namespace CodeBase.Features.ColoristFeature
{
    public class ColorsPicker
    {
        private class Data
        {
            public int[][] colorsArray;
        }
        
        private readonly StaticDataService _staticDataService;
        
        private Data _data;

        public ColorsPicker(StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public async Task LoadConfig(string configName)
        {
            string raw = await _staticDataService.ReadStreamingAssetAsync(configName);
            _data = JsonConvert.DeserializeObject<Data>(raw);
        }

        public void Unload()
        {
            if (_data != null)
            {
                _data.colorsArray = Array.Empty<int[]>();
            }
        }
    }
}