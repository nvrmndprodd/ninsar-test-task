using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Features.ColoristFeature
{
    [CreateAssetMenu(menuName = "_Project/Colorist/Config", fileName = nameof(ColoristConfig), order = 0)]
    public class ColoristConfig : ScriptableObject
    {
        [Serializable]
        public class DigitAndColorPair
        {
            public int digit;
            public Color color;
        }
        
        public string textConfigName = string.Empty;
        public MeshRenderer cubePrefab;
        public Vector3[] cubePositions;
        public DigitAndColorPair[] cubeColors;

        public Dictionary<int, Color> cachedColors;

        private void Awake()
        {
            cachedColors = new Dictionary<int, Color>();

            foreach (var digitAndColorPair in cubeColors)
            {
                cachedColors.Add(digitAndColorPair.digit, digitAndColorPair.color);
            }
        }
    }
}