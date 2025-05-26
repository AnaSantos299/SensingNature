using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    public BoxCollider mapReference;
    public Camera playerCamera;
    public Transform playerTransform;

    public RectTransform mapContainer;
    public RectTransform playerIndicator;

    public Vector2 mapTextureSize = new Vector2(1024, 1024);
    public Bounds mapBounds;

    public float minimapScale = 1f;

    private void Awake()
    {
        mapReference.gameObject.SetActive(true);
        mapBounds = mapReference.bounds;
        mapReference.gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        Transform rotationReferemce = playerCamera.transform;
        Transform positionReference = playerTransform;

        Vector2 unitScale = new Vector2(mapTextureSize.x / mapBounds.size.x, mapTextureSize.y / mapBounds.size.z);

        Vector3 positionOffset = mapBounds.center - positionReference.position;

        Vector2 mapPosition = new Vector2(positionOffset.x * unitScale.x, positionOffset.z * unitScale.y) * minimapScale;

        Quaternion mapRotation = default;

        Vector3 mapScale = new Vector3(minimapScale, minimapScale, minimapScale);

        Quaternion playerRotation = Quaternion.Euler(0, 0, -rotationReferemce.eulerAngles.y);

        playerIndicator.rotation = playerRotation;

        mapContainer.localPosition = mapPosition;
        mapContainer.rotation = mapRotation;
        mapContainer.localScale = mapScale;
    }
}
