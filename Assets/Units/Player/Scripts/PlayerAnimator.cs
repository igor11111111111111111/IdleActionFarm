using UnityEngine;

namespace Farm
{
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(Animator))]

    public class PlayerAnimator : MonoBehaviour
    {
        private PlayerController _controller;
        private Animator _animator;

        private void Awake()
        {
            _controller = GetComponent<PlayerController>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _controller.OnMove += Move;
            _controller.OnHarvest += Harvest;
        }

        private void OnDisable()
        {
            _controller.OnMove -= Move;
            _controller.OnHarvest -= Harvest;
        }

        private void Move(bool active)
        {
            _animator.SetBool("IsRuning", active);
        }

        private void Harvest(bool active)
        {
            _animator.SetBool("IsHarvesting", active);
        }
    }
}
