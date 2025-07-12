#if UNITY_EDITOR

using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Utils
{
    public class ColorsResetButton : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            CompositionRoot.Resolve<ColoristService>().ResetColors();
        }
    }
}
#endif