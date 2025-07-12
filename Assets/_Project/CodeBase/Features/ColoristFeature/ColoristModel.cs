using System.Threading.Tasks;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Features.ColoristFeature
{
    public class ColoristModel
    {
        private readonly StaticDataService _staticDataService;
        
        public readonly ColorsPicker colorsPicker;
        
        public ColoristConfig Config { get; private set; }

        public ColoristModel(StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            colorsPicker = new ColorsPicker(staticDataService);
        }

        public async Task LoadConfigs()
        {
            Config = await _staticDataService.LoadDataAsync<ColoristConfig>(nameof(ColoristConfig));
            await colorsPicker.LoadConfig(Config.textConfigName);
        }

        public void UnloadConfigs()
        {
            Config = null;
            colorsPicker.Unload();
        }
    }
}