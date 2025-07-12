using System;
using System.Data;
using System.Threading.Tasks;
using CodeBase.Infrastructure.Services;
using Newtonsoft.Json;

namespace CodeBase.Features.ColoristFeature
{
    public class ColorsPicker
    {
        public const int ROWS = 3;
        public const int COLUMNS = 3;
        
        private class Data
        {
            public int[][] colorsArray;
        }
        
        private readonly StaticDataService _staticDataService;
        
        private Data _data;
        
        private int _startX;
        private int _startY;

        public ColorsPicker(StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public async Task LoadConfig(string configName)
        {
            string raw = await _staticDataService.ReadStreamingAssetAsync(configName);
            _data = JsonConvert.DeserializeObject<Data>(raw);

            _startX = 0;
            _startY = 0;
        }

        public void Unload()
        {
            if (_data != null)
            {
                _data.colorsArray = Array.Empty<int[]>();
            }
            
            _startX = 0;
            _startY = 0;
        }

        public void ResetPosition()
        {
            _startX = 0;
            _startY = 0;
        }
        
        public void MoveUp()
        {
            _startY--;
        }

        public void MoveDown()
        {
            _startY++;
        }

        public void MoveLeft()
        {
            _startX--;
        }

        public void MoveRight()
        {
            _startX++;
        }

        public void GetCurrentGrid(int[] grid)
        {
            if (_data?.colorsArray == null)
            {
                grid = Array.Empty<int>();
                return;
            }
            
            int index = 0;
            
            int dataRows = _data.colorsArray.Length;
            int dataColumns = _data.colorsArray[0].Length;

            for (int y = 0; y < ROWS; y++)
            {
                for (int x = 0; x < COLUMNS; x++)
                {
                    int sourceY = _startY + y;
                    int sourceX = _startX + x;
                    
                    int wrappedY = sourceY % dataRows;
                    int wrappedX = sourceX % dataColumns;

                    if (wrappedY < 0) wrappedY += dataRows;
                    if (wrappedX < 0) wrappedX += dataColumns;
                    
                    grid[index++] = _data.colorsArray[wrappedY][wrappedX];
                }
            }
        }
    }
}