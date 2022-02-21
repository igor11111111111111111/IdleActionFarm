
using UnityEngine;

namespace Farm
{
    [CreateAssetMenu(fileName = "CropsFieldSO", menuName = "SO/CropsFieldSO", order = 1)]

    public class CropsFieldSO : ScriptableObject
    {
        [SerializeField]
        private CropsTile _prefab;
        [SerializeField]
        private float _growthTime;
        [SerializeField]
        private int _row;
        [SerializeField]
        private int _column;
        [SerializeField]
        private Vector3 _position;

        public CropsTile Prefab => _prefab;
        public float GrowthTime => _growthTime;
        public Vector2 Size => new Vector2(_column, _row);
        public int CountTiles => _row * _column;
        public Vector3 Position => _position;
    }
}
