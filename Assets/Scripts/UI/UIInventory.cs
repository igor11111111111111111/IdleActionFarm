using UnityEngine;
using UnityEngine.UI;

namespace Farm
{
    public class UIInventory : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;

        public void Refresh(float normalizedValue)
        {
            _slider.value = normalizedValue;
        }
    }
}
