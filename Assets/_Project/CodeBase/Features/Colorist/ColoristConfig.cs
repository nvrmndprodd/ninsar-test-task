using System;
using UnityEngine;

namespace CodeBase.Features.Colorist
{
    [CreateAssetMenu(menuName = "_Project/Colorist/Config", fileName = "ColoristConfig", order = 0)]
    public class ColoristConfig : ScriptableObject
    {
        [Serializable]
        public class DigitAndColorPair
        {
            public int digit;
            public Color color;
        }
        
        public string textConfigName = string.Empty;
        public Vector3[] cubePositions;
        public DigitAndColorPair[] cubeColors;
    }
}