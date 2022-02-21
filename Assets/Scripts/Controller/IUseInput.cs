using System;
using UnityEngine;

namespace Farm
{
    public interface IUseInput
    {
        public event Action<Vector2> OnMove;
        public event Action<bool> OnClick;
    }
}
