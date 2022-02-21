using System;
using UnityEngine;

namespace Farm
{
    public abstract class TakerCrops : MonoBehaviour
    {
        public abstract event Action<CropsPart> OnTakeCrops;
        public abstract void TakeCrops(CropsPart cropsPart);
    }
}
