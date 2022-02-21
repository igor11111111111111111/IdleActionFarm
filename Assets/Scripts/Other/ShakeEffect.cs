using DG.Tweening;
using UnityEngine;

namespace Farm
{
    public class ShakeEffect
    {
        public void Activate(Transform transform)
        {
            transform.DOShakePosition(1, 10);
        }
    }
}
 