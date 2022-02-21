using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Farm
{
    public class CropsPart : MonoBehaviour
    {
        public bool IsCanLifted => _isCanLifted;
        private bool _isCanLifted;
        private bool _isUnderImmune;
        private float _immuneTime;

        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private MeshRenderer _meshRenderer;

        public void Init(Material material)
        {
            _meshRenderer.material = material;
            _rigidbody.AddForce(new Vector3(-50, 300, 0));

            _isCanLifted = false;
            _isUnderImmune = true;
            _immuneTime = 1f;
            Invoke(nameof(RemoveImmune), _immuneTime);
        }

        private void RemoveImmune()
        {
            _isUnderImmune = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!_isUnderImmune && other.TryGetComponent(out Ground ground))
            {
                Destroy(_rigidbody);
                transform.position = transform.position + new Vector3(0, transform.localScale.y / 2 - 0.1f, 0);
                _isCanLifted = true;
            }
        }
    }
}
