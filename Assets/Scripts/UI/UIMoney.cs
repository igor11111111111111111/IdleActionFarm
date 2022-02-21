using TMPro;
using UnityEngine;

namespace Farm
{
    public class UIMoney : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI _textMeshPro;

        public void Refresh(float value)
        {
            _textMeshPro.text = value.ToString();
        }
    }
}
