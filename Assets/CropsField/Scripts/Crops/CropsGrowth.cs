using System;
using UnityEngine;

namespace Farm
{
    [Serializable]
    public class CropsGrowth : MonoBehaviour
    {
        public event Action OnGrowComplete;
        [SerializeField]
        private float _maxTime;
        private float _currentTime;
        private CropFilling _filling;

        public bool IsMatured => _currentTime == _maxTime;

        public void InitStartSettings(float maxTime)
        {
            Restart();
            _maxTime = maxTime;
        }

        public void InitFilling(CropFilling filing)
        {
            _filling = filing;
        }

        public void Tick(float time)
        {
            if (_filling != null)
                return;

            _currentTime += time;
            _currentTime = Mathf.Clamp(_currentTime, 0, _maxTime);

            if(_currentTime == _maxTime && _filling == null)
            {
                _currentTime = 0;
                OnGrowComplete?.Invoke();
            }
        }

        public void Restart()
        {
            _currentTime = 0;
        }
    }
}
