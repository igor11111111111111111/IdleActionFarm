using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Farm
{
    public class GrowthTickUpdate : MonoBehaviour
    {
        private List<CropsGrowth> _tiles;
        private float _tickTime = 1f;

        public void Init(List<CropsTile> tiles)
        {
            _tiles = new List<CropsGrowth>(); // linq need
            foreach (var tile in tiles)
            {
                _tiles.Add(tile.CropsGrowth);
            } //

            foreach (var tile in _tiles)
            {
                tile.Restart();
            }

            StopAllCoroutines();
            StartCoroutine(CustomUpdate());
        }

        private IEnumerator CustomUpdate()
        {
            while (true)
            {
                yield return new WaitForSeconds(_tickTime);
                foreach (var tile in _tiles)
                {
                    tile.Tick(_tickTime);
                }
            }  
        }
    }
}
