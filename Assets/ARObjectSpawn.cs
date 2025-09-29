using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARObjectSpawn : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject spawnedObject;

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // Detecta toque en pantalla
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);

            // Lanza raycast al plano detectado
            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                if (spawnedObject == null)
                {
                    // Instancia el prefab solo la primera vez
                    spawnedObject = Instantiate(prefabToSpawn, hitPose.position, hitPose.rotation);
                }
                else
                {
                    // Si ya existe, moverlo
                    spawnedObject.transform.position = hitPose.position;
                }

                // Llama a la interacción del objeto instanciado
                spawnedObject.GetComponent<InteractObject>()?.OnTapped();
            }
        }
    }
}
