using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private ARRaycastManager arRaycastmanager;
    private GameObject placed;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        arRaycastmanager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);

        if (arRaycastmanager.Raycast(touch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            // Si el objeto no ha sido creado todavía...
            if (placed == null)
            {
                // Instancia el prefab en la posición del hit.
                placed = Instantiate(prefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                // Si el objeto ya existe, simplemente mueve su posición
                // a la nueva posición del hit.
                placed.transform.position = hitPose.position;
            }
        }
    }
}
