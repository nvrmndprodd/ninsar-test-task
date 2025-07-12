using System.Threading.Tasks;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Features.ColoristFeature
{
    public class ColoristModel
    {
        private readonly StaticDataService _staticDataService;
        private readonly ColorsPicker _colorsPicker;

        private ColoristConfig _config;

        public ColoristModel(StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _colorsPicker = new ColorsPicker(staticDataService);
        }

        public async Task LoadConfigs()
        {
            _config = await _staticDataService.LoadDataAsync<ColoristConfig>(nameof(ColoristConfig));
            await _colorsPicker.LoadConfig(_config.textConfigName);
        }

        public void UnloadConfigs()
        {
            _config = null;
            _colorsPicker.Unload();
        }
    }
}