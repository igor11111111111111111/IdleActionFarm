using UnityEngine;

namespace Farm
{
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(PlayerData))]
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerPhysics : MonoBehaviour
    {
        private PlayerController _controller;
        private PlayerData _data;
        private Rigidbody _rigidbody;
        private Vector2 _oldDirection;

        private void Awake()
        {
            _controller = GetComponent<PlayerController>();
            _data = GetComponent<PlayerData>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _controller.OnMove += Move;
        }

        private void OnDisable()
        {
            _controller.OnMove -= Move;
        }

        private void Move(bool active)
        {
            if (!active)
            {
                _rigidbody.velocity = Vector3.zero;
            }

            if(Mathf.Sign(_controller.Direction.x) != Mathf.Sign(_oldDirection.x))
            {
                _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y);
            }

            if (Mathf.Sign(_controller.Direction.y) != Mathf.Sign(_oldDirection.y))
            {
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0);
            }

            Vector3 direction = new Vector3(_controller.Direction.x, 0, _controller.Direction.y);

            transform.LookAt(transform.position + direction);

            Vector3 force = direction * _data.Speed;
            _rigidbody.AddForce(force);
            _oldDirection = _controller.Direction;
        }
    }
}
