using System.Collections.Generic;
using UnityEngine;

namespace Farm
{
    public class CropsSpawner : MonoBehaviour
    {
        private CropsFieldSO[] _cropsFieldsSO;
        public List<CropsTile> SpawnedTiles => _spawnedTiles;
        private List<CropsTile> _spawnedTiles;

        private void Awake()
        {
            _cropsFieldsSO = Resources.LoadAll<CropsFieldSO>("CropsField");
        }

        public void Init()
        {
            Spawn();
        }

        private void Spawn()
        {
            _spawnedTiles = new List<CropsTile>();

            foreach (var field in _cropsFieldsSO)
            {
                for(int x = 0; x < field.Size.x; x++)
                {
                    for (int z = 0; z < field.Size.y; z++)
                    {
                        var position = new Vector3(x, 0, z) + field.Position;
                        var cropsTile = Instantiate(field.Prefab, position, Quaternion.identity, transform);

                        var growth = cropsTile.gameObject.AddComponent<CropsGrowth>();
                        growth.InitStartSettings(field.GrowthTime);
                        cropsTile.Init(growth);
                        _spawnedTiles.Add(cropsTile);
                    }
                }
            }
        }
    }
}
