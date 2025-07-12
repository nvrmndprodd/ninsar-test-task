using System.Linq;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Features.ColoristFeature.Editor
{
    [CustomEditor(typeof(ColoristConfig))]
    public class ColoristConfigEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Space(10);

            ColoristConfig config = (ColoristConfig)target;

            if (GUILayout.Button("Find and Save Cube Positions"))
            {
                UpdateCubePositions(config);
            }
        }

        private void UpdateCubePositions(ColoristConfig config)
        {
            var foundObjects = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None)
                .Where(go => go.name == "CubePosition");

            config.cubePositions = foundObjects
                .OrderBy(go => go.transform.position.x)
                .ThenBy(go => go.transform.position.z)
                .Select(go => go.transform.position)
                .ToArray();

            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }
    }
}