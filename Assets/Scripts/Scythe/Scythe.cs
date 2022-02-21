using UnityEngine;
using EzySlice;

namespace Farm
{
    public class Scythe : MonoBehaviour
    {
        [SerializeField]
        private ScytheTrigger _scytheTrigger;
        [SerializeField]
        private CropsPart _cropsPartPrefab;

        private void Awake()
        {
            _scytheTrigger.OnFindTile += OnFindTargetHandler;
        }

        private void OnFindTargetHandler(CropFilling cropFillindg)
        {
            GameObject tileTrigger = cropFillindg.gameObject;
            Material material = cropFillindg.Material;
            SlicedHull slised = tileTrigger.Slice(transform.position, -transform.right, material);

            if (slised == null)
                return;

            CreateCropsPart(tileTrigger, material);
            CreateLowerHull(cropFillindg, tileTrigger, slised, material);
            Destroy(tileTrigger);
        }

        private void CreateCropsPart(GameObject tileTrigger, Material material)
        {
            var cropsPart = Instantiate(_cropsPartPrefab, tileTrigger.transform.position, Quaternion.identity);
            cropsPart.Init(material);
        }

        private void CreateLowerHull(CropFilling cropFilling, GameObject tileTrigger, SlicedHull slised, Material material)
        {
            GameObject slisedDown = slised.CreateLowerHull(tileTrigger, material);
            slisedDown.transform.position = tileTrigger.transform.position;
            slisedDown.transform.SetParent(cropFilling.CropsTile.transform);

            cropFilling.CropsTile.InitSlisedPart(slisedDown);
        }
    }
}
