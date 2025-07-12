using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Features.ColoristFeature
{
    public class Colorist
    {
        private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
        
        private readonly ColoristModel _model;

        private MeshRenderer[] _cubes;
        private int[] _colorsId;
        
        private readonly MaterialPropertyBlock _cachedPropertyBlock = new MaterialPropertyBlock();

        public Colorist(ColoristModel model)
        {
            _model = model;
            
            _colorsId = new int[ColorsPicker.ROWS * ColorsPicker.COLUMNS];
        }

        public void SpawnCubes()
        {
            Vector3[] positions = _model.Config.cubePositions;
            _cubes = new MeshRenderer[positions.Length];

            for (var i = 0; i < positions.Length; i++)
            {
                Vector3 position = positions[i];
                MeshRenderer cube = Object.Instantiate(_model.Config.cubePrefab, position, Quaternion.identity);
                
                _cubes[i] = cube;
            }
        }

        public void DestroyCubes()
        {
            if (_cubes == null)
            {
                return;
            }

            foreach (var cube in _cubes)
            {
                Object.Destroy(cube);
            }
        }

        public void ColorCubes()
        {
            _model.colorsPicker.GetCurrentGrid(_colorsId);

            for (var i = 0; i < _colorsId.Length; i++)
            {
                int colorId = _colorsId[i];
                MeshRenderer cube = _cubes[i];
                
                Color color = _model.Config.cachedColors[colorId];
                
                ApplyColor(cube, ref color);
            }
        }

        public void MoveColors(Vector2 input)
        {
            if (input == Vector2.up)
            {
                _model.colorsPicker.MoveUp();
            }
            else if (input == Vector2.down)
            {
                _model.colorsPicker.MoveDown();
            }
            else if (input == Vector2.left)
            {
                _model.colorsPicker.MoveLeft();
            }
            else if (input == Vector2.right)
            {
                _model.colorsPicker.MoveRight();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(input), input, $"Invalid input: {input}");
            }
        }

        private void ApplyColor(MeshRenderer cube, ref Color color)
        {
            cube.GetPropertyBlock(_cachedPropertyBlock);
                
            _cachedPropertyBlock.SetColor(BaseColor, color);
            
            cube.SetPropertyBlock(_cachedPropertyBlock);
        }
    }
}