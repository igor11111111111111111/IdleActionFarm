using System;
using UnityEngine;

namespace Farm
{
    public class PlayerController : TakerCrops
    {
        public event Action<bool> OnMove;
        public event Action<bool> OnHarvest;
        public override event Action<CropsPart> OnTakeCrops;

        public Vector2 Direction => _direction;
        private Vector2 _direction;
        private IUseInput _input;

        public void Init(IUseInput input)
        {
            _input = input;
            _input.OnMove += MoveHandler;
            _input.OnClick += ClickHandler;
        }

        public override void TakeCrops(CropsPart cropsPart)
        {
            OnTakeCrops?.Invoke(cropsPart);
        }

        private void OnDisable()
        {
            _input.OnMove -= MoveHandler;
            _input.OnClick -= ClickHandler;
        }

        private void MoveHandler(Vector2 direction)
        {
            _direction = direction;
            bool move = direction.x == 0 && direction.y == 0 ? false : true;
            OnMove?.Invoke(move);
        }

        private void ClickHandler(bool active)
        {
            OnHarvest?.Invoke(active);
        }
    }
}
