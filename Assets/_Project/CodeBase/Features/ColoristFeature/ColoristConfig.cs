using System;
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
        public Transform cubePrefab;
        public Vector3[] cubePositions;
        public DigitAndColorPair[] cubeColors;
    }
}